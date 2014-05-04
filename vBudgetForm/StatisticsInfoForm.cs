using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class StatisticsInfoForm : Form
    {
        public StatisticsInfoForm(System.Data.SqlClient.SqlConnection connection, Guid receipt)
        {
            InitializeComponent();
            this.connection = connection;
            this.receipt = receipt;
        }

        private void StatisticsForm_Resize(object sender, EventArgs e)
        {
            this.dgvData.Size = new Size(this.Width - 22, this.Height - 93);
            this.btnOk.Location = new Point(this.Width/2 - this.btnOk.Width/2, this.Height - 65);
        }

        private void StatisticsInfoForm_Load(object sender, EventArgs e)
        {
            this.ReloadStatistics();
        }

        private void ReloadStatistics()
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            string d_member = "";
            string v_member = "";
            if(this.tsmiByReceiver.Checked){
                cmd = Statistics.Contents.ByReceiver(this.receipt, out d_member, out v_member);
            }
            else if (this.tsmiByBuyer.Checked)
            {
                cmd = Statistics.Contents.ByBuyer(this.receipt, out d_member, out v_member);
            }else if( this.tsmiByProductTypes.Checked){
                cmd = Statistics.Contents.ByProductTypes(this.receipt, out d_member, out v_member);
            }
            else if (this.tsmiByCategories.Checked)
            {
                cmd = Statistics.Contents.ByCategories(this.receipt, out d_member, out v_member);
            }
            if (cmd != null)
            {
                System.Data.DataTable content_stat = new DataTable("ContentsStatistics");
                cmd.Connection = this.connection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                sda.Fill(content_stat);
                this.dgvData.DataSource = content_stat;
                this.dgvData.Columns[d_member].DisplayIndex = 0;
                this.dgvData.Columns[v_member].DisplayIndex = 1;
            }
            else
            {
                MessageBox.Show("Не выбрано ни одного критерия!", "Ошибка");
            }
            return;
        }

        private void tsmiByCategories_Click(object sender, EventArgs e)
        {
            this.tsmiByReceiver.Checked = false;
            this.tsmiByProductTypes.Checked = false;
            this.tsmiByCategories.Checked = true;
            this.tsmiByBuyer.Checked = false;
            this.ReloadStatistics();
        }

        private void tsmiByProductTypes_Click(object sender, EventArgs e)
        {
            this.tsmiByReceiver.Checked = false;
            this.tsmiByProductTypes.Checked = true;
            this.tsmiByCategories.Checked = false;
            this.tsmiByBuyer.Checked = false;
            this.ReloadStatistics();
        }

        private void tsmiByPersons_Click(object sender, EventArgs e)
        {
            this.tsmiByReceiver.Checked = true;
            this.tsmiByProductTypes.Checked = false;
            this.tsmiByCategories.Checked = false;
            this.tsmiByBuyer.Checked = false;
            this.ReloadStatistics();
        }
        private void tsmiByBuyer_Click(object sender, EventArgs e)
        {
            this.tsmiByReceiver.Checked = false;
            this.tsmiByProductTypes.Checked = false;
            this.tsmiByCategories.Checked = false;
            this.tsmiByBuyer.Checked = true;
            this.ReloadStatistics();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


    }
}
