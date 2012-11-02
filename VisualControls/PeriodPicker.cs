using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualControls
{
    public partial class PeriodPicker : Form
    {
        public DateTime StartDate{
            set { this.dtpStartDate.Value = value; }
            get { return this.dtpStartDate.Value; }
        }
        public DateTime EndtDate{
            set { this.dtpEndDate.Value = value; }
            get { return this.dtpEndDate.Value; }
        }

        public PeriodPicker(){
            this.InitializeComponent();
        }

        private void PeriodPicker_Load(object sender, EventArgs e)
        {

        }

        private void btnAccapt_Click(object sender, EventArgs e){
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e){
            this.DialogResult = DialogResult.Cancel;
        }
    }
}