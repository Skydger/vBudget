using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class DeleteProductForm : Form
    {
        private bool block = true;
        private System.Data.DataRow product;
        private System.Data.SqlClient.SqlConnection connection = null;
        private System.Data.DataTable contents = null;
        private System.Data.DataTable products = null;
        private System.Data.DataTable categories = null;

        public DeleteProductForm(System.Data.SqlClient.SqlConnection connection,
                                 System.Data.DataRow product)
        {
            InitializeComponent();
            this.product = product;
            this.connection = connection;
        }

        private void DeleteProductForm_Load(object sender, EventArgs e)
        {
            string error;
            this.lvProducts.Columns.Add("Название продукта", 250);
            if( this.product != null ){
                System.Data.SqlClient.SqlCommand cmd = Purchases.ReceiptContent.ExistsCommand((int)this.product["ProductID"]);
                cmd.Connection = this.connection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                this.contents = new System.Data.DataTable("ReceiptContents");
                sda.Fill(this.contents);
                if (this.contents.Rows.Count == 0)
                {

                    if (!Producer.Product.Delete(this.connection, null, this.product, out error))
                    {
                        MessageBox.Show(error, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.Abort;
                        this.Close();
                    }
                    else
                    {
                        DialogResult = DialogResult.Ignore;
                        this.Close();
                    }
                }
                else
                {
                    this.block = true;
                    System.Data.SqlClient.SqlCommand prdccmd = Producer.Commands.ProductCategories();
                    prdccmd.Connection = this.connection;
                    sda = new System.Data.SqlClient.SqlDataAdapter(prdccmd);
                    this.categories = new System.Data.DataTable("Categories");
                    sda.Fill(this.categories);
                    this.categories.Rows.Add(new object[] { -1, "<Без категории>" });

                    this.cbxCategory.DataSource = this.categories;
                    this.cbxCategory.DisplayMember = "CategoryName";
                    this.cbxCategory.ValueMember = "CategoryID";
                    this.cbxCategory.SelectedValue = -1;
                    this.block = false;

                    int cur_rec = -1;
                    System.Windows.Forms.TreeNode r = null;
                    foreach (System.Data.DataRow row in this.contents.Rows)
                    {
                        int prod_id = (int)row["ProductID"];
                        string prod_name = (string)row["ProductName"];
                        int category = (int)row["Category"];
                        int rec_id = (int)row["ReceiptID"];
                        if (rec_id != cur_rec)
                        {
                            DateTime dt = (DateTime)row["Paid"];
                            DateTime dtc = (DateTime)row["Created"];
                            string rn_text = string.Format("[{0}] Оплачено: {1} {2} {3} {4} Создан {5} {6}",
                                                           rec_id, dt.ToShortDateString(), dt.ToShortTimeString(),
                                                           (decimal)row["Price"],
                                                           row["Comment"], dtc.ToShortDateString(), dtc.ToShortTimeString() );
                            r = new TreeNode(rn_text);
                            this.tvContents.Nodes.Add(r);
                        }
                        string rcn_text = string.Format("{0} {1}", prod_id, prod_name );
                        r.Nodes.Add(rcn_text);
                    }
                }
            }else{
                this.Close();
            }
        }

        private void DeleteProductForm_Resize(object sender, EventArgs e)
        {
            this.tbxSearchProduct.Size = new Size(this.scProducts.Width - this.scProducts.SplitterDistance - 114, this.tbxSearchProduct.Size.Height);
            this.cbxCategory.Size = new Size(this.scProducts.Width - this.scProducts.SplitterDistance - 83, this.cbxCategory.Size.Height);
            this.lvProducts.Size = new Size(this.scProducts.Panel2.Width - 13, this.scProducts.Panel2.Height - 67);
        }

        protected void FillUpProducts()
        {
            this.lvProducts.Items.Clear();
            this.lvProducts.Groups.Clear();
            int cur_cat = -1;
            System.Windows.Forms.ListViewGroup lvg = null;
            foreach (DataRow row in this.products.Rows)
            {
                string cat_name = "";
                int cat = -1;
                System.Windows.Forms.ListViewItem lvi = new ListViewItem();
                if (!System.Convert.IsDBNull(row["Category"]) &&
                    !System.Convert.IsDBNull(row["CategoryName"]))
                {
                    cat = (int)row["Category"];
                    cat_name = (string)row["CategoryName"];
                }
                if (cat != cur_cat)
                {
                    lvg = new System.Windows.Forms.ListViewGroup(cat_name);
                    this.lvProducts.Groups.Add(lvg);
                    cur_cat = cat;
                }
                lvi.Group = lvg;
                lvi.Name = ((int)row["ProductID"]).ToString();
                lvi.Text = (string)row["ProductName"];
                lvi.Tag = row;
                this.lvProducts.Items.Add(lvi);
            }
        }

        private void tbxSearchString_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if( this.tbxSearchProduct.Text.Length > 2 ){
                    if ((e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down))
                    {
                        if (this.tbxSearchProduct.Text.Length > 0)
                        {
                            List<Producer.Product.OrderColumn> cols = new List<Producer.Product.OrderColumn>();
                            cols.Add(Producer.Product.OrderColumn.Category);
                            cols.Add(Producer.Product.OrderColumn.Type);
                            System.Data.SqlClient.SqlCommand command = Producer.Product.Select(this.tbxSearchProduct.Text, cols);
                            command.Connection = this.connection;
                            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(command);
                            this.products = new DataTable("Products");
                            sda.Fill(this.products);

                            this.FillUpProducts();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.block)
            {
                List<Producer.Product.OrderColumn> cols = new List<Producer.Product.OrderColumn>();
                cols.Add(Producer.Product.OrderColumn.Category);
                cols.Add(Producer.Product.OrderColumn.Type);
               
                System.Data.SqlClient.SqlCommand cmd = null;
                if (this.cbxCategory.SelectedIndex >= 0)
                {
                    cmd = Producer.Product.Select((Guid)this.cbxCategory.SelectedValue, null, null, cols);
                }
                else
                {
                    cmd = Producer.Product.Select(Guid.Empty, null, null, cols);
                }
                cmd.Connection = this.connection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                this.products = new DataTable("Products");
                sda.Fill(this.products);
                this.FillUpProducts();
            }
            return;
        }

        private void lvProducts_ItemActivate(object sender, EventArgs e)
        {
            try{
                if (this.lvProducts.SelectedItems.Count == 1)
                {
                    string msg = string.Format("Внимание! Продукт \"{0}\"\nво всех найденных чеках будет заменён выбранным\n{1}\n"+
                                               "и удалён!\nЭто действие необратимо, продолжить?",
                                               (string)this.product["ProductName"],
                                               this.lvProducts.SelectedItems[0].Text);
                    if (MessageBox.Show(msg, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string error = "";
                        DataRow new_product = (DataRow)this.lvProducts.SelectedItems[0].Tag;
                        System.Data.SqlClient.SqlTransaction tran = this.connection.BeginTransaction();
                        if (!Purchases.ReceiptContent.ChangeProduct(this.connection, tran, this.product["ProductID"], new_product["ProductID"], out error))
                        {
                            tran.Rollback();
                            MessageBox.Show(error, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else if(!Producer.Product.Delete(this.connection, tran, this.product, out error )){
                            tran.Rollback();
                            MessageBox.Show(error, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else{
                            tran.Commit();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                    }
                }
            }catch(System.Exception exn){
                MessageBox.Show(exn.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }
    }
}