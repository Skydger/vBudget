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
            this.lvVendors.Columns.Add("Чеки", 50);

            System.Data.SqlClient.SqlCommand cmd = Purchases.Vendor.Select(-1, Guid.Empty);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.vendors = new System.Data.DataTable("Vendors");
            sda.Fill(this.vendors);

            this.RefreshVendorsList("");
        }

        ListViewGroup FindGroup(Guid company_id, string group_name)
        {
            ListViewGroup grp = null;
            if ( this.lvVendors.Groups.Count == 0 )
            {
                grp = new ListViewGroup(Guid.Empty.ToString(), "");
                this.lvVendors.Groups.Add(grp);
                grp = null;
            }
            foreach (ListViewGroup g in this.lvVendors.Groups)
            {
                if (g.Header == group_name)
                {
                    grp = g;
                    break;
                }
            }
            if (grp == null)
            {
                if (company_id == Guid.Empty)
                    grp = this.lvVendors.Groups[0];
                else
                {
                    grp = new ListViewGroup(company_id.ToString(), group_name);
                    this.lvVendors.Groups.Add(grp);
                }
            }
            return grp;
        }

        void AddNewRow(int position, System.Data.DataRow row){
            ListViewItem lvi = new ListViewItem();
            lvi.Name = (position + 1).ToString();
            lvi.Text = (position + 1).ToString();
            Guid vid = Guid.Empty;
            string col_name = "VendorID";
            if (!System.Convert.IsDBNull(row[col_name])) vid = (Guid)row[col_name];
            Guid cid = Guid.Empty;
            col_name = "ParentCompany";
            if (!System.Convert.IsDBNull(row[col_name])) cid = (Guid)row[col_name];
            string c_name = "";
            col_name = "CompanyName";
            if (!System.Convert.IsDBNull(row[col_name])) c_name = (string)row[col_name];
            string vendor = "";
            col_name = "VendorName";
            if (!System.Convert.IsDBNull(row[col_name])) vendor = (string)row[col_name];
            string vtype = "";
            col_name = "VendorType";
            if (!System.Convert.IsDBNull(row[col_name])) vtype = ((int)row[col_name]).ToString();
//            byte[] logo = null;
//            if (!System.Convert.IsDBNull(row["Logo"])) logo = (byte[])row["Logo"];
            DateTime cr_dtm = new DateTime(1900, 1, 1);
            col_name = "Created";
            if (!System.Convert.IsDBNull(row[col_name])) cr_dtm = ((DateTime)row[col_name]);
            int rcount = 0;
            col_name = "ReceiptsCount";
            if (!System.Convert.IsDBNull(row[col_name])) rcount = (int)row[col_name];

            lvi.SubItems.Add(vid.ToString());
            lvi.SubItems.Add(vendor);
            lvi.SubItems.Add(vtype);
//            lvi.SubItems.Add(logo);
            lvi.SubItems.Add("");
            lvi.SubItems.Add(cr_dtm.ToShortDateString() + " " + cr_dtm.ToShortTimeString());
            lvi.SubItems.Add(rcount.ToString());
            lvi.Group = this.FindGroup(cid, c_name);
            lvi.Tag = row;
            this.lvVendors.Items.Add(lvi);
            return;
        }
        void UpdateRow(int position, System.Data.DataRow row)
        {
            if (position >= 0 && position < this.lvVendors.Items.Count)
            {
                ListViewItem lvi = this.lvVendors.Items[position];

                Guid cid = Guid.Empty;
                string col_name = "ParentCompany";
                if (!System.Convert.IsDBNull(row[col_name])) cid = (Guid)row[col_name];
                string c_name = "";
                col_name = "CompanyName";
                if (!System.Convert.IsDBNull(row[col_name])) c_name = (string)row[col_name];

                string vendor = "";
                col_name = "VendorName";
                if (!System.Convert.IsDBNull(row[col_name])) vendor = (string)row[col_name];
                lvi.SubItems[2].Text = vendor;
                string vtype = "";
                col_name = "VendorType";
                if (!System.Convert.IsDBNull(row[col_name])) vtype = ((int)row[col_name]).ToString();
                lvi.SubItems[3].Text = vtype;
                lvi.Group = this.FindGroup(cid, c_name);
                lvi.Tag = row;
            }
            return;
        }

        void RefreshVendorsList(string vendor_name){
            this.lvVendors.Groups.Clear();
            this.lvVendors.Items.Clear();

            DataRow[] drows = null;
            if (vendor_name.Length > 0)
            {
                string filter = string.Format("VendorName like '%{0}%'", vendor_name);
                drows = this.vendors.Select(filter);
            }
            else
            {
                drows = this.vendors.Select();
            }
            int i = 0;
            foreach (System.Data.DataRow drw in drows)
            {
                this.AddNewRow(i++, drw);
            }
            return;
        }

        private void lvVendors_ItemActivate(object sender, EventArgs e){
            if (this.lvVendors.SelectedItems.Count > 0){
                System.Data.DataRow drw = (System.Data.DataRow)this.lvVendors.SelectedItems[0].Tag;
                int idx = this.lvVendors.SelectedItems[0].Index;
                //System.Data.DataRow drw = this.vendors.Rows[idx];
                VendorForm vf = new VendorForm(this.cConnection, ref drw);
                if (vf.ShowDialog() == DialogResult.OK){
                    this.UpdateRow(idx, drw);
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

        private void lvVendors_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void lvVendors_ItemDrag(object sender, ItemDragEventArgs e)
        {
            System.Type tp = e.Item.GetType();
            if (tp.Name == "ListViewItem")
            {
                ListViewItem lvi = (ListViewItem)e.Item;
                this.lvVendors.DoDragDrop(e.Item, DragDropEffects.Move);
            }
            else
            {
                //this.lvVendors.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void lvVendors_DragDrop(object sender, DragEventArgs e)
        {
            //this.lvVendors.Groups.
            //ListViewItem lvi = this.lvVendors.GetItemAt(e.X, e.Y);
            //if (lvi != null)
            //{

            //}
            
            var lp = this.lvVendors.PointToClient(new Point(e.X, e.Y));
            ListViewItem gitem = this.lvVendors.GetItemAt(lp.X, lp.Y);
            //ListViewHitTestInfo lvhti = this.lvVendors.HitTest(lp);
            //if (lvhti != null)
            //{

            //}
            var item = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
            if (gitem != null)
            {
                item.Group = gitem.Group;
                DataRow dr1 = (DataRow)item.Tag;
                DataRow dr2 = (DataRow)gitem.Tag;
                Guid pid = Guid.Empty;
                if( !System.Convert.IsDBNull(dr1["ParentCompany"]) )
                    pid = (Guid)dr1["ParentCompany"];
                dr1["ParentCompany"] = dr2["ParentCompany"];
                dr1["CompanyName"] = dr2["CompanyName"];

                string error = "";

                if (!Purchases.Vendor.Update(this.cConnection, dr1, out error))
                {
                    if (pid == Guid.Empty)
                        dr1["ParentCompany"] = DBNull.Value;
                    else
                        dr1["ParentCompany"] = pid;
                    MessageBox.Show("Ошибка при обновлении родительской компании:\n" + error);
                }
                
            }
            return;
        }

        private void tstbxFilter_KeyUp(object sender, KeyEventArgs e)
        {
            this.RefreshVendorsList(this.tstbxFilter.Text);
            return;
        }
    }
}