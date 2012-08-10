namespace vBudgetForm
{
    partial class EditDiscountCardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection;
        private System.Data.DataTable vendors = null;
        private System.Data.DataTable users = null;
        private System.Data.DataRow card;
        private bool is_new = false;

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
            this.lblVendor = new System.Windows.Forms.Label();
            this.cbxVendors = new System.Windows.Forms.ComboBox();
            this.cbxUsers = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDiscountCardName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxNumber = new System.Windows.Forms.TextBox();
            this.lblDiscountCardNumber = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.nudPercents = new System.Windows.Forms.NumericUpDown();
            this.lblDiscountType = new System.Windows.Forms.Label();
            this.cbxDiscountType = new System.Windows.Forms.ComboBox();
            this.lblSince = new System.Windows.Forms.Label();
            this.dtpSince = new System.Windows.Forms.DateTimePicker();
            this.cbxExpired = new System.Windows.Forms.CheckBox();
            this.btnNewVendor = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(12, 9);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(63, 13);
            this.lblVendor.TabIndex = 0;
            this.lblVendor.Text = "��������: ";
            // 
            // cbxVendors
            // 
            this.cbxVendors.FormattingEnabled = true;
            this.cbxVendors.Location = new System.Drawing.Point(91, 6);
            this.cbxVendors.Name = "cbxVendors";
            this.cbxVendors.Size = new System.Drawing.Size(284, 21);
            this.cbxVendors.TabIndex = 1;
            // 
            // cbxUsers
            // 
            this.cbxUsers.FormattingEnabled = true;
            this.cbxUsers.Location = new System.Drawing.Point(91, 33);
            this.cbxUsers.Name = "cbxUsers";
            this.cbxUsers.Size = new System.Drawing.Size(284, 21);
            this.cbxUsers.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 36);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(62, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "��������: ";
            // 
            // lblDiscountCardName
            // 
            this.lblDiscountCardName.AutoSize = true;
            this.lblDiscountCardName.Location = new System.Drawing.Point(13, 65);
            this.lblDiscountCardName.Name = "lblDiscountCardName";
            this.lblDiscountCardName.Size = new System.Drawing.Size(63, 13);
            this.lblDiscountCardName.TabIndex = 4;
            this.lblDiscountCardName.Text = "��������: ";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(91, 62);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(310, 20);
            this.tbxName.TabIndex = 5;
            // 
            // tbxNumber
            // 
            this.tbxNumber.Location = new System.Drawing.Point(91, 88);
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.Size = new System.Drawing.Size(310, 20);
            this.tbxNumber.TabIndex = 7;
            // 
            // lblDiscountCardNumber
            // 
            this.lblDiscountCardNumber.AutoSize = true;
            this.lblDiscountCardNumber.Location = new System.Drawing.Point(13, 91);
            this.lblDiscountCardNumber.Name = "lblDiscountCardNumber";
            this.lblDiscountCardNumber.Size = new System.Drawing.Size(81, 13);
            this.lblDiscountCardNumber.TabIndex = 6;
            this.lblDiscountCardNumber.Text = "����� �����: ";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(245, 168);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "���������";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(326, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "������";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(13, 120);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(56, 13);
            this.lblPercent.TabIndex = 10;
            this.lblPercent.Text = "�������: ";
            // 
            // nudPercents
            // 
            this.nudPercents.DecimalPlaces = 2;
            this.nudPercents.Location = new System.Drawing.Point(91, 116);
            this.nudPercents.Name = "nudPercents";
            this.nudPercents.Size = new System.Drawing.Size(54, 20);
            this.nudPercents.TabIndex = 11;
            // 
            // lblDiscountType
            // 
            this.lblDiscountType.AutoSize = true;
            this.lblDiscountType.Location = new System.Drawing.Point(183, 120);
            this.lblDiscountType.Name = "lblDiscountType";
            this.lblDiscountType.Size = new System.Drawing.Size(66, 13);
            this.lblDiscountType.TabIndex = 12;
            this.lblDiscountType.Text = "��� �����: ";
            // 
            // cbxDiscountType
            // 
            this.cbxDiscountType.FormattingEnabled = true;
            this.cbxDiscountType.Items.AddRange(new object[] {
            "����������",
            "�������������"});
            this.cbxDiscountType.Location = new System.Drawing.Point(255, 116);
            this.cbxDiscountType.Name = "cbxDiscountType";
            this.cbxDiscountType.Size = new System.Drawing.Size(146, 21);
            this.cbxDiscountType.TabIndex = 13;
            // 
            // lblSince
            // 
            this.lblSince.AutoSize = true;
            this.lblSince.Location = new System.Drawing.Point(13, 150);
            this.lblSince.Name = "lblSince";
            this.lblSince.Size = new System.Drawing.Size(52, 13);
            this.lblSince.TabIndex = 14;
            this.lblSince.Text = "������: ";
            // 
            // dtpSince
            // 
            this.dtpSince.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpSince.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSince.Location = new System.Drawing.Point(91, 146);
            this.dtpSince.Name = "dtpSince";
            this.dtpSince.Size = new System.Drawing.Size(130, 20);
            this.dtpSince.TabIndex = 15;
            // 
            // cbxExpired
            // 
            this.cbxExpired.AutoSize = true;
            this.cbxExpired.Location = new System.Drawing.Point(16, 172);
            this.cbxExpired.Name = "cbxExpired";
            this.cbxExpired.Size = new System.Drawing.Size(167, 17);
            this.cbxExpired.TabIndex = 16;
            this.cbxExpired.Text = "���� �������� ����� ����";
            this.cbxExpired.UseVisualStyleBackColor = true;
            // 
            // btnNewVendor
            // 
            this.btnNewVendor.Location = new System.Drawing.Point(381, 4);
            this.btnNewVendor.Name = "btnNewVendor";
            this.btnNewVendor.Size = new System.Drawing.Size(24, 24);
            this.btnNewVendor.TabIndex = 17;
            this.btnNewVendor.Text = "...";
            this.btnNewVendor.UseVisualStyleBackColor = true;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(381, 32);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(24, 24);
            this.btnNewUser.TabIndex = 18;
            this.btnNewUser.Text = "...";
            this.btnNewUser.UseVisualStyleBackColor = true;
            // 
            // EditDiscountCardForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 200);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.btnNewVendor);
            this.Controls.Add(this.cbxExpired);
            this.Controls.Add(this.dtpSince);
            this.Controls.Add(this.lblSince);
            this.Controls.Add(this.cbxDiscountType);
            this.Controls.Add(this.lblDiscountType);
            this.Controls.Add(this.nudPercents);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tbxNumber);
            this.Controls.Add(this.lblDiscountCardNumber);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblDiscountCardName);
            this.Controls.Add(this.cbxUsers);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.cbxVendors);
            this.Controls.Add(this.lblVendor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditDiscountCardForm";
            this.Text = "EditDiscountCardForm";
            this.Load += new System.EventHandler(this.EditDiscountCardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPercents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.ComboBox cbxVendors;
        private System.Windows.Forms.ComboBox cbxUsers;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblDiscountCardName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxNumber;
        private System.Windows.Forms.Label lblDiscountCardNumber;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.NumericUpDown nudPercents;
        private System.Windows.Forms.Label lblDiscountType;
        private System.Windows.Forms.ComboBox cbxDiscountType;
        private System.Windows.Forms.Label lblSince;
        private System.Windows.Forms.DateTimePicker dtpSince;
        private System.Windows.Forms.CheckBox cbxExpired;
        private System.Windows.Forms.Button btnNewVendor;
        private System.Windows.Forms.Button btnNewUser;
    }
}