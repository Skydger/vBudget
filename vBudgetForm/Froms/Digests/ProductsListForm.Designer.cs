namespace vBudgetForm
{
    partial class ProductsListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection;
        private bool bBlockContent = false;
        private System.Data.DataTable categories = null;
        private System.Data.DataTable products = null;
        private System.Data.DataTable types_table = null;

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
            this.lvProducts = new System.Windows.Forms.ListView();
            this.cmsProductsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddNewProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.scProductsContainer = new System.Windows.Forms.SplitContainer();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.cbxCategories = new System.Windows.Forms.ComboBox();
            this.clbxTypes = new System.Windows.Forms.CheckedListBox();
            this.cmsProductTypesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddNewType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProductsMenu.SuspendLayout();
            this.scProductsContainer.Panel1.SuspendLayout();
            this.scProductsContainer.Panel2.SuspendLayout();
            this.scProductsContainer.SuspendLayout();
            this.cmsProductTypesMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvProducts
            // 
            this.lvProducts.ContextMenuStrip = this.cmsProductsMenu;
            this.lvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProducts.FullRowSelect = true;
            this.lvProducts.Location = new System.Drawing.Point(0, 0);
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(485, 393);
            this.lvProducts.TabIndex = 0;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            // 
            // cmsProductsMenu
            // 
            this.cmsProductsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddNewProduct,
            this.tsmiChangeProduct,
            this.tsmiDeleteProduct});
            this.cmsProductsMenu.Name = "cmsProductsMenu";
            this.cmsProductsMenu.Size = new System.Drawing.Size(213, 70);
            // 
            // tsmiAddNewProduct
            // 
            this.tsmiAddNewProduct.Name = "tsmiAddNewProduct";
            this.tsmiAddNewProduct.Size = new System.Drawing.Size(212, 22);
            this.tsmiAddNewProduct.Text = "Добавить новый продукт";
            this.tsmiAddNewProduct.Click += new System.EventHandler(this.tsmiAddNewProduct_Click);
            // 
            // tsmiChangeProduct
            // 
            this.tsmiChangeProduct.Name = "tsmiChangeProduct";
            this.tsmiChangeProduct.Size = new System.Drawing.Size(212, 22);
            this.tsmiChangeProduct.Text = "Изменить продукт";
            this.tsmiChangeProduct.Click += new System.EventHandler(this.tsmiChangeProduct_Click);
            // 
            // tsmiDeleteProduct
            // 
            this.tsmiDeleteProduct.Name = "tsmiDeleteProduct";
            this.tsmiDeleteProduct.Size = new System.Drawing.Size(212, 22);
            this.tsmiDeleteProduct.Text = "Удалить продукт";
            this.tsmiDeleteProduct.Click += new System.EventHandler(this.tsmiDeleteProduct_Click);
            // 
            // scProductsContainer
            // 
            this.scProductsContainer.Location = new System.Drawing.Point(12, 12);
            this.scProductsContainer.Name = "scProductsContainer";
            // 
            // scProductsContainer.Panel1
            // 
            this.scProductsContainer.Panel1.Controls.Add(this.btnAddCategory);
            this.scProductsContainer.Panel1.Controls.Add(this.cbxCategories);
            this.scProductsContainer.Panel1.Controls.Add(this.clbxTypes);
            // 
            // scProductsContainer.Panel2
            // 
            this.scProductsContainer.Panel2.Controls.Add(this.lvProducts);
            this.scProductsContainer.Size = new System.Drawing.Size(731, 393);
            this.scProductsContainer.SplitterDistance = 242;
            this.scProductsContainer.TabIndex = 1;
            this.scProductsContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scProductsContainer_SplitterMoved);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(193, 3);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(24, 23);
            this.btnAddCategory.TabIndex = 2;
            this.btnAddCategory.Text = "...";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // cbxCategories
            // 
            this.cbxCategories.FormattingEnabled = true;
            this.cbxCategories.Location = new System.Drawing.Point(3, 3);
            this.cbxCategories.Name = "cbxCategories";
            this.cbxCategories.Size = new System.Drawing.Size(184, 21);
            this.cbxCategories.TabIndex = 1;
            this.cbxCategories.SelectedIndexChanged += new System.EventHandler(this.cbxCategories_SelectedIndexChanged);
            // 
            // clbxTypes
            // 
            this.clbxTypes.ContextMenuStrip = this.cmsProductTypesMenu;
            this.clbxTypes.FormattingEnabled = true;
            this.clbxTypes.Location = new System.Drawing.Point(3, 30);
            this.clbxTypes.Name = "clbxTypes";
            this.clbxTypes.Size = new System.Drawing.Size(237, 334);
            this.clbxTypes.TabIndex = 0;
            this.clbxTypes.SelectedIndexChanged += new System.EventHandler(this.clbxTypes_SelectedIndexChanged);
            this.clbxTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbxTypes_ItemCheck);
            // 
            // cmsProductTypesMenu
            // 
            this.cmsProductTypesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddNewType,
            this.tsmiEditType,
            this.tsmiDeleteCategory});
            this.cmsProductTypesMenu.Name = "cmsProductTypesMenu";
            this.cmsProductTypesMenu.Size = new System.Drawing.Size(155, 70);
            this.cmsProductTypesMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsProductTypesMenu_Opening);
            // 
            // tsmiAddNewType
            // 
            this.tsmiAddNewType.Name = "tsmiAddNewType";
            this.tsmiAddNewType.Size = new System.Drawing.Size(154, 22);
            this.tsmiAddNewType.Text = "Добавить";
            this.tsmiAddNewType.Click += new System.EventHandler(this.tsmiAddNewType_Click);
            // 
            // tsmiEditType
            // 
            this.tsmiEditType.Name = "tsmiEditType";
            this.tsmiEditType.Size = new System.Drawing.Size(154, 22);
            this.tsmiEditType.Text = "Редактировать";
            this.tsmiEditType.Click += new System.EventHandler(this.tsmiEditType_Click);
            // 
            // tsmiDeleteCategory
            // 
            this.tsmiDeleteCategory.Name = "tsmiDeleteCategory";
            this.tsmiDeleteCategory.Size = new System.Drawing.Size(154, 22);
            this.tsmiDeleteCategory.Text = "Удалить";
            this.tsmiDeleteCategory.Click += new System.EventHandler(this.tsmiDeleteCategory_Click);
            // 
            // ProductsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 417);
            this.Controls.Add(this.scProductsContainer);
            this.Name = "ProductsListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Продукты";
            this.Load += new System.EventHandler(this.ProductsListForm_Load);
            this.Resize += new System.EventHandler(this.ProductsListForm_Resize);
            this.cmsProductsMenu.ResumeLayout(false);
            this.scProductsContainer.Panel1.ResumeLayout(false);
            this.scProductsContainer.Panel2.ResumeLayout(false);
            this.scProductsContainer.ResumeLayout(false);
            this.cmsProductTypesMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.SplitContainer scProductsContainer;
        private System.Windows.Forms.CheckedListBox clbxTypes;
        private System.Windows.Forms.ComboBox cbxCategories;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.ContextMenuStrip cmsProductsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeProduct;
        private System.Windows.Forms.ContextMenuStrip cmsProductTypesMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewType;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditType;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCategory;
    }
}