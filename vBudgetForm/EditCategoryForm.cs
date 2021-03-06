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
            if( System.Convert.IsDBNull(this.product_category["CategoryID"]) || (((Guid)this.product_category["CategoryID"]) == Guid.Empty ) ){
                this.Text = "���������� ����� ���������";
                this.isNewCategory = true;
            }else{
                this.Text = "�������������� ��������� #" + this.product_category["CategoryID"].ToString();
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
                bool exists = false;
                if (Producer.Categories.Exists(this.cConnection, this.tbxCategoryName.Text, out exists, out error))
                {
                    if (!exists)
                    {
                        Guid cid = Producer.Categories.NewId(this.cConnection, out error);
                        if (cid != Guid.Empty)
                        {
                            this.product_category["CategoryID"] = cid;
                            noerrors = Producer.Categories.Insert(this.cConnection, this.product_category, out error);
                        }
                        else
                        {
                            noerrors = false;
                            MessageBox.Show(error);
                        }
                    }
                    else
                    {
                        noerrors = false;
                        error = "��������� � ����� ������ ��� ����������!";
                    }
                }else{
                    noerrors = false;
                }
            }else
                noerrors = Producer.Categories.Update(this.cConnection, this.product_category, out error);
            if (!noerrors){
                MessageBox.Show(error, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                //if (this.isNewCategory) 
                //if (error.Length > 0)
                //    MessageBox.Show(error);
                //else
                    this.DialogResult = DialogResult.OK;
            }
            return;
        }
    }
}