using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class DiscountCardsListForm : Form
    {
        public DiscountCardsListForm(System.Data.SqlClient.SqlConnection inConnection){
            this.InitializeComponent();
            this.cConnection = inConnection;
        }

        private void DiscountCardsListForm_Resize(object sender, EventArgs e){
            this.lvDiscountCards.Size = new Size(this.Width - 16, this.Height - 64 );
        }

        private void DiscountCardsListForm_Load(object sender, EventArgs e)
        {
            this.lvDiscountCards.Columns.Add("№", 30);
            this.lvDiscountCards.Columns.Add("Владелец", 90);
            this.lvDiscountCards.Columns.Add("Название", 120);
            this.lvDiscountCards.Columns.Add("Номер карты", 120);
            this.lvDiscountCards.Columns.Add("%", 50);
            this.lvDiscountCards.Columns.Add("Наименование организации", 120);
            this.lvDiscountCards.Columns.Add("Дата", 80);
            this.lvDiscountCards.Columns.Add("Действительна", 50);

            System.Data.SqlClient.SqlCommand cmd = Purchases.DiscountCard.Select();
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.cards = new System.Data.DataTable("DiscountCard");
            sda.Fill(this.cards);

            this.RefreshCardsList();
            return;
        }

        void AddNewRow(int position, System.Data.DataRow row){
            ListViewItem lvi = new ListViewItem();
            lvi.Name = (position + 1).ToString();
            lvi.Text = (position + 1).ToString();
            string snm = "", nm = "", scnm = "";
            if (!System.Convert.IsDBNull(row["Surname"])) snm = (string)row["Surname"];
            if (!System.Convert.IsDBNull(row["Name"])) nm = (string)row["Name"];
            if (!System.Convert.IsDBNull(row["SecondName"])) scnm = (string)row["SecondName"];
            if (nm.Length > 0) nm = nm.Substring(0, 1) + ".";
            if (scnm.Length > 0) scnm = scnm.Substring(0, 1) + ".";
            snm = snm + " " + nm + scnm;

            string card_name = "";
            if (!System.Convert.IsDBNull(row["CardName"])) card_name = (string)row["CardName"];
            string card_num = "";
            if (!System.Convert.IsDBNull(row["CardNumber"])) card_num = (string)row["CardNumber"];
            decimal percent = 0;
            if (!System.Convert.IsDBNull(row["DiscountPercent"])) percent = (decimal)row["DiscountPercent"];


            string vendor = "";
            if (!System.Convert.IsDBNull(row["VendorName"])) vendor = (string)row["VendorName"];
            DateTime cr_dtm = new DateTime(1900, 1, 1);
            if (!System.Convert.IsDBNull(row["Since"])) cr_dtm = ((DateTime)row["Since"]);


            lvi.SubItems.Add(snm);
            lvi.SubItems.Add(card_name);
            lvi.SubItems.Add(card_num);
            lvi.SubItems.Add(percent.ToString());
            lvi.SubItems.Add(vendor);
            lvi.SubItems.Add(cr_dtm.ToShortDateString());
            lvi.SubItems.Add("");

            this.lvDiscountCards.Items.Add(lvi);
            return;
        }
        void RefreshCardsList(){
            int i = 0;
            foreach (System.Data.DataRow drw in this.cards.Rows){
                this.AddNewRow(i++, drw);
            }
            return;
        }

        private void tsmiAddDiscountCard_Click(object sender, EventArgs e){
            System.Data.DataRow new_crd = this.cards.NewRow();
            EditDiscountCardForm edcf = new EditDiscountCardForm(this.cConnection, ref new_crd);
            if (edcf.ShowDialog() == DialogResult.OK){
                this.cards.Rows.Add(new_crd);
                this.AddNewRow(this.lvDiscountCards.Items.Count, new_crd);
            }
            return;
        }
        private void EditDiscountCard(){
            if (this.lvDiscountCards.SelectedItems.Count > 0){
                int idx = this.lvDiscountCards.SelectedIndices[0];
                System.Data.DataRow crd = this.cards.Rows[idx];
                if (crd != null){
                    EditDiscountCardForm edcf = new EditDiscountCardForm(this.cConnection, ref crd);
                    if (edcf.ShowDialog() == DialogResult.OK)
                    {

                    }
                }else{
                    MessageBox.Show("Ошибка, карта не найдена!");
                }
            }
            return;
        }

        private void lvDiscountCards_ItemActivate(object sender, EventArgs e){
            this.EditDiscountCard();
            return;
        }

        private void tsmiEditDiscountCard_Click(object sender, EventArgs e){
            this.EditDiscountCard();
            return;
        }

        private void tsmiDeleteDiscountCard_Click(object sender, EventArgs e){
            int idx = -1;
            if (this.lvDiscountCards.SelectedItems.Count > 0){
                idx = this.lvDiscountCards.SelectedIndices[0];
                if ( (idx >= 0) &&
                     (MessageBox.Show("Действительно удалить выбранную дисконтную карту?\n" +
                                "Внимание! Если карта была использована, она лишь изменит свой статус на 'Не действительна'.",
                                "Внимание",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Hand
                               ) == DialogResult.Yes) )
                {
                    System.Data.DataRow crd = this.cards.Rows[idx];
                    string sError = "";
                    if (!Purchases.DiscountCard.Delete(this.cConnection, crd, out sError)){
                        MessageBox.Show( "Ошибка при удалении карты:\n" + sError);
                    }else{
                        this.cards.Rows.RemoveAt(idx);
                        this.lvDiscountCards.Items.RemoveAt(idx);
                    }
                }
            }
        }


    }
}