using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class EditCategoryForm : Form
    {
        public EditCategoryForm( System.Data.SqlClient.SqlConnection inConnection, ref System.Data.DataRow inCategory ){
            this.InitializeComponent();
            this.cConnection = inConnection;
            this.product_category = inCategory;
        }

        private void EditCategoryForm_Load(object sender, EventArgs e){
            if( System.Convert.IsDBNull(this.product_category["CategoryID"]) || (((int)this.product_category["CategoryID"]) < 0 ) ){
                this.Text = "Добавление новой категории";
                this.isNewCategory = true;
            }else{
                this.Text = "Редактирование категории #" + this.product_category["CategoryID"].ToString();
                this.tbxCategoryName.Text = (string)this.product_category["CategoryName"];
                this.isNewCategory = false;
            }
            return;
        }

        private void btnAccept_Click(object sender, EventArgs e){
            bool noerrors = true;
            string error = "";
            this.product_category["CategoryName"] = this.tbxCategoryName.Text;
            if (this.isNewCategory){
                noerrors = Producer.Categories.Insert(this.cConnection, this.product_category, out error);
            }else
                noerrors = Producer.Categories.Update(this.cConnection, this.product_category, out error);
            if (!noerrors){
                MessageBox.Show(error);
            }else{
                if (this.isNewCategory) this.product_category["CategoryID"] = Producer.Categories.LastId(this.cConnection, out error);
                if (error.Length > 0)
                    MessageBox.Show(error);
                else
                    this.DialogResult = DialogResult.OK;
            }
            return;
        }
    }
}