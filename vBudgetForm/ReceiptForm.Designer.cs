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
        private System.Data.DataTable vendors = null;
        private System.Data.DataTable cards = null;
        private bool isNew = false;
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblComment = new System.Windows.Forms.Label();
            this.tbxComment = new System.Windows.Forms.TextBox();
            this.lblReceiptNumber = new System.Windows.Forms.Label();
            this.lblDiscountCard = new System.Windows.Forms.Label();
            this.cbxDiscountCards = new System.Windows.Forms.ComboBox();
            this.lblPositions = new System.Windows.Forms.Label();
            this.lblReceiptSum = new System.Windows.Forms.Label();
            this.btnAddDiscountCard = new System.Windows.Forms.Button();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiUpToOneLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDownToOneLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.cmsProductsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptContent)).BeginInit();
            this.cmsPositionsMenu.SuspendLayout();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxVendorTypes
            // 
            this.cbxVendorTypes.FormattingEnabled = true;
            this.cbxVendorTypes.Location = new System.Drawing.Point(141, 27);
            this.cbxVendorTypes.Name = "cbxVendorTypes";
            this.cbxVendorTypes.Size = new System.Drawing.Size(147, 21);
            this.cbxVendorTypes.TabIndex = 1;
            this.cbxVendorTypes.SelectedIndexChanged += new System.EventHandler(this.cbxVendorTypes_SelectedIndexChanged);
            // 
            // lblVendorType
            // 
            this.lblVendorType.AutoSize = true;
            this.lblVendorType.Location = new System.Drawing.Point(9, 30);
            this.lblVendorType.Name = "lblVendorType";
            this.lblVendorType.Size = new System.Drawing.Size(126, 13);
            this.lblVendorType.TabIndex = 1;
            this.lblVendorType.Text = "Сфера товаров и услуг:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(335, 30);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(60, 13);
            this.lblVendor.TabIndex = 3;
            this.lblVendor.Text = "Продавец:";
            // 
            // cbxVendors
            // 
            this.cbxVendors.FormattingEnabled = true;
            this.cbxVendors.Location = new System.Drawing.Point(414, 27);
            this.cbxVendors.Name = "cbxVendors";
            this.cbxVendors.Size = new System.Drawing.Size(360, 21);
            this.cbxVendors.TabIndex = 16;
            this.cbxVendors.SelectedIndexChanged += new System.EventHandler(this.cbxVendors_SelectedIndexChanged);
            this.cbxVendors.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxVendors_KeyUp);
            this.cbxVendors.TextChanged += new System.EventHandler(this.cbxVendors_TextChanged);
            // 
            // btnNewVendor
            // 
            this.btnNewVendor.Location = new System.Drawing.Point(780, 26);
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
            this.lblReceiptDate.Location = new System.Drawing.Point(9, 62);
            this.lblReceiptDate.Name = "lblReceiptDate";
            this.lblReceiptDate.Size = new System.Drawing.Size(36, 13);
            this.lblReceiptDate.TabIndex = 5;
            this.lblReceiptDate.Text = "Дата:";
            // 
            // dtpPeceiptDate
            // 
            this.dtpPeceiptDate.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpPeceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeceiptDate.Location = new System.Drawing.Point(141, 56);
            this.dtpPeceiptDate.Name = "dtpPeceiptDate";
            this.dtpPeceiptDate.Size = new System.Drawing.Size(147, 20);
            this.dtpPeceiptDate.TabIndex = 6;
            this.dtpPeceiptDate.ValueChanged += new System.EventHandler(this.dtpPeceiptDate_ValueChanged);
            // 
            // tbxReceiptNumber
            // 
            this.tbxReceiptNumber.Location = new System.Drawing.Point(141, 81);
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
            this.btnOk.Text = "Применить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // scContent
            // 
            this.scContent.Location = new System.Drawing.Point(12, 134);
            this.scContent.Name = "scContent";
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.lblSearch);
            this.scContent.Panel1.Controls.Add(this.tbxSearchProduct);
            this.scContent.Panel1.Controls.Add(this.btnNewCategory);
            this.scContent.Panel1.Controls.Add(this.btnAddProduct);
            this.scContent.Panel1.Controls.Add(this.lbxProducts);
            this.scContent.Panel1.Controls.Add(this.cbxCategory);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.dgvReceiptContent);
            this.scContent.Size = new System.Drawing.Size(800, 264);
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
            this.lblSearch.Text = "Поиск:";
            // 
            // tbxSearchProduct
            // 
            this.tbxSearchProduct.Location = new System.Drawing.Point(47, 30);
            this.tbxSearchProduct.Name = "tbxSearchProduct";
            this.tbxSearchProduct.Size = new System.Drawing.Size(200, 20);
            this.tbxSearchProduct.TabIndex = 5;
            this.tbxSearchProduct.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxSearchProduct_KeyUp);
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
            this.btnAddProduct.Location = new System.Drawing.Point(247, 103);
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
            this.lbxProducts.Size = new System.Drawing.Size(247, 225);
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
            this.tsmiAddProduct.Text = "Новый продукт";
            this.tsmiAddProduct.Click += new System.EventHandler(this.tsmiAddProduct_Click);
            // 
            // tsmiNewBySelected
            // 
            this.tsmiNewBySelected.Name = "tsmiNewBySelected";
            this.tsmiNewBySelected.Size = new System.Drawing.Size(241, 22);
            this.tsmiNewBySelected.Text = "Новый на основе выбранного";
            this.tsmiNewBySelected.Click += new System.EventHandler(this.tsmiNewBySelected_Click);
            // 
            // tsmiEditProduct
            // 
            this.tsmiEditProduct.Name = "tsmiEditProduct";
            this.tsmiEditProduct.Size = new System.Drawing.Size(241, 22);
            this.tsmiEditProduct.Text = "Редактировать продукт";
            this.tsmiEditProduct.Click += new System.EventHandler(this.tsmiEditProduct_Click);
            // 
            // tsmiDeleteProduct
            // 
            this.tsmiDeleteProduct.Name = "tsmiDeleteProduct";
            this.tsmiDeleteProduct.Size = new System.Drawing.Size(241, 22);
            this.tsmiDeleteProduct.Text = "Удалить продукт";
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
            this.dgvReceiptContent.Size = new System.Drawing.Size(530, 264);
            this.dgvReceiptContent.TabIndex = 0;
            this.dgvReceiptContent.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvReceiptContent_RowPostPaint);
            this.dgvReceiptContent.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvReceiptContent_UserDeletedRow);
            // 
            // cmsPositionsMenu
            // 
            this.cmsPositionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChangePosition,
            this.tsmiChangeProduct,
            this.toolStripMenuItem1,
            this.tsmiUpToOneLevel,
            this.tsmiDownToOneLevel});
            this.cmsPositionsMenu.Name = "cmsPositionsMenu";
            this.cmsPositionsMenu.Size = new System.Drawing.Size(243, 120);
            this.cmsPositionsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPositionsMenu_Opening);
            // 
            // tsmiChangePosition
            // 
            this.tsmiChangePosition.Name = "tsmiChangePosition";
            this.tsmiChangePosition.Size = new System.Drawing.Size(242, 22);
            this.tsmiChangePosition.Text = "Изменить позицию";
            this.tsmiChangePosition.Click += new System.EventHandler(this.tsmiChangePosition_Click);
            // 
            // tsmiChangeProduct
            // 
            this.tsmiChangeProduct.Name = "tsmiChangeProduct";
            this.tsmiChangeProduct.Size = new System.Drawing.Size(242, 22);
            this.tsmiChangeProduct.Text = "Заменить другим продуктом...";
            this.tsmiChangeProduct.Click += new System.EventHandler(this.tsmiChangeProduct_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(738, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(335, 60);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(73, 13);
            this.lblComment.TabIndex = 12;
            this.lblComment.Text = "Примечание:";
            // 
            // tbxComment
            // 
            this.tbxComment.Location = new System.Drawing.Point(414, 59);
            this.tbxComment.MaxLength = 128;
            this.tbxComment.Multiline = true;
            this.tbxComment.Name = "tbxComment";
            this.tbxComment.Size = new System.Drawing.Size(395, 60);
            this.tbxComment.TabIndex = 13;
            // 
            // lblReceiptNumber
            // 
            this.lblReceiptNumber.AutoSize = true;
            this.lblReceiptNumber.Location = new System.Drawing.Point(10, 84);
            this.lblReceiptNumber.Name = "lblReceiptNumber";
            this.lblReceiptNumber.Size = new System.Drawing.Size(70, 13);
            this.lblReceiptNumber.TabIndex = 14;
            this.lblReceiptNumber.Text = "Номер чека:";
            // 
            // lblDiscountCard
            // 
            this.lblDiscountCard.AutoSize = true;
            this.lblDiscountCard.Location = new System.Drawing.Point(10, 108);
            this.lblDiscountCard.Name = "lblDiscountCard";
            this.lblDiscountCard.Size = new System.Drawing.Size(104, 13);
            this.lblDiscountCard.TabIndex = 16;
            this.lblDiscountCard.Text = "Дисконтная карта:";
            // 
            // cbxDiscountCards
            // 
            this.cbxDiscountCards.FormattingEnabled = true;
            this.cbxDiscountCards.Location = new System.Drawing.Point(142, 105);
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
            this.lblPositions.Text = "Всего позиций: ";
            // 
            // lblReceiptSum
            // 
            this.lblReceiptSum.AutoSize = true;
            this.lblReceiptSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblReceiptSum.Location = new System.Drawing.Point(13, 419);
            this.lblReceiptSum.Name = "lblReceiptSum";
            this.lblReceiptSum.Size = new System.Drawing.Size(86, 16);
            this.lblReceiptSum.TabIndex = 18;
            this.lblReceiptSum.Text = "На сумму: ";
            // 
            // btnAddDiscountCard
            // 
            this.btnAddDiscountCard.Location = new System.Drawing.Point(323, 103);
            this.btnAddDiscountCard.Name = "btnAddDiscountCard";
            this.btnAddDiscountCard.Size = new System.Drawing.Size(22, 23);
            this.btnAddDiscountCard.TabIndex = 19;
            this.btnAddDiscountCard.Text = "...";
            this.btnAddDiscountCard.UseVisualStyleBackColor = true;
            this.btnAddDiscountCard.Click += new System.EventHandler(this.btnAddDiscountCard_Click);
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiActionsToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(816, 24);
            this.msMainMenu.TabIndex = 20;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // tsmiActionsToolStripMenuItem
            // 
            this.tsmiActionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImport,
            this.tsmiExport});
            this.tsmiActionsToolStripMenuItem.Name = "tsmiActionsToolStripMenuItem";
            this.tsmiActionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.tsmiActionsToolStripMenuItem.Text = "Actions";
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(158, 22);
            this.tsmiImport.Text = "Import receipt...";
            // 
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(158, 22);
            this.tsmiExport.Text = "Export receipt...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(239, 6);
            // 
            // tsmiUpToOneLevel
            // 
            this.tsmiUpToOneLevel.Name = "tsmiUpToOneLevel";
            this.tsmiUpToOneLevel.Size = new System.Drawing.Size(242, 22);
            this.tsmiUpToOneLevel.Text = "На уровень вверх";
            this.tsmiUpToOneLevel.Click += new System.EventHandler(this.tsmiUpToOneLevel_Click);
            // 
            // tsmiDownToOneLevel
            // 
            this.tsmiDownToOneLevel.Name = "tsmiDownToOneLevel";
            this.tsmiDownToOneLevel.Size = new System.Drawing.Size(242, 22);
            this.tsmiDownToOneLevel.Text = "На уровень вниз";
            // 
            // ReceiptForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(816, 438);
            this.Controls.Add(this.msMainMenu);
            this.Controls.Add(this.lblReceiptSum);
            this.Controls.Add(this.lblPositions);
            this.Controls.Add(this.btnAddDiscountCard);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.scContent);
            this.Controls.Add(this.lblDiscountCard);
            this.Controls.Add(this.cbxDiscountCards);
            this.Controls.Add(this.lblReceiptNumber);
            this.Controls.Add(this.tbxComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblVendorType);
            this.Controls.Add(this.cbxVendorTypes);
            this.Controls.Add(this.tbxReceiptNumber);
            this.Controls.Add(this.dtpPeceiptDate);
            this.Controls.Add(this.lblReceiptDate);
            this.Controls.Add(this.btnNewVendor);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.cbxVendors);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "ReceiptForm";
            this.Text = "Чек";
            this.Load += new System.EventHandler(this.ReceiptForm_Load);
            this.Resize += new System.EventHandler(this.ReceiptForm_Resize);
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel1.PerformLayout();
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.cmsProductsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptContent)).EndInit();
            this.cmsPositionsMenu.ResumeLayout(false);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
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
        private System.Windows.Forms.Label lblReceiptSum;
        private System.Windows.Forms.ContextMenuStrip cmsPositionsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePosition;
        private System.Windows.Forms.Button btnAddDiscountCard;
        private System.Windows.Forms.TextBox tbxSearchProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeProduct;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewBySelected;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpToOneLevel;
        private System.Windows.Forms.ToolStripMenuItem tsmiDownToOneLevel;
    }
}