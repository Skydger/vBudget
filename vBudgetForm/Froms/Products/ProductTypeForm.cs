using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class ProductTypeForm : Form
    {
        public ProductTypeForm(System.Data.SqlClient.SqlConnection inConnection,
                               ref System.Data.DataRow inProductType){
            this.InitializeComponent();
            this.cConnection = inConnection;
            this.product_type = inProductType;
        }

        private void ProductTypeForm_Load(object sender, EventArgs e){
            // TODO сделать для обновления
            System.Data.SqlClient.SqlCommand cat_cmd = Producer.Categories.Select(Guid.Empty);
            cat_cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter catda = new System.Data.SqlClient.SqlDataAdapter(cat_cmd);
            System.Data.DataTable tbl = new System.Data.DataTable("Categories");
            catda.Fill(tbl);
            this.cbxCategories.DataSource = tbl;
            this.cbxCategories.DisplayMember = "CategoryName";
            this.cbxCategories.ValueMember = "CategoryID";
            string col_name = "Category";
            if (!System.Convert.IsDBNull(this.product_type[col_name])) this.cbxCategories.SelectedValue = this.product_type[col_name];
            this.isNewType = (System.Convert.IsDBNull(this.product_type["TypeId"]) || ((int)this.product_type["TypeId"]) < 0);

            string caption = "Добавление нового типа продукта";
            if (!this.isNewType)
            {
                int ptype = -1;
                col_name = "TypeId";
                if (!System.Convert.IsDBNull(this.product_type[col_name]))
                    ptype = (int)this.product_type[col_name];
                col_name = "Name";
                if (!System.Convert.IsDBNull(this.product_type[col_name]))
                    this.tbxProductType.Text = (string)this.product_type[col_name];
                col_name = "Comment";
                if (!System.Convert.IsDBNull(this.product_type[col_name]))
                    this.tbxComment.Text = (string)this.product_type[col_name];

                caption = string.Format("Редактирование типа продукта #{0}", ptype);
            }
            this.Text = caption;
            return;
        }

        private void btnAccept_Click(object sender, EventArgs e){
            if (!System.Convert.IsDBNull(this.cbxCategories.SelectedValue) && ( this.cbxCategories.SelectedValue != null )){
                Guid cat_id = (Guid)this.cbxCategories.SelectedValue;
                this.product_type["Category"] = this.cbxCategories.SelectedValue;
                this.product_type["Name"] = this.tbxProductType.Text;
                this.product_type["Comment"] = this.tbxComment.Text;
                string err;
                bool noerror = true;
                if (this.isNewType){
                    this.product_type["TypeId"] = Producer.ProductTypes.NextId( this.cConnection, cat_id, out err );
                    if (err.Length == 0)
                    {
                        noerror = Producer.ProductTypes.Insert(this.cConnection, this.product_type, out err);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка получения следующего идентификатора:\n" + err);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }else{
                    noerror = Producer.ProductTypes.Update(this.cConnection, this.product_type, out err);
                }
                if (!noerror) MessageBox.Show("Ошибка обновления данных!\n" + err);
                this.DialogResult = (noerror ? DialogResult.OK : DialogResult.Cancel);

/*
                    System.Data.SqlClient.SqlDataAdapter ptda = new System.Data.SqlClient.SqlDataAdapter();
                    ptda.UpdateCommand = Producer.ProductTypes.Update();
                    ptda.UpdateCommand.Connection = this.cConnection;
                    ptda.InsertCommand = Producer.ProductTypes.Insert();
                    ptda.InsertCommand.Connection = this.cConnection;
                    ptda.Update(new DataRow[] { this.product_type });
 */
            }else{
                MessageBox.Show("Категория не может быть пустой!");
                this.DialogResult = DialogResult.Cancel;
            }
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }


    }
}