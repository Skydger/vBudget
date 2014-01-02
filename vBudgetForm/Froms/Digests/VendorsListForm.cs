using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class VendorsListForm : Form
    {
        public VendorsListForm(System.Data.SqlClient.SqlConnection inConnection){
            this.InitializeComponent();
            this.cConnection = inConnection;
        }

        private void VendorsListForm_Load(object sender, EventArgs e){
            this.lvVendors.Columns.Add("№", 30);
            this.lvVendors.Columns.Add("Идентификатор", 30);
            this.lvVendors.Columns.Add("Наименование организации", 190 );
            this.lvVendors.Columns.Add("Тип", 50);
            this.lvVendors.Columns.Add("Логотип", 50);
            this.lvVendors.Columns.Add("Создан", 50);

            System.Data.SqlClient.SqlCommand cmd = Purchases.Vendor.Select(-1);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.vendors = new System.Data.DataTable("Vendors");
            sda.Fill(this.vendors);

            this.RefreshVendorsList();
        }

        void AddNewRow(int position, System.Data.DataRow row){
            ListViewItem lvi = new ListViewItem();
            lvi.Name = (position + 1).ToString();
            lvi.Text = (position + 1).ToString();
            int vid = 0;
            if (!System.Convert.IsDBNull(row["VendorID"])) vid = (int)row["VendorID"];
            string vendor = "";
            if (!System.Convert.IsDBNull(row["VendorName"])) vendor = (string)row["VendorName"];
            string vtype = "";
            if (!System.Convert.IsDBNull(row["VendorType"])) vtype = ((int)row["VendorType"]).ToString();
//            byte[] logo = null;
//            if (!System.Convert.IsDBNull(row["Logo"])) logo = (byte[])row["Logo"];
            DateTime cr_dtm = new DateTime(1900, 1, 1);
            if (!System.Convert.IsDBNull(row["Created"])) cr_dtm = ((DateTime)row["Created"]);
            lvi.SubItems.Add(vid.ToString());
            lvi.SubItems.Add(vendor);
            lvi.SubItems.Add(vtype);
//            lvi.SubItems.Add(logo);
            lvi.SubItems.Add("");
            lvi.SubItems.Add(cr_dtm.ToShortDateString() + " " + cr_dtm.ToShortTimeString());


            this.lvVendors.Items.Add(lvi);
            return;
        }
        void RefreshVendorsList(){
            int i = 0;
            foreach (System.Data.DataRow drw in this.vendors.Rows){
                this.AddNewRow(i++, drw);
//                total += (decimal)drw["Price"];
            }
            return;
        }

        private void lvVendors_ItemActivate(object sender, EventArgs e){
            if (this.lvVendors.SelectedItems.Count > 0){
                int idx = this.lvVendors.SelectedItems[0].Index;
                System.Data.DataRow drw = this.vendors.Rows[idx];
                VendorForm vf = new VendorForm(this.cConnection, ref drw);
                if (vf.ShowDialog() == DialogResult.OK){

                }
            }
        }

        private void VendorsListForm_Resize(object sender, EventArgs e){
            this.lvVendors.Size = new Size(this.Width - 16, this.Height - 91);
            return;
        }

        private void tsbAddNewVendor_Click(object sender, EventArgs e){
            System.Data.DataRow new_vendor = this.vendors.NewRow();
            VendorForm vfrm = new VendorForm( this.cConnection, ref new_vendor );
            if (vfrm.ShowDialog() == DialogResult.OK){
                this.vendors.Rows.Add( new_vendor );
                this.AddNewRow(this.vendors.Rows.Count, new_vendor );
            }
            return;
        }
    }
}