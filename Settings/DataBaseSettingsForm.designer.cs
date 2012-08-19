namespace Settings
{
    partial class DataBaseSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Collections.Specialized.StringCollection asDataServers = null;
        private bool bIntegratedSecurity = false;
        private string sUserLogin;
        private string sUserPassword;
        private string sDefaultDataBase;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBaseSettingsForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbDataBases = new System.Windows.Forms.ComboBox();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.cbIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.lblAuthSettings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(168, 163);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Применить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(269, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbDataBases
            // 
            this.cbDataBases.FormattingEnabled = true;
            this.cbDataBases.Location = new System.Drawing.Point(168, 136);
            this.cbDataBases.Name = "cbDataBases";
            this.cbDataBases.Size = new System.Drawing.Size(176, 21);
            this.cbDataBases.TabIndex = 16;
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Location = new System.Drawing.Point(16, 139);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(146, 13);
            this.lblDataBase.TabIndex = 15;
            this.lblDataBase.Text = "База данных по умолчанию";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(168, 110);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(176, 20);
            this.tbPassword.TabIndex = 14;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 113);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(48, 13);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Пароль:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(168, 84);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(176, 20);
            this.tbUser.TabIndex = 12;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(16, 87);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(83, 13);
            this.lblLogin.TabIndex = 11;
            this.lblLogin.Text = "Пользователь:";
            // 
            // cbServer
            // 
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Location = new System.Drawing.Point(88, 29);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(256, 21);
            this.cbServer.TabIndex = 10;
            this.cbServer.Validated += new System.EventHandler(this.cbServer_Validated);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(16, 32);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(66, 13);
            this.lblServer.TabIndex = 9;
            this.lblServer.Text = "Сервер БД:";
            // 
            // cbIntegratedSecurity
            // 
            this.cbIntegratedSecurity.AutoSize = true;
            this.cbIntegratedSecurity.Location = new System.Drawing.Point(19, 61);
            this.cbIntegratedSecurity.Name = "cbIntegratedSecurity";
            this.cbIntegratedSecurity.Size = new System.Drawing.Size(305, 17);
            this.cbIntegratedSecurity.TabIndex = 17;
            this.cbIntegratedSecurity.Text = "Интегрированная авторизация (авторизация Windows)";
            this.cbIntegratedSecurity.UseVisualStyleBackColor = true;
            this.cbIntegratedSecurity.CheckedChanged += new System.EventHandler(this.cbIntegratedSecurity_CheckedChanged);
            // 
            // lblAuthSettings
            // 
            this.lblAuthSettings.AutoSize = true;
            this.lblAuthSettings.Location = new System.Drawing.Point(3, 9);
            this.lblAuthSettings.Name = "lblAuthSettings";
            this.lblAuthSettings.Size = new System.Drawing.Size(131, 13);
            this.lblAuthSettings.TabIndex = 18;
            this.lblAuthSettings.Text = "Авторизация SQL Server";
            // 
            // DataBaseSettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(353, 194);
            this.Controls.Add(this.lblAuthSettings);
            this.Controls.Add(this.cbIntegratedSecurity);
            this.Controls.Add(this.cbDataBases);
            this.Controls.Add(this.lblDataBase);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.cbServer);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataBaseSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки соединения с БД";
            this.Load += new System.EventHandler(this.DataBaseSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbDataBases;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.CheckBox cbIntegratedSecurity;
        private System.Windows.Forms.Label lblAuthSettings;
    }
}