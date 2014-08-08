namespace vBudgetForm.Froms.Digests
{
    partial class EditCompanyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection connection = null;
        private System.Data.DataRow company = null;
        private System.Data.DataRow parent = null;

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
            this.lblParentCompany = new System.Windows.Forms.Label();
            this.cbxCompanies = new System.Windows.Forms.ComboBox();
            this.btnAddParentCompany = new System.Windows.Forms.Button();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.tbxCompanyName = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tbxWebAddress = new System.Windows.Forms.TextBox();
            this.lblWebAddress = new System.Windows.Forms.Label();
            this.tbxPhones = new System.Windows.Forms.TextBox();
            this.lblPhones = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblParentCompany
            // 
            this.lblParentCompany.AutoSize = true;
            this.lblParentCompany.Location = new System.Drawing.Point(12, 9);
            this.lblParentCompany.Name = "lblParentCompany";
            this.lblParentCompany.Size = new System.Drawing.Size(132, 13);
            this.lblParentCompany.TabIndex = 0;
            this.lblParentCompany.Text = "Родительская компания";
            // 
            // cbxCompanies
            // 
            this.cbxCompanies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompanies.FormattingEnabled = true;
            this.cbxCompanies.Location = new System.Drawing.Point(154, 6);
            this.cbxCompanies.Name = "cbxCompanies";
            this.cbxCompanies.Size = new System.Drawing.Size(311, 21);
            this.cbxCompanies.TabIndex = 1;
            // 
            // btnAddParentCompany
            // 
            this.btnAddParentCompany.Location = new System.Drawing.Point(471, 4);
            this.btnAddParentCompany.Name = "btnAddParentCompany";
            this.btnAddParentCompany.Size = new System.Drawing.Size(24, 24);
            this.btnAddParentCompany.TabIndex = 2;
            this.btnAddParentCompany.Text = "...";
            this.btnAddParentCompany.UseVisualStyleBackColor = true;
            this.btnAddParentCompany.Click += new System.EventHandler(this.btnAddParentCompany_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(12, 39);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(136, 13);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "Наименование компании";
            // 
            // tbxCompanyName
            // 
            this.tbxCompanyName.Location = new System.Drawing.Point(154, 36);
            this.tbxCompanyName.Name = "tbxCompanyName";
            this.tbxCompanyName.Size = new System.Drawing.Size(341, 20);
            this.tbxCompanyName.TabIndex = 4;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(15, 152);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Применить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(420, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(82, 65);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(413, 20);
            this.tbxAddress.TabIndex = 8;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 68);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(38, 13);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Адрес";
            // 
            // tbxWebAddress
            // 
            this.tbxWebAddress.Location = new System.Drawing.Point(82, 91);
            this.tbxWebAddress.Name = "tbxWebAddress";
            this.tbxWebAddress.Size = new System.Drawing.Size(414, 20);
            this.tbxWebAddress.TabIndex = 10;
            // 
            // lblWebAddress
            // 
            this.lblWebAddress.AutoSize = true;
            this.lblWebAddress.Location = new System.Drawing.Point(13, 94);
            this.lblWebAddress.Name = "lblWebAddress";
            this.lblWebAddress.Size = new System.Drawing.Size(63, 13);
            this.lblWebAddress.TabIndex = 9;
            this.lblWebAddress.Text = "Web-адрес";
            // 
            // tbxPhones
            // 
            this.tbxPhones.Location = new System.Drawing.Point(82, 117);
            this.tbxPhones.Name = "tbxPhones";
            this.tbxPhones.Size = new System.Drawing.Size(414, 20);
            this.tbxPhones.TabIndex = 12;
            // 
            // lblPhones
            // 
            this.lblPhones.AutoSize = true;
            this.lblPhones.Location = new System.Drawing.Point(13, 120);
            this.lblPhones.Name = "lblPhones";
            this.lblPhones.Size = new System.Drawing.Size(60, 13);
            this.lblPhones.TabIndex = 11;
            this.lblPhones.Text = "Телефоны";
            // 
            // EditCompanyForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(508, 182);
            this.Controls.Add(this.tbxPhones);
            this.Controls.Add(this.lblPhones);
            this.Controls.Add(this.tbxWebAddress);
            this.Controls.Add(this.lblWebAddress);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tbxCompanyName);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.btnAddParentCompany);
            this.Controls.Add(this.cbxCompanies);
            this.Controls.Add(this.lblParentCompany);
            this.Name = "EditCompanyForm";
            this.Load += new System.EventHandler(this.EditCompanyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParentCompany;
        private System.Windows.Forms.ComboBox cbxCompanies;
        private System.Windows.Forms.Button btnAddParentCompany;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox tbxCompanyName;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox tbxWebAddress;
        private System.Windows.Forms.Label lblWebAddress;
        private System.Windows.Forms.TextBox tbxPhones;
        private System.Windows.Forms.Label lblPhones;
    }
}