using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class MakersListForm : Form
    {
        public MakersListForm( System.Data.SqlClient.SqlConnection inConnection ){
            this.InitializeComponent();
            this.cConnection = inConnection;
        }
    }
}