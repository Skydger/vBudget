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
        private System.Resources.ResourceManager manager;
        private int last_buyer;
        private int last_receiver;

        public ReceiptForm(System.Data.SqlClient.SqlConnection inConnection, ref System.Data.DataRow inReceipt, bool created ){
            InitializeComponent();
            this.manager = new System.Resources.ResourceManager("vBudgetForm.ReceiptFormResource", System.Reflection.Assembly.GetExecutingAssembly());

            this.total_price = 0;
            this.total_discount = 0;
            this.cConnection = inConnection;
            this.receipt = inReceipt;
            this.isNew = created;
            this.last_buyer = -1;
            this.last_receiver = -1;
        }
        private void LoadFromResources()
        {
            this.Text = this.manager.GetString("Form.Title");
            this.lblVendorType.Text = this.manager.GetString("Vendor.Type");
            this.lblVendor.Text = this.manager.GetString("Vendor.Label");
            this.lblComment.Text = this.manager.GetString("Receipt.Comment");
            this.lblReceiptDate.Text = this.manager.GetString("Receipt.Date");
            this.lblReceiptNumber.Text = this.manager.GetString("Receipt.Number");
            this.lblDiscountCard.Text = this.manager.GetString("Receipt.DiscountCard");
            this.lblSearch.Text = this.manager.GetString("Form.SearchLabel");
            this.lblPositions.Text = string.Format(this.manager.GetString("Receipt.Positions"), 0);
            this.lblReceiptSum.Text = string.Format(this.manager.GetString("Receipt.SubtotalPrice"), 0.0);
            this.btnOk.Text = this.manager.GetString("Form.Accept");
            this.btnCancel.Text = this.manager.GetString("Form.Cancel");
            return;
        }


        private void ReceiptForm_Load(object sender, EventArgs e){
            this.block = true;
            this.LoadFromResources();

            System.Data.SqlClient.SqlCommand cmd = Purchases.Vendor.Select(-1);
            cmd.Connection = this.cConnection;

            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.vendors = new System.Data.DataTable("Vendors");
            sda.Fill(this.vendors);

            this.cbxVendors.DataSource = this.vendors;
            this.cbxVendors.DisplayMember = "VendorName";
            //this.cbxVendors.DisplayMember = "VendorNameAddress";
            this.cbxVendors.ValueMember = "VendorID";

            System.Data.SqlClient.SqlCommand prdccmd = Producer.Commands.ProductCategories();
            prdccmd.Connection = this.cConnection;
            sda = new System.Data.SqlClient.SqlDataAdapter(prdccmd);
            this.categories = new System.Data.DataTable("Categories");
            sda.Fill(this.categories);
            string uncat = this.manager.GetString("Form.Uncategorized");
            this.categories.Rows.Add(new object[] { -1, uncat });

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
            if (this.isNew)
            {
                this.cConnection.Open();
                System.Data.SqlClient.SqlCommand idcmd = new System.Data.SqlClient.SqlCommand("SELECT NEWID() AS MaxID FROM Purchases.Receipts", this.cConnection);
                Guid rec_id = (Guid)idcmd.ExecuteScalar();
                this.receipt["ReceiptID"] = rec_id;
                this.cConnection.Close();
            }
            System.Data.SqlClient.SqlCommand cmd = Purchases.Commands.ReceiptContents((Guid)this.receipt["ReceiptID"]);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.contents = new System.Data.DataTable("ReceiptContents");

            sda.Fill(this.contents);

            string stn = this.manager.GetString("Form.Subtotal");

            DataColumn ttlcol = new DataColumn(stn, typeof(Decimal), "Amount * Price * (1.0 - Discount)");
            this.contents.Columns.Add(ttlcol);
            string colname = "ContentID";
            
            this.contents.Columns[colname].ReadOnly = true;

            this.dgvReceiptContent.DataSource = this.contents;

            string column_name = "";
            this.dgvReceiptContent.Columns[0].ReadOnly = true;
            this.dgvReceiptContent.Columns[0].Visible = false;
            this.dgvReceiptContent.Columns[1].ReadOnly = true;
            this.dgvReceiptContent.Columns[1].Visible = false;
            //this.dgvReceiptContent.Columns[2].Visible = false;
            this.dgvReceiptContent.Columns[2].DisplayIndex = 0;

            column_name = "ProductID";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
//            this.dgvReceiptContent.Columns["ProductID"].Frozen = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = this.manager.GetString("ReceiptContent.ProductID");
            this.dgvReceiptContent.Columns[column_name].Visible = false;
//            this.dgvReceiptContent.Columns[column_name].Frozen = true;
            column_name = "ProductName";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].Frozen = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = this.manager.GetString("ReceiptContent.Name");
            this.dgvReceiptContent.Columns[column_name].Width = 250;
            column_name = "Amount";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = this.manager.GetString("ReceiptContent.Amount");
            this.dgvReceiptContent.Columns[column_name].Width = 60;
            column_name = "Price";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = this.manager.GetString("ReceiptContent.Price");
            this.dgvReceiptContent.Columns[column_name].Width = 60;
            column_name = "Discount";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = this.manager.GetString("ReceiptContent.Discount");
            this.dgvReceiptContent.Columns[column_name].Width = 60;
            column_name = "Units";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = this.manager.GetString("ReceiptContent.Units");
            this.dgvReceiptContent.Columns[column_name].Width = 60;

            column_name = "BuyerFullName";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = this.manager.GetString("ReceiptContent.Buyer");
            this.dgvReceiptContent.Columns[column_name].Width = 100;
            column_name = "ReceiverFullName";
            this.dgvReceiptContent.Columns[column_name].ReadOnly = true;
            this.dgvReceiptContent.Columns[column_name].HeaderText = this.manager.GetString("ReceiptContent.Receiver");
            this.dgvReceiptContent.Columns[column_name].Width = 100;

            this.dgvReceiptContent.Columns["Buyer"].ReadOnly = true;
            this.dgvReceiptContent.Columns["Buyer"].Visible = false;
            this.dgvReceiptContent.Columns["Receiver"].ReadOnly = true;
            this.dgvReceiptContent.Columns["Receiver"].Visible = false;

            this.Text = this.manager.GetString("Form.Title") + " #" + this.receipt["ReceiptID"].ToString();
            if (!System.Convert.IsDBNull(this.receipt["DiscountCard"])){
                Guid dc = (Guid)this.receipt["DiscountCard"];
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
            // Recalculate receipt
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
                    System.Data.SqlClient.SqlCommand rcmd = new System.Data.SqlClient.SqlCommand();
                    if (this.isNew){
                        rcmd = Purchases.Receipt.InsertCommand(this.receipt);
                    }else{
                        rcmd = Purchases.Receipt.UpdateCommand(this.receipt);
                    }
                    rcmd.Connection = this.cConnection;
                    rcmd.Transaction = tran;
                    rcmd.ExecuteNonQuery();

                    System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter();
                    sda.InsertCommand = Purchases.ReceiptContent.InsertCommand();
                    sda.InsertCommand.Connection = this.cConnection;
                    sda.InsertCommand.Transaction = tran;
                    sda.UpdateCommand = Purchases.ReceiptContent.UpdateCommand();
                    sda.UpdateCommand.Connection = this.cConnection;
                    sda.UpdateCommand.Transaction = tran;
                    sda.Update(this.contents);
                    //TODO Update discount card balance
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
            this.lbxProducts.Size = new Size(this.scContent.SplitterDistance - this.btnAddProduct.Size.Width - 2, this.scContent.Height - 48);
            int y = (this.scContent.Height / 2) - this.btnAddProduct.Size.Height / 2;
            this.btnAddProduct.Location = new Point(this.lbxProducts.Size.Width + 2, y);
            this.lblPositions.Location = new Point(this.lblPositions.Location.X, this.Height - 74);
            this.lblReceiptSum.Location = new Point(this.lblReceiptSum.Location.X, this.Height - 60);

            this.btnNewCategory.Location = new Point( this.lbxProducts.Size.Width - this.btnNewCategory.Size.Width,
                                                      this.btnNewCategory.Location.Y);
            this.cbxCategory.Size = new Size(this.btnNewCategory.Location.X - 6, this.cbxCategory.Size.Height);

            this.btnUp.Location = new Point(this.lbxProducts.Size.Width + 2, this.lbxProducts.Location.Y);
            this.btnDown.Location = new Point(this.lbxProducts.Size.Width + 2, this.lbxProducts.Location.Y + 29);
            return;
        }
        private void ReceiptForm_Resize(object sender, EventArgs e){
            this.scContent.Size = new Size(this.Width - 32, this.Height - 192 );
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
            // number to string with leading nulls
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
                    cmd = Producer.Commands.Products((int)this.cbxCategory.SelectedValue, System.Guid.Empty);
                }else{
                    cmd = Producer.Commands.Products(-1, System.Guid.Empty);
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
            this.last_position = 1;
            this.total_price = 0;
            this.total_discount = 0;
            int i = 0;
            decimal discount_cash = 0;
            string stn = this.manager.GetString("Form.Subtotal");

            for( i = 0; i < this.dgvReceiptContent.Rows.Count-1; i++ ){
                decimal total = (decimal)this.dgvReceiptContent.Rows[i].Cells[stn].Value;
                decimal summ = (decimal)this.dgvReceiptContent.Rows[i].Cells["Price"].Value;
                summ = summ * (decimal)this.dgvReceiptContent.Rows[i].Cells["Amount"].Value;
                discount_cash += total - summ;

                total_price += total;
                this.total_discount += (decimal)this.dgvReceiptContent.Rows[i].Cells["Discount"].Value;
                this.last_position = (int)this.dgvReceiptContent.Rows[i].Cells["Position"].Value;
            }
            if (i > 0) this.total_discount = this.total_discount / i;
            int num = this.dgvReceiptContent.Rows.Count;
            DataGridViewRow dgvr = this.dgvReceiptContent.Rows[num - 1];
//            dgvr.Cells["ProductID"].ReadOnly = true;
            dgvr.Cells["ProductName"].Value = stn;
            dgvr.Cells["Discount"].Value = this.total_discount;
            dgvr.Cells["Price"].Value = discount_cash;
            dgvr.Cells[stn].Value = this.total_price;

            this.lblPositions.Text = string.Format(this.manager.GetString("Receipt.Positions"), i);
            this.lblReceiptSum.Text = string.Format(this.manager.GetString("Receipt.SubtotalPrice"), this.total_price);
            return;
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
            pdfrm.ProductId = (Guid)this.products.Rows[this.lbxProducts.SelectedIndices[0]]["ProductID"];
            if( pdfrm.ShowDialog() == DialogResult.OK ){
                int icount = this.lbxProducts.SelectedItems.Count;
                for (int i = 0; i < icount; i++){
                    DataRow nrow = this.contents.NewRow();
                    int k = this.lbxProducts.SelectedIndices[i];

                    this.cConnection.Open();
                    System.Data.SqlClient.SqlCommand idcmd = new System.Data.SqlClient.SqlCommand("SELECT NEWID() AS ContentID FROM Purchases.ReceiptContents", this.cConnection);
                    Guid rec_id = (Guid)idcmd.ExecuteScalar();
                    nrow["ContentID"] = rec_id;
                    this.cConnection.Close();
                    nrow["ReceiptID"] = this.receipt["ReceiptID"];
                    nrow["Position"] = this.contents.Rows.Count + 1;
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
            new_product["ProductID"] = Guid.Empty;
            if (!System.Convert.IsDBNull(this.cbxCategory.SelectedValue)) new_product["Category"] = this.cbxCategory.SelectedValue;
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
                System.Data.DataRow prod = ((DataRowView)this.dgvReceiptContent.SelectedRows[0].DataBoundItem).Row;
                PositionDetailsForm pf = new PositionDetailsForm(this.cConnection, ref prod);
                pf.ProductName = (string)prod["ProductName"];
                //pdfrm.ProductId = (Guid)this.products.Rows[this.lbxProducts.SelectedIndices[0]]["ProductID"]
                pf.ProductId = Guid.Empty;
                if (pf.ShowDialog() == DialogResult.OK){
                    prod["Buyer"] = pf.BuyerId;
                    prod["Receiver"] = pf.ReceiverId;
                    prod["BuyerFullName"] = pf.BuyerFullName;
                    prod["ReceiverFullName"] = pf.ReceiverFullName;
                    prod["Amount"] = pf.Amount;
                    prod["Price"] = pf.Price;
                    prod["Discount"] = pf.Discount;
                    prod["Units"] = pf.Units;

                    this.RecalculateReceipt();
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
                //this.cbxVendors.DisplayMember = "VendorNameAddress";
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
            string vendor_name = this.cbxVendors.Text;
            try{
                if ((e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && //!e.Shift && !e.Alt && !e.Control &&
                    (e.KeyCode != Keys.Home) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.ShiftKey) &&
                    (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.Right)
                    )
                {
                    if (!this.block && !this.cbxVendors.Items.Contains(vendor_name))
                    {
                        this.cbxVendors.SuspendLayout();
                        System.Data.SqlClient.SqlCommand cmd = Purchases.Vendor.Select(vendor_name);
                        cmd.Connection = this.cConnection;

                        System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                        this.vendors = new System.Data.DataTable("Vendors");
                        sda.Fill(this.vendors);

                        this.cbxVendors.DataSource = this.vendors;
                        this.cbxVendors.DisplayMember = "VendorName";
                        //this.cbxVendors.DisplayMember = "VendorNameAddress";
                        this.cbxVendors.ValueMember = "VendorID";

                        this.block = true;
                        this.cbxVendors.SelectedIndex = -1;
                        this.cbxVendors.Text = vendor_name;
                        this.cbxVendors.Select(this.cbxVendors.Text.Length, 0);
                        this.block = false;

                        this.cbxVendors.DroppedDown = true;
                        this.cbxVendors.ResumeLayout(false);
                    }
                //}else if( e.Shift ){ //&& !e.Alt && !e.Control
                    e.Handled = true;
                }else{
                    e.Handled = true;
                }
            }catch (System.Exception ex){
                MessageBox.Show(ex.Message);
            }
            return;
        }

        private void cbxVendors_TextChanged(object sender, EventArgs e){
            
            return;
        }

        private void tbxSearchProduct_KeyUp(object sender, KeyEventArgs e){
            try{
                if ( ( e.KeyCode != Keys.Up ) && ( e.KeyCode != Keys.Down ) ){
                    if (this.tbxSearchProduct.Text.Length > 0){
                        List<Producer.Product.OrderColumn> cols = new List<Producer.Product.OrderColumn>();
                        cols.Add(Producer.Product.OrderColumn.ProductName);
                        System.Data.SqlClient.SqlCommand command = Producer.Product.Select(this.tbxSearchProduct.Text, cols);
                        command.Connection = this.cConnection;
                        System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(command);
                        this.products = new DataTable("Products");
                        sda.Fill(this.products);
                        this.lbxProducts.DataSource = this.products;
                        this.lbxProducts.ValueMember = "ProductID";
                        this.lbxProducts.DisplayMember = "ProductName";
                    }
                }
            }catch(System.Exception ex ){
                MessageBox.Show(ex.Message);
            }
            return;
        }

        private void tsmiChangeProduct_Click(object sender, EventArgs e){
            if (this.dgvReceiptContent.SelectedRows.Count == 1){
                System.Data.DataRow position = ((DataRowView)this.dgvReceiptContent.SelectedRows[0].DataBoundItem).Row;
                if ((position != null) && !System.Convert.IsDBNull(position["ProductID"]) ){
                    ChangePositionForm frm = new ChangePositionForm(this.cConnection, position["ProductID"] );
                    if (frm.ShowDialog() == DialogResult.OK){
                        position["ProductID"] = frm.NewProductID;
                    }
                }
            }
            return;
        }

        private void SearchPositions(bool all)
        {
            List<Guid> positions = new List<Guid>();
            if (all && this.dgvReceiptContent.SelectedRows.Count == 1)
            {
                System.Data.DataRow position = ((DataRowView)this.dgvReceiptContent.SelectedRows[0].DataBoundItem).Row;
                if ((position != null) && !System.Convert.IsDBNull(position["ProductID"]))
                {
                    positions.Add((Guid)position["ProductID"]);
                }
            }
            else
            {
                foreach (System.Data.DataRow position in ((DataTable)this.dgvReceiptContent.DataSource).Rows)
                {
                    positions.Add((Guid)position["ProductID"]);
                }
            }
            if (positions.Count > 0)
            {
                List<Producer.Product.OrderColumn> cols = new List<Producer.Product.OrderColumn>();
                cols.Add(Producer.Product.OrderColumn.ProductName);
                System.Data.SqlClient.SqlCommand command = Producer.Product.Select(-1, null, positions.ToArray(), cols);
                command.Connection = this.cConnection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(command);
                this.products = new DataTable("Products");
                sda.Fill(this.products);
                this.lbxProducts.DataSource = this.products;
                this.lbxProducts.ValueMember = "ProductID";
                this.lbxProducts.DisplayMember = "ProductName";
            }
            return;            
        }

        private void tsmiSearchSelectedPosition_Click(object sender, EventArgs e)
        {
            this.SearchPositions(false);
            return;
        }

        private void tsmiSearchAllPositions_Click(object sender, EventArgs e)
        {
            this.SearchPositions(true);
            return;
        }

        private void tsmiDeleteProduct_Click(object sender, EventArgs e)
        {
            if ((this.lbxProducts.SelectedItem != null) &&
                 !System.Convert.IsDBNull(this.lbxProducts.SelectedValue))
            {
                System.Data.DataRow product = this.products.Rows[this.lbxProducts.SelectedIndex];
                DeleteProductForm frm = new DeleteProductForm(this.cConnection, product);
                DialogResult dr = frm.ShowDialog();
                string message = "";
                string caption = "";
                MessageBoxIcon ico = MessageBoxIcon.Information;
                if ( dr == DialogResult.OK)
                {
                    message = this.manager.GetString("Product.Deleted");
                    caption = this.manager.GetString("Product.Information");
                    ico = MessageBoxIcon.Information;
                }
                else if (dr == DialogResult.Ignore)
                {
                    message = this.manager.GetString("Product.Deleted");
                    caption = this.manager.GetString("Product.Information");
                    ico = MessageBoxIcon.Information;
                }
                else if (dr == DialogResult.Cancel)
                {
                    message = this.manager.GetString("Product.Canceled");
                    caption = this.manager.GetString("Product.Information");
                    ico = MessageBoxIcon.Information;
                }
                else if (dr == DialogResult.Abort)
                {
                    message = this.manager.GetString("Product.DeletionError");
                    caption = this.manager.GetString("Product.Error");
                    ico = MessageBoxIcon.Error;
                }
                MessageBox.Show(message, caption, MessageBoxButtons.OK, ico);
            }
        }

        private void tsmiNewBySelected_Click(object sender, EventArgs e)
        {
            if ((this.lbxProducts.SelectedItem != null) &&
                 !System.Convert.IsDBNull(this.lbxProducts.SelectedValue))
            {
                System.Data.DataRow product = this.products.Rows[this.lbxProducts.SelectedIndex];

                System.Data.DataRow new_product = this.products.NewRow();
                new_product["ProductName"] = product["ProductName"];
                new_product["Category"] = product["Category"];
                new_product["Type"] = product["Type"];
                new_product["Maker"] = product["Maker"];
                new_product["Barcode"] = product["Barcode"];
                new_product["ProductID"] = Guid.Empty;

                //if (!System.Convert.IsDBNull(this.cbxCategory.SelectedValue)) new_product["Category"] = this.cbxCategory.SelectedValue;

                AddProductForm apf = new AddProductForm(this.cConnection, ref new_product);
                if (apf.ShowDialog() == DialogResult.OK)
                {
                    this.products.Rows.Add(new_product);
                }

            }

        }
        protected void CheckReceiptExistance()
        {
            if (this.isNew && !this.block)
            {
                DateTime dt = this.dtpPeceiptDate.Value;
                string num = this.tbxReceiptNumber.Text;
                int ven_id = -1;
                if ((this.cbxVendors.SelectedIndex >= 0) &&
                     !System.Convert.IsDBNull(this.cbxVendors.SelectedValue))
                {

                    ven_id = (int)this.cbxVendors.SelectedValue;
                }
                bool ok = false;
                string error = "";
                System.Data.SqlClient.SqlCommand cmd = Purchases.Receipt.Exists(dt, num, ven_id, -1, out ok, out error);
                if (ok)
                {
                    cmd.Connection = this.cConnection;
                    System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    System.Data.DataTable receipts = new System.Data.DataTable("Receipts");
                    sda.Fill(receipts);
                    if (receipts != null )                        
                    {
                        string msg = "";
                        if (receipts.Rows.Count == 1)
                        {
                            string vnd = "<не указан>";
                            if (!System.Convert.IsDBNull(receipts.Rows[0]["VendorName"]))
                            {
                                vnd = (string)receipts.Rows[0]["VendorName"];
                            }
                            msg = string.Format("Такой чек уже присутствует в базе данных под идентификатором {0}\n"+
                                                "{1}\nСумма: {2}, оплачен {3}.\nПозиций: {4} ",
                                                receipts.Rows[0]["ReceiptID"], vnd,
                                                receipts.Rows[0]["Price"],
                                                receipts.Rows[0]["Payed"], receipts.Rows[0]["Amount"]);
                            MessageBox.Show(msg);
                        }
                        else if (receipts.Rows.Count > 1)
                        {
                            msg = string.Format("Похожие чеки уже присутствуют в базе данных (всего: {0})!", receipts.Rows.Count);
                            MessageBox.Show(msg);
                        }
                    }

                }
                else
                {
                    MessageBox.Show(error, "Ошибка получения команды для проверки существования чека");
                }
            }
            return;
        }

        private void dtpPeceiptDate_ValueChanged(object sender, EventArgs e)
        {
            this.CheckReceiptExistance();
            return;
        }

        private void tbxReceiptNumber_TextChanged(object sender, EventArgs e)
        {
            this.CheckReceiptExistance();
            return;
        }

        private void cbxVendors_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CheckReceiptExistance();
            return;
        }

        private void dgvReceiptContent_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.last_position = 1;
            foreach (System.Data.DataRow row in this.contents.Rows)
            {
                row["Position"] = this.last_position++;
            }
        }

        private void ExchangeRows(int old_position, int new_position)
        {
            DataTable cloned = this.contents.Clone();

            //DataTable cloned = new DataTable("ReceiptContents");
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //this.contents.WriteXmlSchema(ms,true);
            //ms.Position = 0;
            //cloned.ReadXmlSchema(ms);
            //ms.Close();

            for (int i = 0; i < this.contents.Rows.Count; i++)
            {
                System.Data.DataRow o_row = this.contents.Rows[i];
                System.Data.DataRow n_row = cloned.NewRow();
                if (i != old_position && i != new_position)
                {
                }
                else if (i == old_position)
                {
                    o_row = this.contents.Rows[new_position];
                    //o_row["Position"] = old_position + 1;
                }
                else if (i == new_position)
                {
                    o_row = this.contents.Rows[old_position];
                    //o_row["Position"] = new_position + 1;
                }

                for (int j = 0; j < this.contents.Columns.Count - 1; j++)
                {
                    n_row[j] = o_row[j];
                    if( i == old_position)
                        n_row["Position"] = old_position + 1;
                    else if (i == new_position)
                        n_row["Position"] = new_position + 1;
                }
                cloned.Rows.Add(n_row);
            }
            //for (int i = 0; i < this.contents.Rows.Count; i++)
            //{
            //    System.Data.DataRow o_row = this.contents.Rows[i];
            //    for (int j = 0; j < cloned.Rows.Count; j++)
            //    {
            //        System.Data.DataRow n_row = cloned.Rows[j];
            //        if (n_row["ContentID"] == o_row["ContentID"])
            //        {
            //            o_row["Position"] = n_row["Position"];
            //            break;
            //        }
            //    }
            //}

            //cloned.Merge(this.contents, true);
            //cloned.AcceptChanges();
            this.contents.Merge(cloned, false);
            //this.contents.
            
            //this.contents = null;
            //this.contents = cloned;
            //this.dgvReceiptContent.DataSource = cloned;
            this.dgvReceiptContent.DataSource = this.contents;
            //this.dgvReceiptContent.Sort(this.dgvReceiptContent.Columns["Position"], ListSortDirection.Ascending);

            this.dgvReceiptContent.ClearSelection();
            this.dgvReceiptContent.Rows[new_position].Selected = true;
            this.dgvReceiptContent.CurrentCell = this.dgvReceiptContent.Rows[new_position].Cells[4];

            return;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            //DataTable cloned = this.contents.Clone();

            
            if (this.dgvReceiptContent.SelectedRows.Count == 1)
            {
                int cur_index = this.dgvReceiptContent.SelectedRows[0].Index;
                this.ExchangeRows(cur_index, cur_index - 1);

                //System.Data.DataRow prod = ((DataRowView)this.dgvReceiptContent.SelectedRows[0].DataBoundItem).Row;
                //int cur_index = this.dgvReceiptContent.SelectedRows[0].Index;
                //for (int i = 0; i <= cur_index; i++)
                //{
                //    if (i == cur_index - 1)
                //    {
                //        this.contents.Rows[cur_index]["Position"] = cur_index;
                //    }
                //    else if (i == cur_index)
                //    {
                //        this.contents.Rows[cur_index-1]["Position"] = cur_index+1;
                //    }
                //}
                //this.dgvReceiptContent.Sort(this.dgvReceiptContent.Columns["Position"], ListSortDirection.Ascending);
/*

                DataRow dr = (DataRow)this.contents.Rows[cur_index];
                int prv_index = cur_index - 1;
                int cur_ind = (int)dr["Position"];

                if (prv_index >= 0)
                {
                    int prv_ind = cur_ind - 1;


                    
                    this.contents.Rows[prv_index]["Position"] = cur_index + 1;
                    this.contents.Rows[cur_index]["Position"] = prv_index + 1;
                    
                    this.dgvReceiptContent.Sort(this.dgvReceiptContent.Columns["Position"], ListSortDirection.Ascending);
                    this.dgvReceiptContent.Rows[prv_index].Selected = true;
                    this.contents.AcceptChanges();
                    //this.dgvReceiptContent.Rows[cur_index - 1].Selected = false;
                    //this.dgvReceiptContent.Rows[cur_index].Selected = false;
                }
 */ 
            }

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.dgvReceiptContent.SelectedRows.Count == 1)
            {

                int cur_index = this.dgvReceiptContent.SelectedRows[0].Index;
                this.ExchangeRows(cur_index, cur_index + 1);

                //System.Data.DataRow prod = ((DataRowView)this.dgvReceiptContent.SelectedRows[0].DataBoundItem).Row;
                //int cur_ind = this.dgvReceiptContent.SelectedRows[0].Index;
                //if (cur_ind < this.dgvReceiptContent.Rows.Count)
                //{
                //    int prv_ind = cur_ind + 1;
                //    this.contents.Rows[cur_ind]["Position"] = prv_ind + 1;
                //    this.contents.Rows[prv_ind]["Position"] = cur_ind + 1;
                //    this.contents.AcceptChanges();
                //    //this.dgvReceiptContent.Sort(this.dgvReceiptContent.Columns["Position"], ListSortDirection.Ascending);
                //}
            }
        }

        private void dgvReceiptContent_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvReceiptContent.SelectedRows.Count == 1)
            {
                this.btnUp.Enabled = true;
                this.btnDown.Enabled = true;
                if (this.dgvReceiptContent.SelectedRows[0].Index == 0)
                {
                    this.btnUp.Enabled = false;
                }
                // Excluding last data row and subtotal row
                else if ( (this.dgvReceiptContent.SelectedRows[0].Index == this.dgvReceiptContent.Rows.Count - 2) ||
                          (this.dgvReceiptContent.SelectedRows[0].Index == this.dgvReceiptContent.Rows.Count - 1) )
                {
                    this.btnDown.Enabled = false;
                }
            }
            else
            {
                this.btnUp.Enabled = false;
                this.btnDown.Enabled = false;
            }
        }


    }
}