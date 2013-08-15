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
        private string sDefaultLanguage;

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
            this.tcSettingsControl = new System.Windows.Forms.TabControl();
            this.tpDbSettings = new System.Windows.Forms.TabPage();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tpInterfaceSettings = new System.Windows.Forms.TabPage();
            this.cbxLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.tcSettingsControl.SuspendLayout();
            this.tpDbSettings.SuspendLayout();
            this.tpInterfaceSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbDataBases
            // 
            this.cbDataBases.FormattingEnabled = true;
            resources.ApplyResources(this.cbDataBases, "cbDataBases");
            this.cbDataBases.Name = "cbDataBases";
            // 
            // lblDataBase
            // 
            resources.ApplyResources(this.lblDataBase, "lblDataBase");
            this.lblDataBase.Name = "lblDataBase";
            // 
            // tbPassword
            // 
            resources.ApplyResources(this.tbPassword, "tbPassword");
            this.tbPassword.Name = "tbPassword";
            // 
            // lblPassword
            // 
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.Name = "lblPassword";
            // 
            // tbUser
            // 
            resources.ApplyResources(this.tbUser, "tbUser");
            this.tbUser.Name = "tbUser";
            // 
            // lblLogin
            // 
            resources.ApplyResources(this.lblLogin, "lblLogin");
            this.lblLogin.Name = "lblLogin";
            // 
            // cbServer
            // 
            this.cbServer.FormattingEnabled = true;
            resources.ApplyResources(this.cbServer, "cbServer");
            this.cbServer.Name = "cbServer";
            this.cbServer.Validated += new System.EventHandler(this.cbServer_Validated);
            // 
            // lblServer
            // 
            resources.ApplyResources(this.lblServer, "lblServer");
            this.lblServer.Name = "lblServer";
            // 
            // cbIntegratedSecurity
            // 
            resources.ApplyResources(this.cbIntegratedSecurity, "cbIntegratedSecurity");
            this.cbIntegratedSecurity.Name = "cbIntegratedSecurity";
            this.cbIntegratedSecurity.UseVisualStyleBackColor = true;
            this.cbIntegratedSecurity.CheckedChanged += new System.EventHandler(this.cbIntegratedSecurity_CheckedChanged);
            // 
            // lblAuthSettings
            // 
            resources.ApplyResources(this.lblAuthSettings, "lblAuthSettings");
            this.lblAuthSettings.Name = "lblAuthSettings";
            // 
            // tcSettingsControl
            // 
            this.tcSettingsControl.Controls.Add(this.tpDbSettings);
            this.tcSettingsControl.Controls.Add(this.tpInterfaceSettings);
            resources.ApplyResources(this.tcSettingsControl, "tcSettingsControl");
            this.tcSettingsControl.Name = "tcSettingsControl";
            this.tcSettingsControl.SelectedIndex = 0;
            // 
            // tpDbSettings
            // 
            this.tpDbSettings.Controls.Add(this.btnBrowse);
            this.tpDbSettings.Controls.Add(this.lblAuthSettings);
            this.tpDbSettings.Controls.Add(this.cbIntegratedSecurity);
            this.tpDbSettings.Controls.Add(this.cbDataBases);
            this.tpDbSettings.Controls.Add(this.lblServer);
            this.tpDbSettings.Controls.Add(this.lblDataBase);
            this.tpDbSettings.Controls.Add(this.cbServer);
            this.tpDbSettings.Controls.Add(this.tbPassword);
            this.tpDbSettings.Controls.Add(this.lblLogin);
            this.tpDbSettings.Controls.Add(this.lblPassword);
            this.tpDbSettings.Controls.Add(this.tbUser);
            resources.ApplyResources(this.tpDbSettings, "tpDbSettings");
            this.tpDbSettings.Name = "tpDbSettings";
            this.tpDbSettings.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tpInterfaceSettings
            // 
            this.tpInterfaceSettings.Controls.Add(this.cbxLanguage);
            this.tpInterfaceSettings.Controls.Add(this.lblLanguage);
            resources.ApplyResources(this.tpInterfaceSettings, "tpInterfaceSettings");
            this.tpInterfaceSettings.Name = "tpInterfaceSettings";
            this.tpInterfaceSettings.UseVisualStyleBackColor = true;
            // 
            // cbxLanguage
            // 
            this.cbxLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.cbxLanguage, "cbxLanguage");
            this.cbxLanguage.Name = "cbxLanguage";
            this.cbxLanguage.SelectedIndexChanged += new System.EventHandler(this.cbxLanguage_SelectedIndexChanged);
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // DataBaseSettingsForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tcSettingsControl);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DataBaseSettingsForm";
            this.Load += new System.EventHandler(this.DataBaseSettingsForm_Load);
            this.tcSettingsControl.ResumeLayout(false);
            this.tpDbSettings.ResumeLayout(false);
            this.tpDbSettings.PerformLayout();
            this.tpInterfaceSettings.ResumeLayout(false);
            this.tpInterfaceSettings.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl tcSettingsControl;
        private System.Windows.Forms.TabPage tpDbSettings;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TabPage tpInterfaceSettings;
        private System.Windows.Forms.ComboBox cbxLanguage;
        private System.Windows.Forms.Label lblLanguage;
    }
}