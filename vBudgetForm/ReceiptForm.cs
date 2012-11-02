using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class ReceiptForm : Form{
        private bool block;
        private decimal total_price;
        private decimal total_discount;
        private int last_buyer;
        private int last_receiver;

        public ReceiptForm(System.Data.SqlClient.SqlConnection inConnection, ref System.Data.DataRow inReceipt, bool created ){
            InitializeComponent();
            this.total_price = 0;
            this.total_discount = 0;
            this.cConnection = inConnection;
            this.receipt = inReceipt;
            this.isNew = created;
            this.last_buyer = -1;
            this.last_receiver = -1;
        } 

        private void ReceiptForm_Load(object sender, EventArgs e){
            this.block = true;
            System.Data.SqlClient.SqlCommand cmd = Purchases.Vendor.Select(-1);
            cmd.Connection = this.cConnection;

            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.vendors = new System.Data.DataTable("Vendors");
            sda.Fill(this.vendors);

            this.cbxVendors.DataSource = this.vendors;
            this.cbxVendors.DisplayMember = "VendorName";
            this.cbxVendors.ValueMember = "VendorID";

            System.Data.SqlClient.SqlCommand prdccmd = Producer.Commands.ProductCategories();
            prdccmd.Connection = this.cConnection;
            sda = new System.Data.SqlClient.SqlDataAdapter(prdccmd);
            this.categories = new System.Data.DataTable("Categories");
            sda.Fill(this.categories);
            this.categories.Rows.Add(new object[] { -1, "<Без категории>" });

            this.cbxCategory.DataSource = this.categories;
            this.cbxCategory.DisplayMember = "CategoryName";
            this.cbxCategory.ValueMember = "CategoryID";
            this.cbxCategory.SelectedValue = -1;
            this.block = false;

            cmd = Purchases.DiscountCard.Select();
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter сda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.cards = new System.Data.DataTable("DiscountCard");
            сda.Fill(this.cards);
            this.cbxDiscountCards.DataSource = this.cards;
            this.cbxDiscountCards.DisplayMember = "CardName";
            this.cbxDiscountCards.ValueMember = "CardID";
            this.cbxDiscountCards.SelectedValue = -1;
            

            this.LoadReceiptContents();
            return;
        }
        protected void LoadReceiptContents(){
            System.Data.SqlClient.SqlCommand cmd = Purchases.Commands.ReceiptContents((int)this.receipt["ReceiptID"]);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.contents = new System.Data.DataTable("ReceiptContents");

            sda.Fill(this.contents);
            DataColumn ttlcol = new DataColumn("Всего", typeof(Decimal), "Amount * Price * (1.0 - Discount)");
            this.contents.Columns.Add(ttlcol);
            string colname = "ContentID";
            this.contents.Columns[colname].AutoIncrement = true;
//            this.contents.Columns[colname].AutoIncrementSeed = (int)this.contents.Rows[this.contents.Rows.Count - 1][colname] + 1;
            this.contents.Columns[colname].AutoIncrementSeed = -1;
            this.contents.Columns[colname].AutoIncrementStep = -1;
            this.contents.Columns[colname].ReadOnly = true;

            this.dgvReceiptContent.DataSource = this.contents;

            string column_name = "";
            this.dgvReceiptContent.Columns[0].ReadOnly = true;
            this.dgvReceiptContent.Columns[0].Visible = false;
            this.dgvReceiptContent.Columns[1].ReadOnly = true;
            this.dgvReceiptContent.Columns[1].Visible = false;

            column_name = "ProductID";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
//            this.dgvReceiptContent.Columns["ProductID"].Frozen = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = "ID продукта";
            this.dgvReceiptContent.Columns[column_name].Visible = false;
//            this.dgvReceiptContent.Columns[column_name].Frozen = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = "ID продукта";
            column_name = "ProductName";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].Frozen = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = "Наименование позиции";
            this.dgvReceiptContent.Columns[column_name].Width = 250;
            column_name = "Amount";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = "Кол-во";
            this.dgvReceiptContent.Columns[column_name].Width = 60;
            column_name = "Price";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = "Цена";
            this.dgvReceiptContent.Columns[column_name].Width = 60;
            column_name = "Discount";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = "Скидка, %";
            this.dgvReceiptContent.Columns[column_name].Width = 60;
            column_name = "Units";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = "Единицы измерения";
            this.dgvReceiptContent.Columns[column_name].Width = 60;

            column_name = "BuyerFullName";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = "ФИО покупателя";
            this.dgvReceiptContent.Columns[column_name].Width = 100;
            column_name = "ReceiverFullName";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = "ФИО получателя";
            this.dgvReceiptContent.Columns[column_name].Width = 100;



            this.dgvReceiptContent.Columns["Buyer"].ReadOnly = true;
            this.dgvReceiptContent.Columns["Buyer"].Visible = false;
            this.dgvReceiptContent.Columns["Receiver"].ReadOnly = true;
            this.dgvReceiptContent.Columns["Receiver"].Visible = false;

            if (!System.Convert.IsDBNull(this.receipt["ReceiptID"]) &&
                ( (int)this.receipt["ReceiptID"] > 0 ) ){
                this.Text = "Чек #" + this.receipt["ReceiptID"].ToString();
            }
            if (!System.Convert.IsDBNull(this.receipt["DiscountCard"])){
                int dc = (int)this.receipt["DiscountCard"];
                this.cbxDiscountCards.SelectedValue = dc;
            }
            if (!System.Convert.IsDBNull(this.receipt["Payed"])){
                DateTime dtm = (DateTime)this.receipt["Payed"];
                this.dtpPeceiptDate.Value = dtm;
            }
            if (!System.Convert.IsDBNull(this.receipt["Vendor"])){
                int vndr = (int)this.receipt["Vendor"];
                this.cbxVendors.SelectedValue = vndr;
            }
            if (!System.Convert.IsDBNull(this.receipt["Number"])){
                this.tbxReceiptNumber.Text = (string)this.receipt["Number"];
            }
            if (!System.Convert.IsDBNull(this.receipt["Comment"])){
                this.tbxComment.Text = (string)this.receipt["Comment"];
            }
            // Пересчитать чек
            this.RecalculateReceipt();
        }

        private void btnOk_Click(object sender, EventArgs e){
            System.Data.SqlClient.SqlTransaction tran = null;
            try{
                this.receipt["Vendor"] = this.cbxVendors.SelectedValue;
                this.receipt["VendorName"] = this.cbxVendors.Text;

                this.receipt["Payed"] = dtpPeceiptDate.Value;
                this.receipt["Price"] = this.total_price;
                this.receipt["Discount"] = this.total_discount;
                if ( ( this.cbxDiscountCards.SelectedValue == null ) ||
                    System.Convert.IsDBNull( this.cbxDiscountCards.SelectedValue ) )
                    this.receipt["DiscountCard"] = System.Convert.DBNull;
                else
                    this.receipt["DiscountCard"] = this.cbxDiscountCards.SelectedValue;

                this.receipt["Number"] = this.tbxReceiptNumber.Text;
                this.receipt["Comment"] = this.tbxComment.Text;

                this.receipt["Created"] = System.DateTime.Now;
                this.receipt["Updated"] = System.DateTime.Now;

                this.cConnection.Open();
                using ( tran = this.cConnection.BeginTransaction()){
    //            using ( System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope() ){
    //                System.Data.SqlClient.SqlDataAdapter sdarc = new System.Data.SqlClient.SqlDataAdapter();
    //                System.Data.SqlClient.SqlDataAdapter rsda = new System.Data.SqlClient.SqlDataAdapter();
                    System.Data.SqlClient.SqlCommand rcmd = new System.Data.SqlClient.SqlCommand();
                    if (this.isNew){
                        //sdarc.InsertCommand = Purchases.Receipt.InsertCommand(this.receipt);
                        //sdarc.InsertCommand.Connection = this.cConnection;
                        //sdarc.InsertCommand.Transaction = tran;
                        rcmd = Purchases.Receipt.InsertCommand(this.receipt);
                        System.Data.SqlClient.SqlCommand idcmd = new System.Data.SqlClient.SqlCommand("SELECT MAX(ReceiptID) + 1 AS MaxID FROM Purchases.Receipts", this.cConnection, tran);
    //                    int receipt_id = (int)idcmd.ExecuteScalar();
                        this.receipt["ReceiptID"] = idcmd.ExecuteScalar();
                        for (int k = 0; k < this.contents.Rows.Count; k++){
                            this.contents.Rows[k]["ReceiptID"] = this.receipt["ReceiptID"];
                        }
                    }else{
                        //sdarc.UpdateCommand = Purchases.Receipt.UpdateCommand(this.receipt);
                        //sdarc.UpdateCommand.Connection = this.cConnection;
                        //sdarc.UpdateCommand.Transaction = tran;
                        rcmd = Purchases.Receipt.UpdateCommand(this.receipt);
    //                    rsda.UpdateCommand = rcmd;
                    }
                    rcmd.Connection = this.cConnection;
                    rcmd.Transaction = tran;
                    rcmd.ExecuteNonQuery();
    //                int id = (int)rcmd.ExecuteScalar();
    //                System.Data.SqlClient.SqlParameter p = rcmd.Parameters.Add("@ReceiptID", SqlDbType.Int);
    //                p.Direction = ParameterDirection.Output;
    //                rsda.Update(new DataRow[] { this.receipt });

    //                sdarc.Update(new DataRow[] { this.receipt } );

                    System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter();
                    sda.InsertCommand = Purchases.ReceiptContent.InsertCommand();
                    sda.InsertCommand.Connection = this.cConnection;
                    sda.InsertCommand.Transaction = tran;
                    sda.UpdateCommand = Purchases.ReceiptContent.UpdateCommand();
                    sda.UpdateCommand.Connection = this.cConnection;
                    sda.UpdateCommand.Transaction = tran;
                    sda.Update(this.contents);
                    tran.Commit();
                }
                this.cConnection.Close();
                this.DialogResult = DialogResult.OK;
            }catch( System.Exception ex ){
                MessageBox.Show(ex.Message);
                if( tran != null ) tran.Rollback();
            }finally{
                if (this.cConnection.State == ConnectionState.Open) this.cConnection.Close();
            }
        }

        private void RefreshElements(){
            this.lbxProducts.Size = new Size(this.scContent.SplitterDistance - this.btnAddProduct.Size.Width - 2, this.scContent.Height - 33);
            int y = (this.scContent.Height / 2) - this.btnAddProduct.Size.Height / 2;
            this.btnAddProduct.Location = new Point(this.lbxProducts.Size.Width + 2, y);
            this.lblPositions.Location = new Point(this.lblPositions.Location.X, this.Height - 74);
            this.lblReceiptSum.Location = new Point(this.lblReceiptSum.Location.X, this.Height - 60);

            this.btnNewCategory.Location = new Point( this.lbxProducts.Size.Width - this.btnNewCategory.Size.Width,
                                                      this.btnNewCategory.Location.Y);
            this.cbxCategory.Size = new Size(this.btnNewCategory.Location.X - 6, this.cbxCategory.Size.Height);
            return;
        }
        private void ReceiptForm_Resize(object sender, EventArgs e){
            this.scContent.Size = new Size(this.Width - 32, this.Height - 192);
            this.btnOk.Location = new Point(this.Width - 256, this.Height - 72);
            this.btnCancel.Location = new Point(this.Width - 94, this.Height - 72);
            this.RefreshElements();
        }
        private void scContent_SplitterMoved(object sender, SplitterEventArgs e){
            this.RefreshElements();
            return;
        }
        private void dgvReceiptContent_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e){

            string strRowNumber = (e.RowIndex + 1).ToString();
            // преобразование в номер с лидирующими нулями
            while (strRowNumber.Length < this.dgvReceiptContent.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

            if (this.dgvReceiptContent.RowHeadersWidth < (int)(size.Width + 20)) this.dgvReceiptContent.RowHeadersWidth = (int)(size.Width + 20);

            Brush b = SystemBrushes.ControlText;

            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
//            base.OnRowPostPaint(e);
            return;
        }


        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e){
            if (!this.block){
                System.Data.SqlClient.SqlCommand cmd = null;
                if (this.cbxCategory.SelectedIndex >= 0){
                    cmd = Producer.Commands.Products((int)this.cbxCategory.SelectedValue, -1);
                }else{
                    cmd = Producer.Commands.Products(-1, -1);
                }
                cmd.Connection = this.cConnection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                this.products = new DataTable("Products");
                sda.Fill(this.products);
                this.lbxProducts.DataSource = this.products;
                this.lbxProducts.ValueMember = "ProductID";
                this.lbxProducts.DisplayMember = "ProductName";
            }
            return;
        }

        protected void RecalculateReceipt(){
            this.total_price = 0;
            this.total_discount = 0;
            int i = 0;
            decimal discount_cash = 0;
            for( i = 0; i < this.dgvReceiptContent.Rows.Count-1; i++ ){
                decimal total = (decimal)this.dgvReceiptContent.Rows[i].Cells["Всего"].Value;
                decimal summ = (decimal)this.dgvReceiptContent.Rows[i].Cells["Price"].Value;
                summ = summ * (decimal)this.dgvReceiptContent.Rows[i].Cells["Amount"].Value;
                discount_cash += total - summ;

                total_price += total;
                this.total_discount += (decimal)this.dgvReceiptContent.Rows[i].Cells["Discount"].Value;
            }
            if (i > 0) this.total_discount = this.total_discount / i;
            int num = this.dgvReceiptContent.Rows.Count;
            DataGridViewRow dgvr = this.dgvReceiptContent.Rows[num - 1];
//            dgvr.Cells["ProductID"].ReadOnly = true;
            dgvr.Cells["ProductName"].Value = "Итого";
            dgvr.Cells["Discount"].Value = this.total_discount;
            dgvr.Cells["Price"].Value = discount_cash;
            dgvr.Cells["Всего"].Value = this.total_price;

            this.lblPositions.Text = "Всего позиций: " + i.ToString();
            this.lblReceiptSum.Text = "На сумму: " + this.total_price.ToString("0.00");
        }

        protected void AddProducts(){
            System.Data.DataRow prod = null;
            PositionDetailsForm pdfrm = new PositionDetailsForm(this.cConnection, ref prod);
            if( this.last_buyer >= 0 )
                pdfrm.BuyerId = this.last_buyer;
            if( this.last_receiver >= 0 )
                pdfrm.ReceiverId = this.last_receiver;

            if (this.cbxDiscountCards.SelectedIndex >= 0)
                pdfrm.Discount = this.cards.Rows[this.cbxDiscountCards.SelectedIndex]["DiscountPercent"];
            pdfrm.ProductName = (string)this.products.Rows[this.lbxProducts.SelectedIndices[0]]["ProductName"];
            pdfrm.ProductId = (int)this.products.Rows[this.lbxProducts.SelectedIndices[0]]["ProductID"];
            if( pdfrm.ShowDialog() == DialogResult.OK ){
                int icount = this.lbxProducts.SelectedItems.Count;
                for (int i = 0; i < icount; i++){
                    DataRow nrow = this.contents.NewRow();
                    int k = this.lbxProducts.SelectedIndices[i];
                    nrow["ReceiptID"] = this.receipt["ReceiptID"];
                    nrow["ProductID"] = this.products.Rows[k]["ProductID"];
                    nrow["ProductName"] = this.products.Rows[k]["ProductName"];
                    nrow["Buyer"] = pdfrm.BuyerId;
                    nrow["Receiver"] = pdfrm.ReceiverId;
                    nrow["BuyerFullName"] = pdfrm.BuyerFullName;
                    nrow["ReceiverFullName"] = pdfrm.ReceiverFullName;

                    nrow["Amount"] = pdfrm.Amount;
                    nrow["Price"] = pdfrm.Price;
                    nrow["Discount"] = pdfrm.Discount;
                    nrow["Units"] = pdfrm.Units;

                    this.contents.Rows.Add(nrow);
                    this.last_buyer = (int)pdfrm.BuyerId;
                    this.last_receiver = (int)pdfrm.ReceiverId;
                }
//                if (this.contents.Rows.Count == 1){
//                    this.dgvReceiptContent.Rows.Add();
//                }
                this.RecalculateReceipt();
            }
            return;
        }
        private void lbxProducts_DoubleClick(object sender, EventArgs e){
            this.AddProducts();
            return;
        }

        private void btnAddProduct_Click(object sender, EventArgs e){
            this.AddProducts();
            return;
        }

        private void btnNewCategory_Click(object sender, EventArgs e){
            System.Data.DataRow new_category = this.categories.NewRow();
            EditCategoryForm ecf = new EditCategoryForm(this.cConnection, ref new_category);
            if (ecf.ShowDialog() == DialogResult.OK){
                this.categories.Rows.Add(new_category);
            }
            return;
        }

        private void btnNewVendor_Click(object sender, EventArgs e){
            System.Data.DataRow new_vendor = this.vendors.NewRow();
            VendorForm vfrm = new VendorForm( this.cConnection, ref new_vendor );
            if (vfrm.ShowDialog() == DialogResult.OK){
                this.vendors.Rows.Add( new_vendor );
            }
        }

        private void tsmiAddProduct_Click(object sender, EventArgs e){
            System.Data.DataRow new_product = this.products.NewRow();
            if (!System.Convert.IsDBNull(this.cbxCategory.SelectedValue)) new_product["Category"] = this.cbxCategory.SelectedValue;
//            if (!System.Convert.IsDBNull(this.clbxTypes.SelectedValue) && (this.clbxTypes.SelectedValue != null)) new_product["Type"] = this.clbxTypes.SelectedValue;
            AddProductForm apf = new AddProductForm(this.cConnection, ref new_product);
            if (apf.ShowDialog() == DialogResult.OK){
//                this.AddNewRow(this.lvProducts.Items.Count, new_product);
//                this.lbxProducts
//                string message = "";
                this.products.Rows.Add(new_product);
            }
            return;
        }

        private void cmsProductsMenu_Opening(object sender, CancelEventArgs e)
        {
            if (this.products == null){
                this.tsmiAddProduct.Enabled = false;
                this.tsmiEditProduct.Enabled = false;
            }else{
                this.tsmiAddProduct.Enabled = true;
                this.tsmiEditProduct.Enabled = true;
            }

        }

        private void tsmiChangePosition_Click(object sender, EventArgs e){
            if (this.dgvReceiptContent.SelectedRows.Count == 1){
//                System.Data.DataRow prod = this.dgvReceiptContent.SelectedRows[0];
                System.Data.DataRow prod = ((DataRowView)this.dgvReceiptContent.SelectedRows[0].DataBoundItem).Row;
                PositionDetailsForm pf = new PositionDetailsForm(this.cConnection, ref prod);
                pf.ProductId = -1;
                if (pf.ShowDialog() == DialogResult.OK){
                    prod["Buyer"] = pf.BuyerId;
                    prod["Receiver"] = pf.ReceiverId;
                    prod["BuyerFullName"] = pf.BuyerFullName;
                    prod["ReceiverFullName"] = pf.ReceiverFullName;
                    prod["Amount"] = pf.Amount;
                    prod["Price"] = pf.Price;
                    prod["Discount"] = pf.Discount;
                    prod["Units"] = pf.Units;
                }
            }
            return;
        }

        private void tsmiEditProduct_Click(object sender, EventArgs e){
            if ( (this.lbxProducts.SelectedItem != null) &&
                 !System.Convert.IsDBNull(this.lbxProducts.SelectedValue) ){
                     System.Data.DataRow product = this.products.Rows[this.lbxProducts.SelectedIndex];
                AddProductForm apf = new AddProductForm(this.cConnection, ref product );
                if (apf.ShowDialog() == DialogResult.OK){
                }
            }
        }

        private void btnAddDiscountCard_Click(object sender, EventArgs e){
            System.Data.DataRow new_crd = this.cards.NewRow();
            EditDiscountCardForm edcf = new EditDiscountCardForm(this.cConnection, ref new_crd);
            if (edcf.ShowDialog() == DialogResult.OK){
                this.cards.Rows.Add(new_crd);
//                this.
//                this.AddNewRow(this.lvDiscountCards.Items.Count, new_crd);
            }
            return;
        }

        private void cbxVendorTypes_SelectedIndexChanged(object sender, EventArgs e){
            if ( this.cbxVendorTypes.SelectedItem != null && 
                !System.Convert.IsDBNull(this.cbxVendorTypes.SelectedValue)){
                    System.Data.SqlClient.SqlCommand cmd = Purchases.Vendor.Select((int)this.cbxVendorTypes.SelectedValue);
                cmd.Connection = this.cConnection;

                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                this.vendors = new System.Data.DataTable("Vendors");
                sda.Fill(this.vendors);

                this.cbxVendors.DataSource = this.vendors;
                this.cbxVendors.DisplayMember = "VendorName";
                this.cbxVendors.ValueMember = "VendorID";
            }
        }

        private void cbxVendors_Validating(object sender, CancelEventArgs e){
            
        }

        private void cbxVendors_KeyDown(object sender, KeyEventArgs e){
        }

        private void cbxVendors_TextUpdate(object sender, EventArgs e){

        }

        private void cbxVendors_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if( Char.IsLetterOrDigit(e.KeyChar) ){


            //}else{
            //    e.Handled = true;
            //}
        }

        private void cbxVendors_Validated(object sender, EventArgs e)
        {

        }

        private void cbxVendors_KeyUp(object sender, KeyEventArgs e){

        }

        private void cbxVendors_TextChanged(object sender, EventArgs e){
            string vendor_name = this.cbxVendors.Text;
            try{
                if ( !this.block && !this.cbxVendors.Items.Contains(vendor_name) ){
                    this.cbxVendors.SuspendLayout();
                    System.Data.SqlClient.SqlCommand cmd = Purchases.Vendor.Select(vendor_name);
                    cmd.Connection = this.cConnection;

                    System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    this.vendors = new System.Data.DataTable("Vendors");
                    sda.Fill(this.vendors);

                    this.cbxVendors.DataSource = this.vendors;
                    this.cbxVendors.DisplayMember = "VendorName";
                    this.cbxVendors.ValueMember = "VendorID";

                    this.block = true;
                    this.cbxVendors.SelectedIndex = -1;
                    this.cbxVendors.Text = vendor_name;
                    this.cbxVendors.Select(this.cbxVendors.Text.Length, 0);
                    this.block = false;

                    this.cbxVendors.DroppedDown = true;
                    this.cbxVendors.ResumeLayout(false);
                }
            }catch(System.Exception ex){
                MessageBox.Show(ex.Message);

            }
            return;
        }

        private void tbxSearchProduct_KeyUp(object sender, KeyEventArgs e){
            try{
                if (this.tbxSearchProduct.Text.Length > 0){
                    System.Data.SqlClient.SqlCommand command = Producer.Product.Select(this.tbxSearchProduct.Text);
                    command.Connection = this.cConnection;
                    System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(command);
                    this.products = new DataTable("Products");
                    sda.Fill(this.products);
                    this.lbxProducts.DataSource = this.products;
                    this.lbxProducts.ValueMember = "ProductID";
                    this.lbxProducts.DisplayMember = "ProductName";
                }
            }catch(System.Exception ex ){
                MessageBox.Show(ex.Message);
            }
            return;
        }
//            if( e.ColumnIndex == 7 ){
//                decimal vl = (decimal)e.Value;
//                vl = Math.Round(vl, 2);
                
////                e.Handled
        //            }
    }
}