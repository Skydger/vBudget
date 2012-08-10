using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
 //           "SELECT  rc.ProductID, p.ProductName, SUM(Amount)
 // FROM Purchases.ReceiptContents AS rc
 // JOIN Producer.Products AS p
 //   ON p.ProductID = rc.ProductID
 //GROUP BY rc.ProductID, p.ProductName
 //ORDER BY 3 DESC"
        }
    }
}