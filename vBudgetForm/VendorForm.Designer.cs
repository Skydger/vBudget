namespace vBudgetForm
{
    partial class VendorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection = null;
        private System.Data.DataTable companies = null;
        private System.Data.DataRow vendor = null;
        private bool isNewVendor = false;
        private byte[] image = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendorForm));
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.cmsPictureMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiLoadPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeletePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cbxTypes = new System.Windows.Forms.ComboBox();
            this.btnAddType = new System.Windows.Forms.Button();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tbxPhones = new System.Windows.Forms.TextBox();
            this.lblPhones = new System.Windows.Forms.Label();
            this.tbxPTI = new System.Windows.Forms.TextBox();
            this.lblPTI = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxWeb = new System.Windows.Forms.TextBox();
            this.lblWeb = new System.Windows.Forms.Label();
            this.cbDeleted = new System.Windows.Forms.CheckBox();
            this.ofdLodaPictureDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnAddCompany = new System.Windows.Forms.Button();
            this.cbxCompanies = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.cmsPictureMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxLogo
            // 
            this.pbxLogo.ContextMenuStrip = this.cmsPictureMenu;
            this.pbxLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.ErrorImage")));
            this.pbxLogo.Location = new System.Drawing.Point(12, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(128, 128);
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // cmsPictureMenu
            // 
            this.cmsPictureMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadPicture,
            this.tsmiEditPicture,
            this.tsmiDeletePicture});
            this.cmsPictureMenu.Name = "cmsPictureMenu";
            this.cmsPictureMenu.Size = new System.Drawing.Size(164, 70);
            // 
            // tsmiLoadPicture
            // 
            this.tsmiLoadPicture.Name = "tsmiLoadPicture";
            this.tsmiLoadPicture.Size = new System.Drawing.Size(163, 22);
            this.tsmiLoadPicture.Text = "Загрузить...";
            this.tsmiLoadPicture.Click += new System.EventHandler(this.tsmiLoadPicture_Click);
            // 
            // tsmiEditPicture
            // 
            this.tsmiEditPicture.Enabled = false;
            this.tsmiEditPicture.Name = "tsmiEditPicture";
            this.tsmiEditPicture.Size = new System.Drawing.Size(163, 22);
            this.tsmiEditPicture.Text = "Редактировать...";
            // 
            // tsmiDeletePicture
            // 
            this.tsmiDeletePicture.Name = "tsmiDeletePicture";
            this.tsmiDeletePicture.Size = new System.Drawing.Size(163, 22);
            this.tsmiDeletePicture.Text = "Удалить";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(146, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Название: ";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(218, 58);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(350, 20);
            this.tbxName.TabIndex = 4;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(146, 34);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Тип:  ";
            // 
            // cbxTypes
            // 
            this.cbxTypes.FormattingEnabled = true;
            this.cbxTypes.Location = new System.Drawing.Point(218, 31);
            this.cbxTypes.Name = "cbxTypes";
            this.cbxTypes.Size = new System.Drawing.Size(319, 21);
            this.cbxTypes.TabIndex = 2;
            // 
            // btnAddType
            // 
            this.btnAddType.Location = new System.Drawing.Point(543, 30);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(25, 23);
            this.btnAddType.TabIndex = 15;
            this.btnAddType.Text = "...";
            this.btnAddType.UseVisualStyleBackColor = true;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(218, 84);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(350, 20);
            this.tbxAddress.TabIndex = 6;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(146, 87);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(47, 13);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Адрес:  ";
            // 
            // tbxPhones
            // 
            this.tbxPhones.Location = new System.Drawing.Point(218, 110);
            this.tbxPhones.Name = "tbxPhones";
            this.tbxPhones.Size = new System.Drawing.Size(350, 20);
            this.tbxPhones.TabIndex = 8;
            // 
            // lblPhones
            // 
            this.lblPhones.AutoSize = true;
            this.lblPhones.Location = new System.Drawing.Point(146, 113);
            this.lblPhones.Name = "lblPhones";
            this.lblPhones.Size = new System.Drawing.Size(72, 13);
            this.lblPhones.TabIndex = 7;
            this.lblPhones.Text = "Телефон(ы): ";
            // 
            // tbxPTI
            // 
            this.tbxPTI.Location = new System.Drawing.Point(218, 136);
            this.tbxPTI.Name = "tbxPTI";
            this.tbxPTI.Size = new System.Drawing.Size(350, 20);
            this.tbxPTI.TabIndex = 10;
            // 
            // lblPTI
            // 
            this.lblPTI.AutoSize = true;
            this.lblPTI.Location = new System.Drawing.Point(146, 139);
            this.lblPTI.Name = "lblPTI";
            this.lblPTI.Size = new System.Drawing.Size(40, 13);
            this.lblPTI.TabIndex = 9;
            this.lblPTI.Text = "ИНН:  ";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(218, 187);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Применить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(493, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbxWeb
            // 
            this.tbxWeb.Location = new System.Drawing.Point(218, 162);
            this.tbxWeb.Name = "tbxWeb";
            this.tbxWeb.Size = new System.Drawing.Size(350, 20);
            this.tbxWeb.TabIndex = 12;
            // 
            // lblWeb
            // 
            this.lblWeb.AutoSize = true;
            this.lblWeb.Location = new System.Drawing.Point(146, 165);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(40, 13);
            this.lblWeb.TabIndex = 11;
            this.lblWeb.Text = "Сайт:  ";
            // 
            // cbDeleted
            // 
            this.cbDeleted.AutoSize = true;
            this.cbDeleted.Enabled = false;
            this.cbDeleted.Location = new System.Drawing.Point(12, 191);
            this.cbDeleted.Name = "cbDeleted";
            this.cbDeleted.Size = new System.Drawing.Size(64, 17);
            this.cbDeleted.TabIndex = 16;
            this.cbDeleted.Text = "Удалён";
            this.cbDeleted.UseVisualStyleBackColor = true;
            // 
            // btnAddCompany
            // 
            this.btnAddCompany.Location = new System.Drawing.Point(543, 3);
            this.btnAddCompany.Name = "btnAddCompany";
            this.btnAddCompany.Size = new System.Drawing.Size(25, 23);
            this.btnAddCompany.TabIndex = 19;
            this.btnAddCompany.Text = "...";
            this.btnAddCompany.UseVisualStyleBackColor = true;
            // 
            // cbxCompanies
            // 
            this.cbxCompanies.FormattingEnabled = true;
            this.cbxCompanies.Location = new System.Drawing.Point(284, 4);
            this.cbxCompanies.Name = "cbxCompanies";
            this.cbxCompanies.Size = new System.Drawing.Size(253, 21);
            this.cbxCompanies.TabIndex = 18;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(146, 7);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(132, 13);
            this.lblCompany.TabIndex = 17;
            this.lblCompany.Text = "Родительская компания";
            // 
            // VendorForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(580, 222);
            this.Controls.Add(this.btnAddCompany);
            this.Controls.Add(this.cbxCompanies);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cbDeleted);
            this.Controls.Add(this.tbxWeb);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblWeb);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tbxPTI);
            this.Controls.Add(this.tbxPhones);
            this.Controls.Add(this.lblPTI);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.lblPhones);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.cbxTypes);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.pbxLogo);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VendorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Карточка продавца";
            this.Load += new System.EventHandler(this.VendorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.cmsPictureMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cbxTypes;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox tbxPhones;
        private System.Windows.Forms.Label lblPhones;
        private System.Windows.Forms.TextBox tbxPTI;
        private System.Windows.Forms.Label lblPTI;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxWeb;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.CheckBox cbDeleted;
        private System.Windows.Forms.ContextMenuStrip cmsPictureMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadPicture;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditPicture;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeletePicture;
        private System.Windows.Forms.OpenFileDialog ofdLodaPictureDialog;
        private System.Windows.Forms.Button btnAddCompany;
        private System.Windows.Forms.ComboBox cbxCompanies;
        private System.Windows.Forms.Label lblCompany;
    }
}