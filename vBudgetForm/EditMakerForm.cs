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
            System.Data.SqlClient.SqlCommand cat_cmd = Producer.Categories.Select(Guid.Empty);
            cat_cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter catda = new System.Data.SqlClient.SqlDataAdapter(cat_cmd);
            this.categories = new System.Data.DataTable("Categories");
            this.categories.Columns.AddRange(new DataColumn[] { new DataColumn("CategoryID"), new DataColumn("CategoryName") });
            this.categories.Rows.Add(new object[] { Guid.Empty, "<Без категории>" });
            catda.Fill(this.categories);
            this.cbxCategories.DataSource = this.categories;
            this.cbxCategories.DisplayMember = "CategoryName";
            this.cbxCategories.ValueMember = "CategoryID";
            if( this.current_category != null )
                this.cbxCategories.SelectedValue = this.current_category;

            System.Data.SqlClient.SqlCommand cmd = Purchases.Vendor.Select(-1, Guid.Empty);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter vda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.vendors = new System.Data.DataTable("Vendors");
            this.vendors.Columns.AddRange(new DataColumn[] { new DataColumn("VendorID"), new DataColumn("VendorName") });
            this.vendors.Rows.Add(new object[] { Guid.Empty, "<Неизвестен>" });
            vda.Fill(this.vendors);
            this.cbxVendors.DataSource = this.vendors;
            this.cbxVendors.DisplayMember = "VendorName";
            this.cbxVendors.ValueMember = "VendorID";

            string info = "Редактирование производителя";
            if (this.maker != null)
            {
                string column = "Name";
                string maker_name = "";
                if (!System.Convert.IsDBNull(this.maker[column]))
                    maker_name = (string)this.maker[column];
                this.tbxMakerName.Text = maker_name;

                column = "Address";
                string maker_addr = "";
                if (!System.Convert.IsDBNull(this.maker[column]))
                    maker_addr = (string)this.maker[column];
                this.tbxAddress.Text = maker_addr;

                column = "WebSite";
                string maker_web = "";
                if (!System.Convert.IsDBNull(this.maker[column]))
                    maker_web = (string)this.maker[column];
                this.tbxWebSite.Text = maker_web;

                column = "MakerID";
                this.is_new = System.Convert.IsDBNull(this.maker[column]) || ((Guid)this.maker[column] == Guid.Empty);
            }
            else
            {
                is_new = true;
            }
            if (this.is_new)
            {
                string column = "MakerID";
                string error = "";
                this.maker[column] = Producer.Maker.NewId(this.cConnection, out error);
                if ((Guid)this.maker[column] == Guid.Empty)
                    MessageBox.Show(error);
                info = "Новый производитель";
            }

            this.Text = string.Format("{0}: #{1}", info, this.maker["MakerID"]);

        }

        private void btnAccept_Click(object sender, EventArgs e){
            
            bool noerrors = true;
            string error = "";
            this.maker["Name"] = this.tbxMakerName.Text;
            this.maker["MakerCategory"] = this.cbxCategories.SelectedValue;
            //if( !System.Convert.IsDBNull( this.cbxVendors.SelectedValue ) )
            this.maker["Vendor"] = this.cbxVendors.SelectedValue;
            this.maker["Address"] = this.tbxAddress.Text;
            this.maker["WebSite"] = this.tbxWebSite.Text;
            if (this.is_new){
                noerrors = Producer.Maker.Insert(this.cConnection, this.maker, out error);
            }else
                noerrors = Producer.Maker.Update(this.cConnection, this.maker, out error);
            if (!noerrors){
                MessageBox.Show(error);
            }else{
                this.DialogResult = DialogResult.OK;
            }


        }
    }
}