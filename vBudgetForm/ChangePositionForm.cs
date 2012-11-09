using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class ChangePositionForm : Form
    {
        public int NewProductID{
            get { return this.product_id; }
        }
        public ChangePositionForm(System.Data.SqlClient.SqlConnection current_connection, object current_product){
            InitializeComponent();
            this.connection = current_connection;
            this.product_id = (int)current_product;
        }

        private void ChangePositionForm_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataAdapter sda = null;

            System.Data.SqlClient.SqlCommand prdccmd = Producer.Commands.Products(-1, -1 );
            prdccmd.Connection = this.connection;
            sda = new System.Data.SqlClient.SqlDataAdapter(prdccmd);
            this.products = new System.Data.DataTable("Products");
            sda.Fill(this.products);
            this.cbxProducts.DataSource = this.products;
            this.cbxProducts.DisplayMember = "ProductName";
            this.cbxProducts.ValueMember = "ProductID";
            this.cbxProducts.SelectedValue = this.product_id;

            prdccmd = Producer.Commands.Products( -1, this.product_id );
            prdccmd.Connection = this.connection;
            sda = new System.Data.SqlClient.SqlDataAdapter(prdccmd);
            System.Data.DataTable prods = new System.Data.DataTable("Product");
            sda.Fill(prods);
            

            System.Data.SqlClient.SqlCommand catccmd = Producer.Commands.ProductCategories();
            catccmd.Connection = this.connection;
            sda = new System.Data.SqlClient.SqlDataAdapter(catccmd);
            this.categories = new System.Data.DataTable("Categories");
            sda.Fill(this.categories);
            this.cbxCategory.DataSource = this.categories;
            this.cbxCategory.DisplayMember = "CategoryName";
            this.cbxCategory.ValueMember = "CategoryID";
            this.cbxCategory.SelectedValue = prods.Rows[0]["Category"];
            //this.block = false;

            //this.tbxCurrentProduct.Text = this.product["ProductName"].ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e){
            if (!System.Convert.IsDBNull(this.cbxProducts.SelectedValue)
                && (this.product_id != (int)this.cbxProducts.SelectedValue))
            {
                this.product_id = (int)this.cbxProducts.SelectedValue;
                this.DialogResult = DialogResult.OK;
            }else{
                this.DialogResult = DialogResult.Cancel;
            }
            return;
        }

        private void btnAddCategory_Click(object sender, EventArgs e){
            System.Data.DataRow new_category = this.categories.NewRow();
            EditCategoryForm ecf = new EditCategoryForm(this.connection, ref new_category);
            if (ecf.ShowDialog() == DialogResult.OK){
                this.categories.Rows.Add(new_category);
            }
            return;
        }

        private void btnAddProduct_Click(object sender, EventArgs e){
            System.Data.DataRow new_product = this.products.NewRow();
            if (!System.Convert.IsDBNull(this.cbxCategory.SelectedValue)) new_product["Category"] = this.cbxCategory.SelectedValue;
            AddProductForm apf = new AddProductForm(this.connection, ref new_product);
            if (apf.ShowDialog() == DialogResult.OK){
                this.products.Rows.Add(new_product);
            }
        }
    }
}