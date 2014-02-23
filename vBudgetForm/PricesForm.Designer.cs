namespace vBudgetForm
{
    partial class PricesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection = null;
        private bool bBlockContent = false;
        private System.Data.DataTable categories = null;
        private System.Data.DataTable products = null;
        private System.Data.DataTable prices = null;

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
            this.lblProduct = new System.Windows.Forms.Label();
            this.cbxProducts = new System.Windows.Forms.ComboBox();
            this.cbxCategories = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lvPrices = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(16, 43);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(49, 13);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "Продукт";
            // 
            // cbxProducts
            // 
            this.cbxProducts.FormattingEnabled = true;
            this.cbxProducts.Location = new System.Drawing.Point(82, 40);
            this.cbxProducts.Name = "cbxProducts";
            this.cbxProducts.Size = new System.Drawing.Size(285, 21);
            this.cbxProducts.TabIndex = 1;
            this.cbxProducts.SelectedIndexChanged += new System.EventHandler(this.cbxProducts_SelectedIndexChanged);
            // 
            // cbxCategories
            // 
            this.cbxCategories.FormattingEnabled = true;
            this.cbxCategories.Location = new System.Drawing.Point(82, 12);
            this.cbxCategories.Name = "cbxCategories";
            this.cbxCategories.Size = new System.Drawing.Size(285, 21);
            this.cbxCategories.TabIndex = 3;
            this.cbxCategories.SelectedIndexChanged += new System.EventHandler(this.cbxCategories_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(16, 15);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(60, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Категория";
            // 
            // lvPrices
            // 
            this.lvPrices.FullRowSelect = true;
            this.lvPrices.Location = new System.Drawing.Point(12, 67);
            this.lvPrices.Name = "lvPrices";
            this.lvPrices.Size = new System.Drawing.Size(622, 186);
            this.lvPrices.TabIndex = 4;
            this.lvPrices.UseCompatibleStateImageBehavior = false;
            this.lvPrices.View = System.Windows.Forms.View.Details;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(385, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 21);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // PricesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 265);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lvPrices);
            this.Controls.Add(this.cbxCategories);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cbxProducts);
            this.Controls.Add(this.lblProduct);
            this.Name = "PricesForm";
            this.Text = "Товары и цены";
            this.Load += new System.EventHandler(this.PricesForm_Load);
            this.Resize += new System.EventHandler(this.PricesForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cbxProducts;
        private System.Windows.Forms.ComboBox cbxCategories;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ListView lvPrices;
        private System.Windows.Forms.Button btnSearch;
    }
}