using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class AddProductForm : Form
    {
        private bool block;
        
        public AddProductForm( System.Data.SqlClient.SqlConnection inConnection,
                               ref System.Data.DataRow inProduct )
        {
            this.InitializeComponent();
            this.cConnection = inConnection;
            this.product = inProduct;
            this.block = false;
        }

        private void AddProductForm_Load(object sender, EventArgs e){
            this.block = true;
            if (System.Convert.IsDBNull(this.product["ProductID"]) || (((int)this.product["ProductID"]) < 0 )){
                this.Text = "Новый продукт";
                this.isNew = true;
            }else{
                this.Text = "Редактирование продукта #" + ((int)this.product["ProductID"]).ToString();
                this.isNew = false;
            }

            System.Data.SqlClient.SqlCommand cat_cmd = Producer.Categories.Select(-1);
            cat_cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter catda = new System.Data.SqlClient.SqlDataAdapter(cat_cmd);
            this.categories = new System.Data.DataTable("Categories");
            catda.Fill(this.categories);
            this.categories.Rows.Add(new object[] { -1, "<Без категории>" });
            this.cbxCategories.DataSource = this.categories;
            this.cbxCategories.DisplayMember = "CategoryName";
            this.cbxCategories.ValueMember = "CategoryID";

            if (!System.Convert.IsDBNull(this.product["Category"])){
                this.cbxCategories.SelectedValue = this.product["Category"];

                System.Data.SqlClient.SqlCommand tp_cmd = Producer.ProductTypes.Select((int)this.cbxCategories.SelectedValue);
                tp_cmd.Connection = this.cConnection;
                System.Data.SqlClient.SqlDataAdapter tpda = new System.Data.SqlClient.SqlDataAdapter(tp_cmd);
                this.types_table = new System.Data.DataTable("Types");
                tpda.Fill(this.types_table);
                this.cbxTypes.DataSource = this.types_table;
                this.cbxTypes.DisplayMember = "Name";
                this.cbxTypes.ValueMember = "TypeId";
                if (!System.Convert.IsDBNull(this.product["Type"])) this.cbxTypes.SelectedValue = this.product["Type"];
            }else{
                this.cbxCategories.SelectedValue = -1;
            }

            System.Data.SqlClient.SqlCommand mk_cmd = Producer.Maker.Select(-1);
            mk_cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter mkda = new System.Data.SqlClient.SqlDataAdapter(mk_cmd);
            this.makers = new System.Data.DataTable("Makers");
            mkda.Fill(this.makers);
            this.makers.Rows.Add(new object[] { -1, "<Выберите производителя>" });
            this.cbxMakers.DataSource = this.makers;
            this.cbxMakers.DisplayMember = "Name";
            this.cbxMakers.ValueMember = "MakerId";
            this.cbxMakers.SelectedValue = -1;
            if (!System.Convert.IsDBNull(this.product["Maker"])) this.cbxMakers.SelectedValue = this.product["Maker"];

            if (!System.Convert.IsDBNull(this.product["ProductName"])) this.tbxProductName.Text = (string)this.product["ProductName"];
            if (!System.Convert.IsDBNull(this.product["Barcode"])) this.tbxBarcode.Text = (string)this.product["Barcode"];
            if (!System.Convert.IsDBNull(this.product["Comment"])) this.tbxComment.Text = (string)this.product["Comment"];
            if (!System.Convert.IsDBNull(this.product["Deleted"])) this.cbDeleted.Checked = (bool)this.product["Deleted"];
            this.block = false;
        }

        private void btnAccept_Click(object sender, EventArgs e){
            this.product["ProductName"] = this.tbxProductName.Text;

            if (this.cbxCategories.SelectedValue == null) this.product["Category"] = DBNull.Value;
            else                                          this.product["Category"] = this.cbxCategories.SelectedValue;
            if( this.cbxTypes.SelectedValue == null ) this.product["Type"] = DBNull.Value;
            else                                      this.product["Type"] = this.cbxTypes.SelectedValue;
            if (this.cbxMakers.SelectedValue == null) this.product["Maker"] = DBNull.Value;
            else                                      this.product["Maker"] = this.cbxMakers.SelectedValue;
            this.product["Barcode"] = this.tbxBarcode.Text;
            this.product["Comment"] = this.tbxComment.Text;
            this.product["Created"] = System.DateTime.Now;
            this.product["Updated"] = System.DateTime.Now;
            this.product["Deleted"] = 0;
//            System.Data.SqlClient.SqlDataAdapter prda = new System.Data.SqlClient.SqlDataAdapter();
//            prda.SelectCommand = Producer.Product.Select(-1, null, 0);
//            prda.SelectCommand.Connection = this.cConnection;
            //prda.UpdateCommand = Producer.Product.Update();
            //prda.UpdateCommand.Connection = this.cConnection;
            //prda.InsertCommand = Producer.Product.Insert();
            //prda.InsertCommand.Connection = this.cConnection;
            //prda.Update(new DataRow[] { this.product });
            bool noerrors = true;
            string error = "";
            if( this.isNew )
                noerrors = Producer.Product.Insert(this.cConnection, this.product, out error);
            else
                noerrors = Producer.Product.Update(this.cConnection, this.product, out error);
            if (!noerrors){
                MessageBox.Show(error);
            }else{
                if (this.isNew) this.product["ProductID"] = Producer.Product.LastId(this.cConnection, (int)this.product["Category"], out error);
                if (error.Length > 0)
                    MessageBox.Show(error);
                else
                    this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e){
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e){
            if (!this.block){
                System.Data.SqlClient.SqlCommand cmd = null;
                if (this.cbxCategories.SelectedIndex >= 0){
                    cmd = Producer.ProductTypes.Select((int)this.cbxCategories.SelectedValue);
                }else{
                    cmd = Producer.Commands.Products(-1, -1);
                }
                cmd.Connection = this.cConnection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                this.types_table = new DataTable("ProductTypes");
                sda.Fill(this.types_table);
                this.cbxTypes.DataSource = this.types_table;
                this.cbxTypes.DisplayMember = "Name";
                this.cbxTypes.ValueMember = "TypeId";
            }
            return;
        }

        private void btnAddCategory_Click(object sender, EventArgs e){
            System.Data.DataRow new_category = this.categories.NewRow();
            EditCategoryForm ecf = new EditCategoryForm(this.cConnection, ref new_category);
            if (ecf.ShowDialog() == DialogResult.OK){
                this.categories.Rows.Add(new_category);
            }
            return;
        }

        private void btnAddType_Click(object sender, EventArgs e){
            System.Data.DataRow new_type = this.types_table.NewRow();
            if (!System.Convert.IsDBNull(this.cbxCategories.SelectedValue)) new_type["Category"] = this.cbxCategories.SelectedValue;
            ProductTypeForm ptf = new ProductTypeForm(this.cConnection, ref new_type);
            if (ptf.ShowDialog() == DialogResult.OK){
                this.types_table.Rows.Add(new_type);
            }
            return;
        }

        private void btnAddMaker_Click(object sender, EventArgs e){
            DataRow new_maker = this.makers.NewRow();
            EditMakerForm emf = new EditMakerForm(this.cConnection, this.cbxCategories.SelectedValue, ref new_maker);
            if (emf.ShowDialog() == DialogResult.OK){
                this.makers.Rows.Add(new_maker);
            }
            return;
        }
    }
}