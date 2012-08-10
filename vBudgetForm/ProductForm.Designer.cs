namespace vBudgetForm
{
    partial class ProductForm
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
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddType = new System.Windows.Forms.Button();
            this.cbxTypes = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnAddMaker = new System.Windows.Forms.Button();
            this.cbxMakers = new System.Windows.Forms.ComboBox();
            this.lblMaker = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.tbxBarcode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.tbxComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(25, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Категория:";
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(114, 17);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(281, 21);
            this.cbxCategory.TabIndex = 1;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(401, 15);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(28, 23);
            this.btnAddCategory.TabIndex = 2;
            this.btnAddCategory.Text = "...";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            // 
            // btnAddType
            // 
            this.btnAddType.Location = new System.Drawing.Point(401, 42);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(28, 23);
            this.btnAddType.TabIndex = 5;
            this.btnAddType.Text = "...";
            this.btnAddType.UseVisualStyleBackColor = true;
            // 
            // cbxTypes
            // 
            this.cbxTypes.FormattingEnabled = true;
            this.cbxTypes.Location = new System.Drawing.Point(114, 44);
            this.cbxTypes.Name = "cbxTypes";
            this.cbxTypes.Size = new System.Drawing.Size(281, 21);
            this.cbxTypes.TabIndex = 4;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(25, 47);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 13);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Тип:";
            // 
            // btnAddMaker
            // 
            this.btnAddMaker.Location = new System.Drawing.Point(401, 69);
            this.btnAddMaker.Name = "btnAddMaker";
            this.btnAddMaker.Size = new System.Drawing.Size(28, 23);
            this.btnAddMaker.TabIndex = 8;
            this.btnAddMaker.Text = "...";
            this.btnAddMaker.UseVisualStyleBackColor = true;
            // 
            // cbxMakers
            // 
            this.cbxMakers.FormattingEnabled = true;
            this.cbxMakers.Location = new System.Drawing.Point(114, 71);
            this.cbxMakers.Name = "cbxMakers";
            this.cbxMakers.Size = new System.Drawing.Size(281, 21);
            this.cbxMakers.TabIndex = 7;
            // 
            // lblMaker
            // 
            this.lblMaker.AutoSize = true;
            this.lblMaker.Location = new System.Drawing.Point(25, 74);
            this.lblMaker.Name = "lblMaker";
            this.lblMaker.Size = new System.Drawing.Size(89, 13);
            this.lblMaker.TabIndex = 6;
            this.lblMaker.Text = "Производитель:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(25, 104);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(86, 13);
            this.lblProductName.TabIndex = 9;
            this.lblProductName.Text = "Наименование:";
            // 
            // tbxProductName
            // 
            this.tbxProductName.Location = new System.Drawing.Point(114, 101);
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.Size = new System.Drawing.Size(315, 20);
            this.tbxProductName.TabIndex = 10;
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Location = new System.Drawing.Point(114, 127);
            this.tbxBarcode.MaxLength = 13;
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.Size = new System.Drawing.Size(115, 20);
            this.tbxBarcode.TabIndex = 12;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(25, 130);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(62, 13);
            this.lblBarcode.TabIndex = 11;
            this.lblBarcode.Text = "Штрих-код:";
            // 
            // tbxComment
            // 
            this.tbxComment.Location = new System.Drawing.Point(114, 153);
            this.tbxComment.MaxLength = 128;
            this.tbxComment.Multiline = true;
            this.tbxComment.Name = "tbxComment";
            this.tbxComment.Size = new System.Drawing.Size(315, 38);
            this.tbxComment.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Примечание:";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(240, 198);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 15;
            this.btnAccept.Text = "Применить";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(354, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(451, 233);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tbxComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxBarcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.tbxProductName);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.btnAddMaker);
            this.Controls.Add(this.cbxMakers);
            this.Controls.Add(this.lblMaker);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.cbxTypes);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.cbxCategory);
            this.Controls.Add(this.lblCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProductForm";
            this.Text = "Продукт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.ComboBox cbxTypes;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnAddMaker;
        private System.Windows.Forms.ComboBox cbxMakers;
        private System.Windows.Forms.Label lblMaker;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.TextBox tbxBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox tbxComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}