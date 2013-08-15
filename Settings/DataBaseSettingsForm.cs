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
        public string DefaultLanguage
        {
            get { return this.sDefaultLanguage; }
            set { this.sDefaultLanguage = value; }
        }

        public DataBaseSettingsForm()
        {
            this.InitializeComponent();
        }
        private void DataBaseSettingsForm_Load(object sender, EventArgs e){
            this.CheckSettings();
        }

        protected void CheckSettings(){
            this.cbServer.Items.Clear();
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

            this.cbxLanguage.Items.Clear();
            this.cbxLanguage.Items.Add("Русский");
            this.cbxLanguage.Items.Add("English");
            this.cbxLanguage.SelectedIndex = (this.sDefaultLanguage == "ru-RU" ? 0 : 1);

            System.Globalization.CultureInfo nс = new System.Globalization.CultureInfo(this.sDefaultLanguage);
            System.Threading.Thread.CurrentThread.CurrentCulture = nс;
            System.Threading.Thread.CurrentThread.CurrentUICulture = nс;

            System.Resources.ResourceManager manager = new System.Resources.ResourceManager("Settings.SettingsResource", System.Reflection.Assembly.GetExecutingAssembly());
            this.Text = manager.GetString("Main.Name");
            this.tcSettingsControl.TabPages[0].Text = manager.GetString("Tab.CS.Name");
            this.tcSettingsControl.TabPages[1].Text = manager.GetString("Tab.IS.Name");

            this.lblAuthSettings.Text = manager.GetString("Tab.CS.AuthType");
            this.lblServer.Text = manager.GetString("Tab.CS.Server");
            this.cbIntegratedSecurity.Text = manager.GetString("Tab.CS.IntegratedAuth");

            this.lblLogin.Text = manager.GetString("Tab.CS.User");
            this.lblPassword.Text = manager.GetString("Tab.CS.Password");
            this.lblDataBase.Text = manager.GetString("Tab.CS.DefaultDatabase");

            this.lblLanguage.Text = manager.GetString("Tab.IS.Language");
            
            this.btnOk.Text = manager.GetString("Main.Apply");
            this.btnCancel.Text = manager.GetString("Main.Cancel");
            return;
        }
        private void btnOk_Click(object sender, EventArgs e){
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
            //this.lblServer.Enabled = !this.cbIntegratedSecurity.Checked;
            //this.cbServer.Enabled = !this.cbIntegratedSecurity.Checked;
            this.lblLogin.Enabled = !this.cbIntegratedSecurity.Checked;
            this.tbUser.Enabled = !this.cbIntegratedSecurity.Checked;
            this.lblPassword.Enabled = !this.cbIntegratedSecurity.Checked;
            this.tbPassword.Enabled = !this.cbIntegratedSecurity.Checked;
            this.lblDataBase.Enabled = !this.cbIntegratedSecurity.Checked;
            this.cbDataBases.Enabled = !this.cbIntegratedSecurity.Checked;
        }

        private void cbServer_Validated(object sender, EventArgs e){
            string server = this.cbServer.Text;
            if (this.cbServer.Items.Contains(server)){
                this.cbServer.Items.Remove(server);
            }
            this.cbServer.Items.Insert(0, server);
            return;
        }

        protected void ChangeAuthType( bool isSqlServer ){
//            this.rbNativeAuthorization.Checked = isSqlServer;
            this.cbIntegratedSecurity.Enabled = isSqlServer;
            //this.lblServer.Enabled = isSqlServer;
            //this.cbServer.Enabled = isSqlServer;
            this.lblLogin.Enabled = isSqlServer;
            this.tbUser.Enabled = isSqlServer;
            this.lblPassword.Enabled = isSqlServer;
            this.tbPassword.Enabled = isSqlServer;
            this.lblDataBase.Enabled = isSqlServer;
            this.cbDataBases.Enabled = isSqlServer;
        }
        private void rbABBYYAuthorizer_CheckedChanged(object sender, EventArgs e){

            this.ChangeAuthType(true);
        }

        private bool GetDatabase()
        {
            bool done = false;
            try
            {
                System.Data.SqlClient.SqlConnectionStringBuilder sqlConnBuilder =
                        new System.Data.SqlClient.SqlConnectionStringBuilder();
                sqlConnBuilder.DataSource = this.cbServer.Text;
                if (this.cbIntegratedSecurity.Checked)
                {
                    sqlConnBuilder.IntegratedSecurity = this.cbIntegratedSecurity.Checked;
                }
                else
                {
                    sqlConnBuilder.UserID = this.tbUser.Text;
                    sqlConnBuilder.Password = this.tbPassword.Text;
                }
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(sqlConnBuilder.ConnectionString);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_databases";
                conn.Open();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                string sel_db = this.cbDataBases.Text;
                this.cbDataBases.Items.Clear();
                int sel = -1;
                while (reader.Read())
                {
                    string db_name = (string)reader["DATABASE_NAME"];
                    int idx = this.cbDataBases.Items.Add(db_name);
                    if (sel_db == db_name)
                        sel = idx;
                }
                this.cbDataBases.SelectedIndex = sel;
                done = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return done;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.GetDatabase();
            return;
        }

        private void cbxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO
            this.sDefaultLanguage = (this.cbxLanguage.SelectedIndex == 0 ? "ru-RU" : "en-US");
        }

    }
}