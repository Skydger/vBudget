using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class MakersListForm : Form
    {
        public MakersListForm( System.Data.SqlClient.SqlConnection inConnection ){
            this.InitializeComponent();
            this.cConnection = inConnection;
        }

        private void MakersListForm_Load(object sender, EventArgs e)
        {
            this.lvMakers.Columns.Add("№", 30);
            this.lvMakers.Columns.Add("Идентификатор", 30);
            this.lvMakers.Columns.Add("Наименование организации", 190);
            this.lvMakers.Columns.Add("Тип", 50);
            this.lvMakers.Columns.Add("Продавец", 50);
            //this.lvMakers.Columns.Add("Создан", 50);

            System.Data.SqlClient.SqlCommand cmd = Producer.Maker.Select(-1);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.makers = new System.Data.DataTable("Makers");
            sda.Fill(this.makers);

            this.RefreshMakersList();
        }

        void AddNewRow(int position, System.Data.DataRow row){
            ListViewItem lvi = new ListViewItem();
            lvi.Name = (position).ToString();
            lvi.Text = (position).ToString();
            int mid = 0;
            if (!System.Convert.IsDBNull(row["MakerId"])) mid = (int)row["MakerId"];
            string maker = "";
            if (!System.Convert.IsDBNull(row["Name"])) maker = (string)row["Name"];
            string mtype = "";
            if (!System.Convert.IsDBNull(row["CategoryName"])) mtype = ((string)row["CategoryName"]);
            string vendor = "";
            if (!System.Convert.IsDBNull(row["Vendor"])) vendor = ((int)row["Vendor"]).ToString();

//            byte[] logo = null;
//            if (!System.Convert.IsDBNull(row["Logo"])) logo = (byte[])row["Logo"];
            //DateTime cr_dtm = new DateTime(1900, 1, 1);
            //if (!System.Convert.IsDBNull(row["Created"])) cr_dtm = ((DateTime)row["Created"]);
            lvi.SubItems.Add(mid.ToString());
            lvi.SubItems.Add(maker);
            lvi.SubItems.Add(mtype);
//            lvi.SubItems.Add(logo);
            lvi.SubItems.Add(vendor);
            //lvi.SubItems.Add(cr_dtm.ToShortDateString() + " " + cr_dtm.ToShortTimeString());


            this.lvMakers.Items.Add(lvi);
            return;
        }
        void RefreshMakersList(){
            int i = 0;
            foreach (System.Data.DataRow drw in this.makers.Rows)
            {
                this.AddNewRow(++i, drw);
            }
            return;
        }

        private void lvMakers_ItemActivate(object sender, EventArgs e)
        {
            if (this.lvMakers.SelectedItems.Count > 0){
                int idx = this.lvMakers.SelectedItems[0].Index;
                System.Data.DataRow drw = this.makers.Rows[idx];
                EditMakerForm ef = new EditMakerForm(this.cConnection, null, ref drw);
                if (ef.ShowDialog() == DialogResult.OK)
                {

                }
            }
            return;
        }
    }
}