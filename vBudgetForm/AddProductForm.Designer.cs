namespace vBudgetForm
{
    partial class AddProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection;
        private System.Data.DataTable categories = null;
        private System.Data.DataTable types_table = null;
        private System.Data.DataTable makers = null;
        private System.Data.DataRow product = null;
        private bool isNew;
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
            this.lblMaker = new System.Windows.Forms.Label();
            this.cbxMakers = new System.Windows.Forms.ComboBox();
            this.tbxComment = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.tbxBarcode = new System.Windows.Forms.TextBox();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxCategories = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbxTypes = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.btnAddType = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddMaker = new System.Windows.Forms.Button();
            this.cbDeleted = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblMaker
            // 
            this.lblMaker.AutoSize = true;
            this.lblMaker.Location = new System.Drawing.Point(11, 38);
            this.lblMaker.Name = "lblMaker";
            this.lblMaker.Size = new System.Drawing.Size(89, 13);
            this.lblMaker.TabIndex = 0;
            this.lblMaker.Text = "Производитель:";
            // 
            // cbxMakers
            // 
            this.cbxMakers.FormattingEnabled = true;
            this.cbxMakers.Location = new System.Drawing.Point(106, 35);
            this.cbxMakers.Name = "cbxMakers";
            this.cbxMakers.Size = new System.Drawing.Size(489, 21);
            this.cbxMakers.TabIndex = 1;
            // 
            // tbxComment
            // 
            this.tbxComment.Location = new System.Drawing.Point(14, 142);
            this.tbxComment.MaxLength = 128;
            this.tbxComment.Multiline = true;
            this.tbxComment.Name = "tbxComment";
            this.tbxComment.Size = new System.Drawing.Size(611, 60);
            this.tbxComment.TabIndex = 2;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(17, 100);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(62, 13);
            this.lblBarcode.TabIndex = 3;
            this.lblBarcode.Text = "Штрих-код:";
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Location = new System.Drawing.Point(106, 96);
            this.tbxBarcode.MaxLength = 32;
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.Size = new System.Drawing.Size(150, 20);
            this.tbxBarcode.TabIndex = 4;
            // 
            // tbxProductName
            // 
            this.tbxProductName.Location = new System.Drawing.Point(106, 70);
            this.tbxProductName.MaxLength = 128;
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.Size = new System.Drawing.Size(519, 20);
            this.tbxProductName.TabIndex = 6;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(17, 74);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(60, 13);
            this.lblProductName.TabIndex = 5;
            this.lblProductName.Text = "Название:";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(425, 208);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Применить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(550, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbxCategories
            // 
            this.cbxCategories.FormattingEnabled = true;
            this.cbxCategories.Location = new System.Drawing.Point(106, 6);
            this.cbxCategories.Name = "cbxCategories";
            this.cbxCategories.Size = new System.Drawing.Size(233, 21);
            this.cbxCategories.TabIndex = 10;
            this.cbxCategories.SelectedIndexChanged += new System.EventHandler(this.cbxCategories_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(11, 9);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "Категория:";
            // 
            // cbxTypes
            // 
            this.cbxTypes.FormattingEnabled = true;
            this.cbxTypes.Location = new System.Drawing.Point(423, 6);
            this.cbxTypes.Name = "cbxTypes";
            this.cbxTypes.Size = new System.Drawing.Size(172, 21);
            this.cbxTypes.TabIndex = 12;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(388, 9);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 13);
            this.lblType.TabIndex = 11;
            this.lblType.Text = "Тип:";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(17, 126);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(73, 13);
            this.lblComment.TabIndex = 13;
            this.lblComment.Text = "Примечание:";
            // 
            // btnAddType
            // 
            this.btnAddType.Location = new System.Drawing.Point(601, 5);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(24, 24);
            this.btnAddType.TabIndex = 14;
            this.btnAddType.Text = "...";
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(345, 5);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(24, 24);
            this.btnAddCategory.TabIndex = 15;
            this.btnAddCategory.Text = "...";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddMaker
            // 
            this.btnAddMaker.Location = new System.Drawing.Point(601, 35);
            this.btnAddMaker.Name = "btnAddMaker";
            this.btnAddMaker.Size = new System.Drawing.Size(24, 24);
            this.btnAddMaker.TabIndex = 16;
            this.btnAddMaker.Text = "...";
            this.btnAddMaker.UseVisualStyleBackColor = true;
            this.btnAddMaker.Click += new System.EventHandler(this.btnAddMaker_Click);
            // 
            // cbDeleted
            // 
            this.cbDeleted.AutoSize = true;
            this.cbDeleted.Enabled = false;
            this.cbDeleted.Location = new System.Drawing.Point(14, 212);
            this.cbDeleted.Name = "cbDeleted";
            this.cbDeleted.Size = new System.Drawing.Size(64, 17);
            this.cbDeleted.TabIndex = 17;
            this.cbDeleted.Text = "Удалён";
            this.cbDeleted.UseVisualStyleBackColor = true;
            // 
            // AddProductForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(645, 237);
            this.Controls.Add(this.cbDeleted);
            this.Controls.Add(this.btnAddMaker);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.cbxTypes);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cbxCategories);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tbxProductName);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.tbxBarcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.tbxComment);
            this.Controls.Add(this.cbxMakers);
            this.Controls.Add(this.lblMaker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddProductForm";
            this.Text = "Новый продукт";
            this.Load += new System.EventHandler(this.AddProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaker;
        private System.Windows.Forms.ComboBox cbxMakers;
        private System.Windows.Forms.TextBox tbxComment;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox tbxBarcode;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxCategories;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbxTypes;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAddMaker;
        private System.Windows.Forms.CheckBox cbDeleted;
    }
}