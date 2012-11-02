using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{

    public enum StatisticsType { Makers = 0, Vendors, Products };
    public partial class StatisticsForm : Form
    {
        public static string[] StatisticsTypeString = new string[] { "Производители", "Продавцы", "Продукты" };
       
        public StatisticsForm(System.Data.SqlClient.SqlConnection connection){
            InitializeComponent();
            this.connection = connection;
 //           "SELECT  rc.ProductID, p.ProductName, SUM(Amount)
 // FROM Purchases.ReceiptContents AS rc
 // JOIN Producer.Products AS p
 //   ON p.ProductID = rc.ProductID
 //GROUP BY rc.ProductID, p.ProductName
 //ORDER BY 3 DESC"
        }

        private void cbxEntities_SelectedIndexChanged(object sender, EventArgs e){

        }

        private void StatisticsForm_Load(object sender, EventArgs e){
            this.cbxEntities.Items.Insert(0, StatisticsTypeString[0]);
            this.cbxEntities.Items.Insert(1, StatisticsTypeString[1]);
            this.cbxEntities.Items.Insert(2, StatisticsTypeString[2]);
            this.cbxEntities.SelectedIndex = 0;
        }
    }
}