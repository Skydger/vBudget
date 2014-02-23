using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class PricesForm : Form
    {
        public PricesForm(System.Data.SqlClient.SqlConnection inConnection ){
            this.InitializeComponent();
            this.cConnection = inConnection;
            this.lvPrices.Columns.Add("№", 70);
            this.lvPrices.Columns.Add("Товар", 250);
//            this.lvPrices.Columns.Add("Тип", 70);
//            this.lvPrices.Columns.Add("Производитель", 100);
            this.lvPrices.Columns.Add("Штрих-код", 80);
            this.lvPrices.Columns.Add("Создан", 70);
            this.lvPrices.Columns.Add("Цена", 70);
            this.lvPrices.Columns.Add("Оплачено", 70);
        }

        private void PricesForm_Load(object sender, EventArgs e)
        {
            this.bBlockContent = true;
            System.Data.SqlClient.SqlCommand cat_cmd = Producer.Categories.Select(Guid.Empty);
            cat_cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter catda = new System.Data.SqlClient.SqlDataAdapter(cat_cmd);
            this.categories = new System.Data.DataTable("Categories");
            catda.Fill(this.categories);
            this.categories.Rows.Add(new object[] { Guid.Empty, "<Без категории>" });
            this.cbxCategories.DataSource = this.categories;
            this.cbxCategories.DisplayMember = "CategoryName";
            this.cbxCategories.ValueMember = "CategoryID";
            this.cbxCategories.SelectedValue = Guid.Empty;

            this.bBlockContent = false;
        }

        private void PricesForm_Resize(object sender, EventArgs e)
        {
            this.lvPrices.Size = new Size(this.Width - 40, this.Height - 117);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadPrices(Guid.Empty);
        }

        private void LoadPrices(Guid product_id)
        {

            System.Data.SqlClient.SqlCommand prd_cmd = null;
            if( product_id == Guid.Empty )
                prd_cmd = Statistics.Purchases.ByName(this.cbxProducts.Text);
            else
                prd_cmd = Statistics.Purchases.ByIdentifier(product_id);
            prd_cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter prda = new System.Data.SqlClient.SqlDataAdapter(prd_cmd);
            this.prices = new System.Data.DataTable("ReceiptContents");
            prda.Fill(this.prices);
            
            this.lvPrices.Items.Clear();
            int row_num = 1;
            foreach (System.Data.DataRow row in this.prices.Rows)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Name = row_num.ToString();
                lvi.Text = row_num.ToString();

                string p_name = "";
                if (!System.Convert.IsDBNull(row["ProductName"])) p_name = ((string)row["ProductName"]);
                lvi.SubItems.Add(p_name);
                string b_code = "";
                if (!System.Convert.IsDBNull(row["Barcode"])) b_code = ((string)row["Barcode"]);
                lvi.SubItems.Add(b_code);
                string p_made = "";
                if (!System.Convert.IsDBNull(row["Created"])) p_made = ((DateTime)row["Created"]).ToShortDateString();
                lvi.SubItems.Add(p_made);
                string p_price = "";
                if (!System.Convert.IsDBNull(row["Price"])) p_price = ((decimal)row["Price"]).ToString();
                lvi.SubItems.Add(p_price);
                string p_sold = "";
                if (!System.Convert.IsDBNull(row["Sold"])) p_sold = ((decimal)row["Sold"]).ToString();
                lvi.SubItems.Add(p_sold);
                this.lvPrices.Items.Add(lvi);
                row_num++;
            }
            return;
        }

        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.bBlockContent)
            {
                this.bBlockContent = true;
                System.Data.SqlClient.SqlCommand cmd = null;
                if (this.cbxCategories.SelectedIndex >= 0)
                {
                    cmd = Producer.Commands.Products((Guid)this.cbxCategories.SelectedValue, System.Guid.Empty);
                }
                else
                {
                    cmd = Producer.Commands.Products(Guid.Empty, System.Guid.Empty);
                }
                cmd.Connection = this.cConnection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                this.products = new DataTable("Products");
                sda.Fill(this.products);
                this.cbxProducts.DataSource = this.products;
                this.cbxProducts.ValueMember = "ProductID";
                this.cbxProducts.DisplayMember = "ProductName";
                if( this.products.Rows.Count > 0 )
                    this.LoadPrices((Guid)this.products.Rows[0]["ProductID"]);
                this.bBlockContent = false;
            }
        }

        private void cbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.bBlockContent)
            {
                if (!System.Convert.IsDBNull(this.cbxProducts.SelectedValue))
                {
                    this.LoadPrices((Guid)this.cbxProducts.SelectedValue);
                }
            }
            return;
        }
    }
}