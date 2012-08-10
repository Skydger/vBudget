using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class PositionDetailsForm : Form
    {
        private bool block_refresh;
        private int product_id;
        private System.Data.DataTable p_prices = null;
        public string ProductName{
            set { this.lblProduct.Text = "Продукт: " + value; }
        }

        public int ProductId
        {
            set { this.product_id = value; }
        }

        // Стоимость товара
        public object Price{
            get { return this.nudPrice.Value; }
        }
        // Количество
        public object Discount{
            get{
                Decimal dcm = (Decimal)this.nudDiscount.Value;
                dcm = dcm / 100;
                return (object)dcm;
            }
            set { this.nudDiscount.Value = (decimal)value; }
        }
        // Стоимость
        public object Units{
            get { return (object)this.cbxUnits.Text; }
        }
        // Скидка
        public object Amount{
            get { return this.nudAmount.Value; }
        }

        // ID покупателя
        public object BuyerId{
            get { return this.cbxBuyer.SelectedValue; }
            set { this.cbxBuyer.SelectedValue = value; }
        }
        // ФИО Покупателя
        public object BuyerFullName{
            get { return this.cbxBuyer.Text; }
        }
        // ID получателя
        public object ReceiverId
        {
            get { return this.cbxReceiver.SelectedValue; }
            set { this.cbxReceiver.SelectedValue = value; }
        }
        // ФИО получателя
        public object ReceiverFullName{
            get { return this.cbxReceiver.Text; }
        }

        public PositionDetailsForm(System.Data.SqlClient.SqlConnection connection, ref System.Data.DataRow inRow ){
            this.InitializeComponent();
            this.cConnection = connection;
            this.product = inRow;

        }

        private void btnOk_Click(object sender, EventArgs e){
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e){
            this.DialogResult = DialogResult.Cancel;
        }

        private void PositionDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.block_refresh = true;
                this.cbxUnits.SelectedIndex = 0;
                System.Data.DataTable buyers = null;
                System.Data.DataTable recvrs = null;
                System.Data.SqlClient.SqlCommand cmd = Vault.Users.Select(-1);
                cmd.Connection = this.cConnection;

                System.Data.SqlClient.SqlDataAdapter bda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                System.Data.SqlClient.SqlDataAdapter rda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                buyers = new System.Data.DataTable("Users");
                recvrs = new System.Data.DataTable("Users");
                bda.Fill(buyers);
                rda.Fill(recvrs);

                this.cbxBuyer.DataSource = buyers;
                this.cbxBuyer.DisplayMember = "UserFullName";
                this.cbxBuyer.ValueMember = "UserID";

                this.cbxReceiver.DataSource = recvrs;
                this.cbxReceiver.DisplayMember = "UserFullName";
                this.cbxReceiver.ValueMember = "UserID";

                if (this.product != null)
                {
                    if (!System.Convert.IsDBNull(this.product["Buyer"]))
                        this.cbxBuyer.SelectedValue = this.product["Buyer"];
                    if (!System.Convert.IsDBNull(this.product["Receiver"]))
                        this.cbxReceiver.SelectedValue = this.product["Receiver"];
                    this.nudPrice.Value = (decimal)this.product["Price"];
                    if (!System.Convert.IsDBNull(this.product["Amount"]))
                        this.nudAmount.Value = (decimal)this.product["Amount"];
                    this.nudDiscount.Value = ((decimal)this.product["Discount"] * 100);
                    if (!System.Convert.IsDBNull(this.product["Units"]))
                        this.cbxUnits.Text = (string)this.product["Units"];
                }

                if (this.product_id == -1) this.product_id = (int)this.product["ProductID"];
                this.p_prices = new System.Data.DataTable("ProductPrices"); ;
                cmd = Statistics.Products.ProductPrices(this.product_id);
                cmd.Connection = this.cConnection;

                System.Data.SqlClient.SqlDataAdapter pda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                pda.Fill(p_prices);
                //DataColumn picol = new DataColumn("PricaAndVendor", typeof(string), "CAST(Price AS VARCHAR(50)) + ' - ' + VendorName");
                //p_prices.Columns.Add(picol);

                this.cbxPrices.DataSource = p_prices;
                this.cbxPrices.DisplayMember = "PricaAndVendor";
                this.cbxPrices.ValueMember = "Price";
                this.block_refresh = false;
            }catch(System.Exception ex ){
                MessageBox.Show(ex.Message);
            }
        }

        private void CalculateTotal(){
            decimal total = this.nudPrice.Value * (1 - this.nudDiscount.Value / 100);
            total *= this.nudAmount.Value;
            decimal discount = this.nudPrice.Value * this.nudDiscount.Value / 100;
            discount *= this.nudAmount.Value;
            this.lblTotal.Text = "Итог: " + total.ToString("0.00") + " (скидка: " + discount.ToString("0.00") + ")";
            return;
        }

        private void nudPrice_ValueChanged(object sender, EventArgs e){
            this.CalculateTotal();
            return;
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e){
            this.CalculateTotal();
            return;
        }

        private void nudAmount_ValueChanged(object sender, EventArgs e){
            this.CalculateTotal();
            return;
        }

        private void cbxPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( !this.block_refresh && !System.Convert.IsDBNull( this.cbxPrices.SelectedValue ) )
                this.nudPrice.Value = (decimal)this.cbxPrices.SelectedValue;
        }
    }
}