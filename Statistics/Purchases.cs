using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics
{
    public class Purchases{
        public static System.Data.SqlClient.SqlCommand ByMonths(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string query = "SELECT DATEPART(YEAR, r.Created) AS Year, DATEPART(MONTH, r.Created) AS Month,\n" +
                           "       SUM(rc.Amount * rc.Price * (1.0 - rc.Discount)) AS summary\n" +
                           "  FROM Purchases.Receipts AS r\n" +
                           "  JOIN Purchases.ReceiptContents AS rc\n" +
                           "    ON r.ReceiptID = rc.ReceiptID\n" +
                           " GROUP BY DATEPART(YEAR, r.Created), DATEPART(MONTH, r.Created)\n" +
                           " ORDER BY DATEPART(YEAR, r.Created), DATEPART(MONTH, r.Created)\n";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            return cmd;
        }
    }
}
