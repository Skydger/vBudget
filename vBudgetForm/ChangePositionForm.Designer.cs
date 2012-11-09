namespace vBudgetForm
{
    partial class ChangePositionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection connection = null;
        private System.Data.DataTable categories = null;
        private System.Data.DataTable products = null;
        private System.Data.DataRow product = null;
        private int product_id = -1;

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
            this.lblCategories = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.cbxProducts = new System.Windows.Forms.ComboBox();
            this.lblCurrentProduct = new System.Windows.Forms.Label();
            this.tbxCurrentProduct = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(23, 45);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(63, 13);
            this.lblCategories.TabIndex = 0;
            this.lblCategories.Text = "Категория:";
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(92, 42);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(326, 21);
            this.cbxCategory.TabIndex = 1;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(23, 72);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(52, 13);
            this.lblProduct.TabIndex = 2;
            this.lblProduct.Text = "Продукт:";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(424, 40);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(26, 23);
            this.btnAddCategory.TabIndex = 3;
            this.btnAddCategory.Text = "...";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(424, 67);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(26, 23);
            this.btnAddProduct.TabIndex = 5;
            this.btnAddProduct.Text = "...";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // cbxProducts
            // 
            this.cbxProducts.FormattingEnabled = true;
            this.cbxProducts.Location = new System.Drawing.Point(92, 69);
            this.cbxProducts.Name = "cbxProducts";
            this.cbxProducts.Size = new System.Drawing.Size(326, 21);
            this.cbxProducts.TabIndex = 4;
            // 
            // lblCurrentProduct
            // 
            this.lblCurrentProduct.AutoSize = true;
            this.lblCurrentProduct.Location = new System.Drawing.Point(23, 18);
            this.lblCurrentProduct.Name = "lblCurrentProduct";
            this.lblCurrentProduct.Size = new System.Drawing.Size(98, 13);
            this.lblCurrentProduct.TabIndex = 6;
            this.lblCurrentProduct.Text = "Текущий продукт:";
            // 
            // tbxCurrentProduct
            // 
            this.tbxCurrentProduct.Enabled = false;
            this.tbxCurrentProduct.Location = new System.Drawing.Point(127, 15);
            this.tbxCurrentProduct.Name = "tbxCurrentProduct";
            this.tbxCurrentProduct.Size = new System.Drawing.Size(323, 20);
            this.tbxCurrentProduct.TabIndex = 7;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(248, 107);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Применить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(375, 107);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ChangePositionForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(468, 141);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tbxCurrentProduct);
            this.Controls.Add(this.lblCurrentProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.cbxProducts);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cbxCategory);
            this.Controls.Add(this.lblCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChangePositionForm";
            this.Text = "Изменить продукт на...";
            this.Load += new System.EventHandler(this.ChangePositionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ComboBox cbxProducts;
        private System.Windows.Forms.Label lblCurrentProduct;
        private System.Windows.Forms.TextBox tbxCurrentProduct;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}