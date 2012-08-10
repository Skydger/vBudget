using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Settings
{
    public partial class DataBaseSettingsForm : Form
    {
        public System.Collections.Specialized.StringCollection DataServers{
            get { return this.asDataServers; }
            set { this.asDataServers = value; }
        }
        public bool IsIntegratedSecurity{
            get { return this.bIntegratedSecurity; }
            set { this.bIntegratedSecurity = value; }
        }
        public string UserLogin{
            get { return this.sUserLogin; }
            set { this.sUserLogin = value; }
        }
        public string UserPassword{
            get { return this.sUserPassword; }
            set { this.sUserPassword = value; }
        }
        public string DefaultDataBase{
            get { return this.sDefaultDataBase; }
            set { this.sDefaultDataBase = value; }
        }

        public DataBaseSettingsForm()
        {
            this.InitializeComponent();
        }
        private void DataBaseSettingsForm_Load(object sender, EventArgs e){
            this.CheckSettings();
        }

        protected void CheckSettings(){
//            this.rbNativeAuthorization.Checked = true;
/*
            if ((Properties.Settings.Default.DataServers != null) && Properties.Settings.Default.DataServers.Count > 0)
            {
                foreach (string server_name in Properties.Settings.Default.DataServers){
                    this.cbServer.Items.Add(server_name);
                }
                this.cbServer.SelectedIndex = 0;
            }
            this.cbIntegratedSecurity.Checked = Properties.Settings.Default.UseIntegratedSecurity;
            this.tbUser.Text = Properties.Settings.Default.UserLogin;
            this.tbPassword.Text = Properties.Settings.Default.UserPassword;
            // TODO: загрузка списка баз
            this.cbDataBases.Text = Properties.Settings.Default.DefaultDataBase;
*/
            if ((this.asDataServers != null) && this.asDataServers.Count > 0)
            {
                foreach (string server_name in this.asDataServers){
                    this.cbServer.Items.Add(server_name);
                }
                this.cbServer.SelectedIndex = 0;
            }
            this.cbIntegratedSecurity.Checked = this.bIntegratedSecurity;
            this.tbUser.Text = this.sUserLogin;
            this.tbPassword.Text = this.sUserPassword;
            // TODO: загрузка списка баз
            this.cbDataBases.Text = this.sDefaultDataBase;
        }
        private void btnOk_Click(object sender, EventArgs e){
/*
//            Properties.Settings.Default.UseABBYAuthorizer = this.rbABBYYAuthorizer.Checked;
            Properties.Settings.Default.UseIntegratedSecurity = this.cbIntegratedSecurity.Checked;

            if (Properties.Settings.Default.DataServers != null)
                Properties.Settings.Default.DataServers.Clear();
            else
                Properties.Settings.Default.DataServers = new System.Collections.Specialized.StringCollection();
            foreach ( string server_name in this.cbServer.Items){
                Properties.Settings.Default.DataServers.Add(server_name);
            }
            Properties.Settings.Default.UserLogin = this.tbUser.Text;
            Properties.Settings.Default.UserPassword = this.tbPassword.Text;
            Properties.Settings.Default.DefaultDataBase = this.cbDataBases.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
 */

            this.bIntegratedSecurity = this.cbIntegratedSecurity.Checked;

            if (this.asDataServers != null)
                this.asDataServers.Clear();
            else
                this.asDataServers = new System.Collections.Specialized.StringCollection();
            foreach (string server_name in this.cbServer.Items){
                this.asDataServers.Add(server_name);
            }
            this.sUserLogin = this.tbUser.Text;
            this.sUserPassword = this.tbPassword.Text;
            this.sDefaultDataBase = this.cbDataBases.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void rbNativeAuthorization_Click(object sender, EventArgs e){
        }

        private void cbIntegratedSecurity_CheckedChanged(object sender, EventArgs e){
            this.lblServer.Enabled = !this.cbIntegratedSecurity.Checked;
            this.cbServer.Enabled = !this.cbIntegratedSecurity.Checked;
            this.lblLogin.Enabled = !this.cbIntegratedSecurity.Checked;
            this.tbUser.Enabled = !this.cbIntegratedSecurity.Checked;
            this.lblPassword.Enabled = !this.cbIntegratedSecurity.Checked;
            this.tbPassword.Enabled = !this.cbIntegratedSecurity.Checked;
            this.lblDataBase.Enabled = !this.cbIntegratedSecurity.Checked;
            this.cbDataBases.Enabled = !this.cbIntegratedSecurity.Checked;
        }

        private void cbServer_Validated(object sender, EventArgs e)
        {
            if (!this.cbServer.Items.Contains(this.cbServer.Text)){
                this.cbServer.Items.Insert(0, this.cbServer.Text);
            }
        }

        protected void ChangeAuthType( bool isSqlServer ){
//            this.rbABBYYAuthorizer.Checked = !isSqlServer;
//            this.rbNativeAuthorization.Checked = isSqlServer;
            this.cbIntegratedSecurity.Enabled = isSqlServer;
            this.lblServer.Enabled = isSqlServer;
            this.cbServer.Enabled = isSqlServer;
            this.lblLogin.Enabled = isSqlServer;
            this.tbUser.Enabled = isSqlServer;
            this.lblPassword.Enabled = isSqlServer;
            this.tbPassword.Enabled = isSqlServer;
            this.lblDataBase.Enabled = isSqlServer;
            this.cbDataBases.Enabled = isSqlServer;
        }
        private void rbABBYYAuthorizer_CheckedChanged(object sender, EventArgs e){
//            this.ChangeAuthType(!this.rbABBYYAuthorizer.Checked);
            this.ChangeAuthType(true);
        }

    }
}