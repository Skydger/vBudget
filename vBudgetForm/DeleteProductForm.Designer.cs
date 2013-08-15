namespace vBudgetForm
{
    partial class DeleteProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.scProducts = new System.Windows.Forms.SplitContainer();
            this.tvContents = new System.Windows.Forms.TreeView();
            this.tbxSearchProduct = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lvProducts = new System.Windows.Forms.ListView();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.scProducts.Panel1.SuspendLayout();
            this.scProducts.Panel2.SuspendLayout();
            this.scProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // scProducts
            // 
            this.scProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scProducts.Location = new System.Drawing.Point(0, 0);
            this.scProducts.Name = "scProducts";
            // 
            // scProducts.Panel1
            // 
            this.scProducts.Panel1.Controls.Add(this.tvContents);
            // 
            // scProducts.Panel2
            // 
            this.scProducts.Panel2.Controls.Add(this.tbxSearchProduct);
            this.scProducts.Panel2.Controls.Add(this.lblSearch);
            this.scProducts.Panel2.Controls.Add(this.lvProducts);
            this.scProducts.Panel2.Controls.Add(this.lblCategory);
            this.scProducts.Panel2.Controls.Add(this.cbxCategory);
            this.scProducts.Size = new System.Drawing.Size(768, 304);
            this.scProducts.SplitterDistance = 395;
            this.scProducts.TabIndex = 0;
            // 
            // tvContents
            // 
            this.tvContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContents.Location = new System.Drawing.Point(0, 0);
            this.tvContents.Name = "tvContents";
            this.tvContents.Size = new System.Drawing.Size(395, 304);
            this.tvContents.TabIndex = 0;
            // 
            // tbxSearchProduct
            // 
            this.tbxSearchProduct.Location = new System.Drawing.Point(103, 6);
            this.tbxSearchProduct.Name = "tbxSearchProduct";
            this.tbxSearchProduct.Size = new System.Drawing.Size(259, 20);
            this.tbxSearchProduct.TabIndex = 5;
            this.tbxSearchProduct.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxSearchString_KeyUp);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(91, 13);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Поиск продукта:";
            // 
            // lvProducts
            // 
            this.lvProducts.Location = new System.Drawing.Point(6, 59);
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(356, 238);
            this.lvProducts.TabIndex = 3;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            this.lvProducts.ItemActivate += new System.EventHandler(this.lvProducts_ItemActivate);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(6, 35);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Категория:";
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(72, 32);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(290, 21);
            this.cbxCategory.TabIndex = 1;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // DeleteProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 304);
            this.Controls.Add(this.scProducts);
            this.Name = "DeleteProductForm";
            this.Text = "Удаление продукта";
            this.Load += new System.EventHandler(this.DeleteProductForm_Load);
            this.Resize += new System.EventHandler(this.DeleteProductForm_Resize);
            this.scProducts.Panel1.ResumeLayout(false);
            this.scProducts.Panel2.ResumeLayout(false);
            this.scProducts.Panel2.PerformLayout();
            this.scProducts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scProducts;
        private System.Windows.Forms.TreeView tvContents;
        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.TextBox tbxSearchProduct;
        private System.Windows.Forms.Label lblSearch;
    }
}