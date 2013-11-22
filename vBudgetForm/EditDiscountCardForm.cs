using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class EditDiscountCardForm : Form
    {
        public EditDiscountCardForm(System.Data.SqlClient.SqlConnection inConnection, ref System.Data.DataRow inCard){
            this.InitializeComponent();
            this.cConnection = inConnection;
            this.card = inCard;
        }

        private void EditDiscountCardForm_Load(object sender, EventArgs e){
            System.Data.SqlClient.SqlCommand cmd = Purchases.Vendor.Select(-1);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.vendors = new System.Data.DataTable("Vendors");
            sda.Fill(this.vendors);
            this.cbxVendors.DataSource = this.vendors;
            this.cbxVendors.DisplayMember = "VendorName";
            this.cbxVendors.ValueMember = "VendorID";
            string column = "VendorID";
            if (!System.Convert.IsDBNull(this.card[column]))
                this.cbxVendors.SelectedValue = this.card[column];

            cmd = Vault.Users.Select(-1);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter uda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.users = new System.Data.DataTable("Users");
            uda.Fill(this.users);
            this.cbxUsers.DataSource = this.users;
            this.cbxUsers.DisplayMember = "UserFullName";
            this.cbxUsers.ValueMember = "UserID";
            column = "CardOwner";
            if (!System.Convert.IsDBNull(this.card[column]))
                this.cbxUsers.SelectedValue = this.card[column];

            column = "CardName";
            if (!System.Convert.IsDBNull(this.card[column]))
                this.tbxName.Text = (string)this.card[column];
            column = "CardNumber";
            if (!System.Convert.IsDBNull(this.card[column]))
                this.tbxNumber.Text = (string)this.card[column];
            column = "DiscountPercent";
            if (!System.Convert.IsDBNull(this.card[column]))
                this.nudPercents.Value = (decimal)this.card[column];
            short dtype = 0;
            column = "DiscountType";
            if (!System.Convert.IsDBNull(this.card[column]))
                dtype = (short)this.card[column];
            this.cbxDiscountType.SelectedIndex = (int)dtype - 1;

            column = "Since";
            if (!System.Convert.IsDBNull(this.card[column]))
                this.dtpSince.Value = (DateTime)this.card[column];
            column = "Added";
            if (System.Convert.IsDBNull(this.card[column]))
                this.is_new = true;
            column = "Expired";
            if (!System.Convert.IsDBNull(this.card[column]))
                this.cbxExpired.Checked = true;

            this.card_balance = new DataTable("CardBalance");
            column = "HasBalance";
            this.is_new_balance = ((int)this.card[column] == 0);
            this.has_balance = ((int)this.card[column] == 1);
            return;
        }

        private void btnAccept_Click(object sender, EventArgs e){
            DateTime dt = new DateTime(2012, 10, 4, 0, 0, 0);
            TimeSpan sp = new TimeSpan(500);
            //dt += sp;
            string tm = (dt + sp).ToShortTimeString();
            try
            {
                this.card["CardOwner"] = this.cbxUsers.SelectedValue;
                if (!System.Convert.IsDBNull(this.cbxVendors.SelectedValue))
                    this.card["VendorID"] = this.cbxVendors.SelectedValue;
                this.card["CardName"] = this.tbxName.Text;
                this.card["CardNumber"] = this.tbxNumber.Text;
                this.card["DiscountPercent"] = this.nudPercents.Value;
                this.card["DiscountType"] = this.cbxDiscountType.SelectedIndex + 1;
                this.card["Since"] = this.dtpSince.Value;
                if (this.is_new) this.card["Added"] = System.DateTime.Now;
                if( this.cbxExpired.Checked )
                    this.card["Expired"] = DateTime.Now;

                this.card["VendorName"] = this.cbxVendors.Text;
                System.Data.DataRow user = this.users.Rows[this.cbxUsers.SelectedIndex];
                this.card["Surname"] = user["Surname"];
                this.card["Name"] = user["Name"];
                this.card["SecondName"] = user["SecondName"];

                bool noerrors = true;
                string error = "";
                if (this.is_new)
                    noerrors = Purchases.DiscountCard.Insert(this.cConnection, this.card, out error);
                else
                    noerrors = Purchases.DiscountCard.Update(this.cConnection, this.card, out error);
                if (!noerrors)
                {
                    MessageBox.Show(error);
                }
                else
                {
                    if (this.is_new) this.card["CardID"] = Purchases.DiscountCard.LastId(this.cConnection, out error);
                    if (error.Length > 0)
                        MessageBox.Show(error);
                    else
                    {
                        if ((int)this.card["DiscountType"] > 0)
                        {
                            System.Data.DataRow brow = this.ConvertBalance(this.card["CardID"]);
                            if (this.is_new_balance)
                                noerrors = Purchases.CardBalance.Insert(this.cConnection, brow, out error);
                            else
                                noerrors = Purchases.CardBalance.Update(this.cConnection, brow, out error);
                            if (!noerrors)
                            {
                                MessageBox.Show(error);
                            }
                            else
                            {
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
            }catch(System.Exception ex){
                MessageBox.Show(ex.Message, "Îøèáêà!");
            }
            return;
        }

        private System.Data.DataRow ConvertBalance(object card_id)
        {
            System.Data.SqlClient.SqlCommand cmd = Purchases.CardBalance.Select(null);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            System.Data.DataTable t = new System.Data.DataTable("CardBalance");
            sda.Fill(t);

            System.Data.DataRow dr = t.NewRow();
            dr["CardID"] = card_id;
            foreach (System.Data.DataRow row in this.card_balance.Rows)
            {
                string name = (string)row["Names"];
                decimal val = (decimal)row["CardData"];
                dr[name] = val;
            }
            return dr;
        }

        private void cbxDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxDiscountType.SelectedIndex >= 0)
            {
                if (this.has_balance)
                {
                    try
                    {
                        Guid card_id = (Guid)this.card["CardID"];
                        System.Data.SqlClient.SqlCommand cmd = Purchases.CardBalance.UnpivotedSelect(card_id);
                        cmd.Connection = this.cConnection;
                        System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                        sda.Fill(this.card_balance);
                        this.dgvBalanceInfo.DataSource = this.card_balance;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");
                    }
                }
                else if( this.is_new_balance)
                {

                }
            }else{

            }
            return;
        }

    }
}