using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class EditMakerForm : Form
    {
        private bool is_new;
        public EditMakerForm(System.Data.SqlClient.SqlConnection inConnection, object category, ref DataRow inMaker){
            this.InitializeComponent();
            this.cConnection = inConnection;
            this.maker = inMaker;
            this.current_category = category;
            this.is_new = true;
        }


        private void EditMakerForm_Load(object sender, EventArgs e){
            System.Data.SqlClient.SqlCommand cat_cmd = Producer.Categories.Select(-1);
            cat_cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter catda = new System.Data.SqlClient.SqlDataAdapter(cat_cmd);
            this.categories = new System.Data.DataTable("Categories");
            catda.Fill(this.categories);
            this.categories.Rows.Add(new object[] { -1, "<Без категории>" });
            this.cbxCategories.DataSource = this.categories;
            this.cbxCategories.DisplayMember = "CategoryName";
            this.cbxCategories.ValueMember = "CategoryID";
            if( this.current_category != null )
                this.cbxCategories.SelectedValue = this.current_category;

            System.Data.SqlClient.SqlCommand cmd = Purchases.Vendor.Select(-1);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter vda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.vendors = new System.Data.DataTable("Vendors");
            vda.Fill(this.vendors);
            this.vendors.Rows.Add(new object[] { -1, "<Неизвестен>" });
            this.cbxVendors.DataSource = this.vendors;
            this.cbxVendors.DisplayMember = "VendorName";
            this.cbxVendors.ValueMember = "VendorID";
            //this.cbxCategories.SelectedValue = this.current_category;
            if ( (this.maker != null) && !System.Convert.IsDBNull( this.maker["Name"] ) )
            {
                this.tbxMakerName.Text = (string)this.maker["Name"];
                this.is_new = ( (int)this.maker["MakerId"] < 0 );
            }

        }

        private void btnAccept_Click(object sender, EventArgs e){
            
            bool noerrors = true;
            string error = "";
            this.maker["Name"] = this.tbxMakerName.Text;
            this.maker["MakerCategory"] = this.cbxCategories.SelectedValue;
            if( !System.Convert.IsDBNull( this.cbxVendors.SelectedValue ) )
                this.maker["Vendor"] = this.cbxVendors.SelectedValue;
            if (this.is_new){
                noerrors = Producer.Maker.Insert(this.cConnection, this.maker, out error);
            }else
                noerrors = Producer.Maker.Update(this.cConnection, this.maker, out error);
            if (!noerrors){
                MessageBox.Show(error);
            }else{
                if (this.is_new) this.maker["MakerId"] = Producer.Maker.LastId(this.cConnection, out error);
                if (error.Length > 0)
                    MessageBox.Show(error);
                else
                    this.DialogResult = DialogResult.OK;
            }


        }
    }
}