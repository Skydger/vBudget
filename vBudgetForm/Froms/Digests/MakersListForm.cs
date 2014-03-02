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
        public MakersListForm(System.Data.SqlClient.SqlConnection inConnection)
        {
            this.InitializeComponent();
            this.cConnection = inConnection;
        }

        private void MakersListForm_Load(object sender, EventArgs e)
        {
            this.lvMakers.Columns.Add("№", 30);
            this.lvMakers.Columns.Add("Идентификатор", 30);
            this.lvMakers.Columns.Add("Наименование организации", 190);
            this.lvMakers.Columns.Add("Web-страница", 120);
            this.lvMakers.Columns.Add("Тип", 50);
            this.lvMakers.Columns.Add("Продавец", 50);
            //this.lvMakers.Columns.Add("Создан", 50);

            System.Data.SqlClient.SqlCommand cmd = Producer.Maker.Select(Guid.Empty);
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
            lvi.Tag = row;
            Guid mid = Guid.Empty;
            string column = "MakerID";
            if (!System.Convert.IsDBNull(row[column])) mid = (Guid)row[column];
            string maker = "";
            column = "Name";
            if (!System.Convert.IsDBNull(row[column])) maker = (string)row[column];
            column = "WebSite";
            string web_addr = "";
            if (!System.Convert.IsDBNull(row[column])) web_addr = (string)row[column];
            string mtype = "";
            column = "CategoryName";
            if (!System.Convert.IsDBNull(row[column])) mtype = ((string)row[column]);
            string vendor = "";
            column = "Vendor";
            if (!System.Convert.IsDBNull(row[column])) vendor = ((Guid)row[column]).ToString();

//            byte[] logo = null;
//            if (!System.Convert.IsDBNull(row["Logo"])) logo = (byte[])row["Logo"];
            //DateTime cr_dtm = new DateTime(1900, 1, 1);
            //if (!System.Convert.IsDBNull(row["Created"])) cr_dtm = ((DateTime)row["Created"]);
            lvi.SubItems.Add(mid.ToString());
            lvi.SubItems.Add(maker);
            lvi.SubItems.Add(web_addr);
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

        private void EditMaker()
        {
            if (this.lvMakers.SelectedItems.Count > 0)
            {
                int idx = this.lvMakers.SelectedItems[0].Index;
                //System.Data.DataRow drw = this.makers.Rows[idx];
                System.Data.DataRow drw = (System.Data.DataRow)this.lvMakers.SelectedItems[0].Tag;
                EditMakerForm ef = new EditMakerForm(this.cConnection, this.makers.Rows[idx]["MakerCategory"], ref drw);
                if (ef.ShowDialog() == DialogResult.OK)
                {

                }
            }
            return;
        }

        private void lvMakers_ItemActivate(object sender, EventArgs e)
        {
            this.EditMaker();
            return;
        }

        private void tsmiCreate_Click(object sender, EventArgs e)
        {
            DataRow new_maker = this.makers.NewRow();
            EditMakerForm emf = new EditMakerForm(this.cConnection, null, ref new_maker);
            if (emf.ShowDialog() == DialogResult.OK)
            {
                this.makers.Rows.Add(new_maker);
                this.AddNewRow(this.lvMakers.Items.Count, new_maker);
            }
            return;
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            this.EditMaker();
            return;
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (this.lvMakers.SelectedItems.Count > 0)
            {
                int idx = this.lvMakers.SelectedItems[0].Index;
                System.Data.DataRow drw = (System.Data.DataRow)this.lvMakers.SelectedItems[0].Tag;
                if (MessageBox.Show("Действительно удалить поизводителя?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string error = "";
                    if (!Producer.Maker.Delete(this.cConnection, null, drw, out error))
                    {
                        MessageBox.Show("Ошибка при удалении производителя!\n" + error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.lvMakers.Items.RemoveAt(idx);
                    }
                }
            }
            return;
        }
    }
}