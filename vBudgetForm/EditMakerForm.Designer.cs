namespace vBudgetForm
{
    partial class EditMakerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection = null;
        private System.Data.DataRow maker = null;
        private System.Data.DataTable categories = null;
        private System.Data.DataTable vendors = null;
        private object current_category = null;

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
            this.lblMakerName = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxMakerName = new System.Windows.Forms.TextBox();
            this.lblMakerCategory = new System.Windows.Forms.Label();
            this.cbxCategories = new System.Windows.Forms.ComboBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxVendors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMakerName
            // 
            this.lblMakerName.AutoSize = true;
            this.lblMakerName.Location = new System.Drawing.Point(18, 13);
            this.lblMakerName.Name = "lblMakerName";
            this.lblMakerName.Size = new System.Drawing.Size(92, 13);
            this.lblMakerName.TabIndex = 0;
            this.lblMakerName.Text = "Производитель: ";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblError.Location = new System.Drawing.Point(12, 81);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(299, 15);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "                                                                         ";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(321, 99);
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
            this.btnCancel.Location = new System.Drawing.Point(441, 99);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbxMakerName
            // 
            this.tbxMakerName.Location = new System.Drawing.Point(116, 12);
            this.tbxMakerName.Name = "tbxMakerName";
            this.tbxMakerName.Size = new System.Drawing.Size(400, 20);
            this.tbxMakerName.TabIndex = 5;
            // 
            // lblMakerCategory
            // 
            this.lblMakerCategory.AutoSize = true;
            this.lblMakerCategory.Location = new System.Drawing.Point(18, 48);
            this.lblMakerCategory.Name = "lblMakerCategory";
            this.lblMakerCategory.Size = new System.Drawing.Size(126, 13);
            this.lblMakerCategory.TabIndex = 9;
            this.lblMakerCategory.Text = "Сфера товаров и услуг:";
            // 
            // cbxCategories
            // 
            this.cbxCategories.FormattingEnabled = true;
            this.cbxCategories.Location = new System.Drawing.Point(150, 44);
            this.cbxCategories.Name = "cbxCategories";
            this.cbxCategories.Size = new System.Drawing.Size(336, 21);
            this.cbxCategories.TabIndex = 10;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(492, 43);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(24, 24);
            this.btnAddCategory.TabIndex = 11;
            this.btnAddCategory.Text = "...";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 14;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbxVendors
            // 
            this.cbxVendors.FormattingEnabled = true;
            this.cbxVendors.Location = new System.Drawing.Point(150, 72);
            this.cbxVendors.Name = "cbxVendors";
            this.cbxVendors.Size = new System.Drawing.Size(336, 21);
            this.cbxVendors.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Продавец:";
            // 
            // EditMakerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 134);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxVendors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.cbxCategories);
            this.Controls.Add(this.lblMakerCategory);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbxMakerName);
            this.Controls.Add(this.lblMakerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditMakerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditMakerForm";
            this.Load += new System.EventHandler(this.EditMakerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMakerName;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxMakerName;
        private System.Windows.Forms.Label lblMakerCategory;
        private System.Windows.Forms.ComboBox cbxCategories;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbxVendors;
        private System.Windows.Forms.Label label1;
    }
}