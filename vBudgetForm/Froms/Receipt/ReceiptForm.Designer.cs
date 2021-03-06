namespace vBudgetForm
{
    partial class ReceiptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection = null;
        private System.Data.DataRow receipt = null;
        private System.Data.DataTable categories = null;
        private System.Data.DataTable products = null;
        private System.Data.DataTable contents = null;
        private System.Data.DataTable companies = null;
        private System.Data.DataTable vendors = null;
        private System.Data.DataTable cards = null;
        private int last_position;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptForm));
            this.cbxVendorTypes = new System.Windows.Forms.ComboBox();
            this.lblVendorType = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.cbxVendors = new System.Windows.Forms.ComboBox();
            this.btnNewVendor = new System.Windows.Forms.Button();
            this.lblReceiptDate = new System.Windows.Forms.Label();
            this.dtpPeceiptDate = new System.Windows.Forms.DateTimePicker();
            this.tbxReceiptNumber = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbxSearchProduct = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnNewCategory = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lbxProducts = new System.Windows.Forms.ListBox();
            this.cmsProductsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewBySelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.dgvReceiptContent = new System.Windows.Forms.DataGridView();
            this.cmsPositionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiChangePosition = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeparatorI = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSearchSelectedPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearchAllPositions = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblComment = new System.Windows.Forms.Label();
            this.tbxComment = new System.Windows.Forms.TextBox();
            this.lblReceiptNumber = new System.Windows.Forms.Label();
            this.lblDiscountCard = new System.Windows.Forms.Label();
            this.cbxDiscountCards = new System.Windows.Forms.ComboBox();
            this.lblPositions = new System.Windows.Forms.Label();
            this.btnAddDiscountCard = new System.Windows.Forms.Button();
            this.llblReceiptSum = new System.Windows.Forms.LinkLabel();
            this.btnNewCompany = new System.Windows.Forms.Button();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cbxCompanies = new System.Windows.Forms.ComboBox();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.cmsProductsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptContent)).BeginInit();
            this.cmsPositionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxVendorTypes
            // 
            this.cbxVendorTypes.FormattingEnabled = true;
            this.cbxVendorTypes.Location = new System.Drawing.Point(144, 6);
            this.cbxVendorTypes.Name = "cbxVendorTypes";
            this.cbxVendorTypes.Size = new System.Drawing.Size(147, 21);
            this.cbxVendorTypes.TabIndex = 1;
            this.cbxVendorTypes.SelectedIndexChanged += new System.EventHandler(this.cbxVendorTypes_SelectedIndexChanged);
            // 
            // lblVendorType
            // 
            this.lblVendorType.AutoSize = true;
            this.lblVendorType.Location = new System.Drawing.Point(12, 9);
            this.lblVendorType.Name = "lblVendorType";
            this.lblVendorType.Size = new System.Drawing.Size(126, 13);
            this.lblVendorType.TabIndex = 1;
            this.lblVendorType.Text = "����� ������� � �����:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(339, 36);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(60, 13);
            this.lblVendor.TabIndex = 3;
            this.lblVendor.Text = "��������:";
            // 
            // cbxVendors
            // 
            this.cbxVendors.FormattingEnabled = true;
            this.cbxVendors.Location = new System.Drawing.Point(418, 33);
            this.cbxVendors.Name = "cbxVendors";
            this.cbxVendors.Size = new System.Drawing.Size(360, 21);
            this.cbxVendors.TabIndex = 16;
            this.cbxVendors.SelectedIndexChanged += new System.EventHandler(this.cbxVendors_SelectedIndexChanged);
            this.cbxVendors.TextChanged += new System.EventHandler(this.cbxVendors_TextChanged);
            this.cbxVendors.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxVendors_KeyUp);
            // 
            // btnNewVendor
            // 
            this.btnNewVendor.Location = new System.Drawing.Point(784, 32);
            this.btnNewVendor.Name = "btnNewVendor";
            this.btnNewVendor.Size = new System.Drawing.Size(29, 23);
            this.btnNewVendor.TabIndex = 4;
            this.btnNewVendor.Text = "...";
            this.btnNewVendor.UseVisualStyleBackColor = true;
            this.btnNewVendor.Click += new System.EventHandler(this.btnNewVendor_Click);
            // 
            // lblReceiptDate
            // 
            this.lblReceiptDate.AutoSize = true;
            this.lblReceiptDate.Location = new System.Drawing.Point(12, 41);
            this.lblReceiptDate.Name = "lblReceiptDate";
            this.lblReceiptDate.Size = new System.Drawing.Size(36, 13);
            this.lblReceiptDate.TabIndex = 5;
            this.lblReceiptDate.Text = "����:";
            // 
            // dtpPeceiptDate
            // 
            this.dtpPeceiptDate.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpPeceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeceiptDate.Location = new System.Drawing.Point(144, 35);
            this.dtpPeceiptDate.Name = "dtpPeceiptDate";
            this.dtpPeceiptDate.Size = new System.Drawing.Size(147, 20);
            this.dtpPeceiptDate.TabIndex = 6;
            this.dtpPeceiptDate.ValueChanged += new System.EventHandler(this.dtpPeceiptDate_ValueChanged);
            // 
            // tbxReceiptNumber
            // 
            this.tbxReceiptNumber.Location = new System.Drawing.Point(144, 60);
            this.tbxReceiptNumber.Name = "tbxReceiptNumber";
            this.tbxReceiptNumber.Size = new System.Drawing.Size(176, 20);
            this.tbxReceiptNumber.TabIndex = 8;
            this.tbxReceiptNumber.TextChanged += new System.EventHandler(this.tbxReceiptNumber_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(526, 404);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "���������";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // scContent
            // 
            this.scContent.Location = new System.Drawing.Point(12, 114);
            this.scContent.Name = "scContent";
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.lblSearch);
            this.scContent.Panel1.Controls.Add(this.tbxSearchProduct);
            this.scContent.Panel1.Controls.Add(this.btnDown);
            this.scContent.Panel1.Controls.Add(this.btnUp);
            this.scContent.Panel1.Controls.Add(this.btnNewCategory);
            this.scContent.Panel1.Controls.Add(this.btnAddProduct);
            this.scContent.Panel1.Controls.Add(this.lbxProducts);
            this.scContent.Panel1.Controls.Add(this.cbxCategory);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.dgvReceiptContent);
            this.scContent.Size = new System.Drawing.Size(800, 284);
            this.scContent.SplitterDistance = 266;
            this.scContent.TabIndex = 10;
            this.scContent.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scContent_SplitterMoved);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 33);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "�����:";
            // 
            // tbxSearchProduct
            // 
            this.tbxSearchProduct.Location = new System.Drawing.Point(47, 30);
            this.tbxSearchProduct.Name = "tbxSearchProduct";
            this.tbxSearchProduct.Size = new System.Drawing.Size(198, 20);
            this.tbxSearchProduct.TabIndex = 5;
            this.tbxSearchProduct.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxSearchProduct_KeyUp);
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(246, 85);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(18, 23);
            this.btnDown.TabIndex = 21;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(246, 56);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(18, 23);
            this.btnUp.TabIndex = 20;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnNewCategory
            // 
            this.btnNewCategory.Location = new System.Drawing.Point(225, 3);
            this.btnNewCategory.Name = "btnNewCategory";
            this.btnNewCategory.Size = new System.Drawing.Size(23, 23);
            this.btnNewCategory.TabIndex = 4;
            this.btnNewCategory.Text = "...";
            this.btnNewCategory.UseVisualStyleBackColor = true;
            this.btnNewCategory.Click += new System.EventHandler(this.btnNewCategory_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(246, 127);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(18, 78);
            this.btnAddProduct.TabIndex = 3;
            this.btnAddProduct.Text = ">";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // lbxProducts
            // 
            this.lbxProducts.ContextMenuStrip = this.cmsProductsMenu;
            this.lbxProducts.FormattingEnabled = true;
            this.lbxProducts.Location = new System.Drawing.Point(0, 56);
            this.lbxProducts.Name = "lbxProducts";
            this.lbxProducts.Size = new System.Drawing.Size(245, 225);
            this.lbxProducts.TabIndex = 2;
            this.lbxProducts.DoubleClick += new System.EventHandler(this.lbxProducts_DoubleClick);
            // 
            // cmsProductsMenu
            // 
            this.cmsProductsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddProduct,
            this.tsmiNewBySelected,
            this.tsmiEditProduct,
            this.tsmiDeleteProduct});
            this.cmsProductsMenu.Name = "cmsProductsMenu";
            this.cmsProductsMenu.Size = new System.Drawing.Size(242, 92);
            this.cmsProductsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsProductsMenu_Opening);
            // 
            // tsmiAddProduct
            // 
            this.tsmiAddProduct.Name = "tsmiAddProduct";
            this.tsmiAddProduct.Size = new System.Drawing.Size(241, 22);
            this.tsmiAddProduct.Text = "����� �������";
            this.tsmiAddProduct.Click += new System.EventHandler(this.tsmiAddProduct_Click);
            // 
            // tsmiNewBySelected
            // 
            this.tsmiNewBySelected.Name = "tsmiNewBySelected";
            this.tsmiNewBySelected.Size = new System.Drawing.Size(241, 22);
            this.tsmiNewBySelected.Text = "����� �� ������ ����������";
            this.tsmiNewBySelected.Click += new System.EventHandler(this.tsmiNewBySelected_Click);
            // 
            // tsmiEditProduct
            // 
            this.tsmiEditProduct.Name = "tsmiEditProduct";
            this.tsmiEditProduct.Size = new System.Drawing.Size(241, 22);
            this.tsmiEditProduct.Text = "������������� �������";
            this.tsmiEditProduct.Click += new System.EventHandler(this.tsmiEditProduct_Click);
            // 
            // tsmiDeleteProduct
            // 
            this.tsmiDeleteProduct.Name = "tsmiDeleteProduct";
            this.tsmiDeleteProduct.Size = new System.Drawing.Size(241, 22);
            this.tsmiDeleteProduct.Text = "������� �������";
            this.tsmiDeleteProduct.Click += new System.EventHandler(this.tsmiDeleteProduct_Click);
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(6, 3);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(213, 21);
            this.cbxCategory.TabIndex = 1;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // dgvReceiptContent
            // 
            this.dgvReceiptContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptContent.ContextMenuStrip = this.cmsPositionsMenu;
            this.dgvReceiptContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceiptContent.Location = new System.Drawing.Point(0, 0);
            this.dgvReceiptContent.Name = "dgvReceiptContent";
            this.dgvReceiptContent.Size = new System.Drawing.Size(530, 284);
            this.dgvReceiptContent.TabIndex = 0;
            this.dgvReceiptContent.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvReceiptContent_RowPostPaint);
            this.dgvReceiptContent.SelectionChanged += new System.EventHandler(this.dgvReceiptContent_SelectionChanged);
            this.dgvReceiptContent.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvReceiptContent_UserDeletedRow);
            // 
            // cmsPositionsMenu
            // 
            this.cmsPositionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChangePosition,
            this.tsmiChangeProduct,
            this.tsmiSeparatorI,
            this.tsmiSearchSelectedPosition,
            this.tsmiSearchAllPositions});
            this.cmsPositionsMenu.Name = "cmsPositionsMenu";
            this.cmsPositionsMenu.Size = new System.Drawing.Size(243, 98);
            // 
            // tsmiChangePosition
            // 
            this.tsmiChangePosition.Name = "tsmiChangePosition";
            this.tsmiChangePosition.Size = new System.Drawing.Size(242, 22);
            this.tsmiChangePosition.Text = "�������� �������";
            this.tsmiChangePosition.Click += new System.EventHandler(this.tsmiChangePosition_Click);
            // 
            // tsmiChangeProduct
            // 
            this.tsmiChangeProduct.Name = "tsmiChangeProduct";
            this.tsmiChangeProduct.Size = new System.Drawing.Size(242, 22);
            this.tsmiChangeProduct.Text = "�������� ������ ���������...";
            this.tsmiChangeProduct.Click += new System.EventHandler(this.tsmiChangeProduct_Click);
            // 
            // tsmiSeparatorI
            // 
            this.tsmiSeparatorI.Name = "tsmiSeparatorI";
            this.tsmiSeparatorI.Size = new System.Drawing.Size(239, 6);
            // 
            // tsmiSearchSelectedPosition
            // 
            this.tsmiSearchSelectedPosition.Name = "tsmiSearchSelectedPosition";
            this.tsmiSearchSelectedPosition.Size = new System.Drawing.Size(242, 22);
            this.tsmiSearchSelectedPosition.Text = "����� ��������� �������";
            this.tsmiSearchSelectedPosition.Click += new System.EventHandler(this.tsmiSearchSelectedPosition_Click);
            // 
            // tsmiSearchAllPositions
            // 
            this.tsmiSearchAllPositions.Name = "tsmiSearchAllPositions";
            this.tsmiSearchAllPositions.Size = new System.Drawing.Size(242, 22);
            this.tsmiSearchAllPositions.Text = "����� ��� �������� ����";
            this.tsmiSearchAllPositions.Click += new System.EventHandler(this.tsmiSearchAllPositions_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(738, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "��������";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(338, 63);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(73, 13);
            this.lblComment.TabIndex = 12;
            this.lblComment.Text = "����������:";
            // 
            // tbxComment
            // 
            this.tbxComment.Location = new System.Drawing.Point(418, 60);
            this.tbxComment.MaxLength = 128;
            this.tbxComment.Multiline = true;
            this.tbxComment.Name = "tbxComment";
            this.tbxComment.Size = new System.Drawing.Size(395, 45);
            this.tbxComment.TabIndex = 13;
            // 
            // lblReceiptNumber
            // 
            this.lblReceiptNumber.AutoSize = true;
            this.lblReceiptNumber.Location = new System.Drawing.Point(13, 63);
            this.lblReceiptNumber.Name = "lblReceiptNumber";
            this.lblReceiptNumber.Size = new System.Drawing.Size(70, 13);
            this.lblReceiptNumber.TabIndex = 14;
            this.lblReceiptNumber.Text = "����� ����:";
            // 
            // lblDiscountCard
            // 
            this.lblDiscountCard.AutoSize = true;
            this.lblDiscountCard.Location = new System.Drawing.Point(13, 87);
            this.lblDiscountCard.Name = "lblDiscountCard";
            this.lblDiscountCard.Size = new System.Drawing.Size(104, 13);
            this.lblDiscountCard.TabIndex = 16;
            this.lblDiscountCard.Text = "���������� �����:";
            // 
            // cbxDiscountCards
            // 
            this.cbxDiscountCards.FormattingEnabled = true;
            this.cbxDiscountCards.Location = new System.Drawing.Point(145, 84);
            this.cbxDiscountCards.Name = "cbxDiscountCards";
            this.cbxDiscountCards.Size = new System.Drawing.Size(175, 21);
            this.cbxDiscountCards.TabIndex = 15;
            // 
            // lblPositions
            // 
            this.lblPositions.AutoSize = true;
            this.lblPositions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPositions.Location = new System.Drawing.Point(13, 402);
            this.lblPositions.Name = "lblPositions";
            this.lblPositions.Size = new System.Drawing.Size(126, 16);
            this.lblPositions.TabIndex = 17;
            this.lblPositions.Text = "����� �������: ";
            // 
            // btnAddDiscountCard
            // 
            this.btnAddDiscountCard.Location = new System.Drawing.Point(326, 82);
            this.btnAddDiscountCard.Name = "btnAddDiscountCard";
            this.btnAddDiscountCard.Size = new System.Drawing.Size(22, 23);
            this.btnAddDiscountCard.TabIndex = 19;
            this.btnAddDiscountCard.Text = "...";
            this.btnAddDiscountCard.UseVisualStyleBackColor = true;
            this.btnAddDiscountCard.Click += new System.EventHandler(this.btnAddDiscountCard_Click);
            // 
            // llblReceiptSum
            // 
            this.llblReceiptSum.AutoSize = true;
            this.llblReceiptSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llblReceiptSum.Location = new System.Drawing.Point(15, 419);
            this.llblReceiptSum.Name = "llblReceiptSum";
            this.llblReceiptSum.Size = new System.Drawing.Size(82, 16);
            this.llblReceiptSum.TabIndex = 20;
            this.llblReceiptSum.TabStop = true;
            this.llblReceiptSum.Text = "�� �����:";
            this.llblReceiptSum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblReceiptSum_LinkClicked);
            // 
            // btnNewCompany
            // 
            this.btnNewCompany.Location = new System.Drawing.Point(783, 5);
            this.btnNewCompany.Name = "btnNewCompany";
            this.btnNewCompany.Size = new System.Drawing.Size(29, 23);
            this.btnNewCompany.TabIndex = 22;
            this.btnNewCompany.Text = "...";
            this.btnNewCompany.UseVisualStyleBackColor = true;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(338, 9);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(61, 13);
            this.lblCompany.TabIndex = 21;
            this.lblCompany.Text = "��������:";
            // 
            // cbxCompanies
            // 
            this.cbxCompanies.FormattingEnabled = true;
            this.cbxCompanies.Location = new System.Drawing.Point(417, 6);
            this.cbxCompanies.Name = "cbxCompanies";
            this.cbxCompanies.Size = new System.Drawing.Size(360, 21);
            this.cbxCompanies.TabIndex = 23;
            this.cbxCompanies.SelectedIndexChanged += new System.EventHandler(this.cbxCompanies_SelectedIndexChanged);
            // 
            // ReceiptForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(816, 438);
            this.Controls.Add(this.btnNewCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cbxCompanies);
            this.Controls.Add(this.llblReceiptSum);
            this.Controls.Add(this.btnAddDiscountCard);
            this.Controls.Add(this.lblPositions);
            this.Controls.Add(this.lblDiscountCard);
            this.Controls.Add(this.cbxDiscountCards);
            this.Controls.Add(this.lblReceiptNumber);
            this.Controls.Add(this.tbxComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.scContent);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbxReceiptNumber);
            this.Controls.Add(this.dtpPeceiptDate);
            this.Controls.Add(this.lblReceiptDate);
            this.Controls.Add(this.btnNewVendor);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.cbxVendors);
            this.Controls.Add(this.lblVendorType);
            this.Controls.Add(this.cbxVendorTypes);
            this.Name = "ReceiptForm";
            this.Text = "���";
            this.Load += new System.EventHandler(this.ReceiptForm_Load);
            this.Resize += new System.EventHandler(this.ReceiptForm_Resize);
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel1.PerformLayout();
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.cmsProductsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptContent)).EndInit();
            this.cmsPositionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxVendorTypes;
        private System.Windows.Forms.Label lblVendorType;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.ComboBox cbxVendors;
        private System.Windows.Forms.Button btnNewVendor;
        private System.Windows.Forms.Label lblReceiptDate;
        private System.Windows.Forms.DateTimePicker dtpPeceiptDate;
        private System.Windows.Forms.TextBox tbxReceiptNumber;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvReceiptContent;
        private System.Windows.Forms.ListBox lbxProducts;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnNewCategory;
        private System.Windows.Forms.ContextMenuStrip cmsProductsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditProduct;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox tbxComment;
        private System.Windows.Forms.Label lblReceiptNumber;
        private System.Windows.Forms.Label lblDiscountCard;
        private System.Windows.Forms.ComboBox cbxDiscountCards;
        private System.Windows.Forms.Label lblPositions;
        private System.Windows.Forms.ContextMenuStrip cmsPositionsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePosition;
        private System.Windows.Forms.Button btnAddDiscountCard;
        private System.Windows.Forms.TextBox tbxSearchProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeProduct;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewBySelected;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchSelectedPosition;
        private System.Windows.Forms.ToolStripSeparator tsmiSeparatorI;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchAllPositions;
        private System.Windows.Forms.LinkLabel llblReceiptSum;
        private System.Windows.Forms.Button btnNewCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cbxCompanies;
    }
}