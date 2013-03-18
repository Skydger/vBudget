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


        public static System.Data.SqlClient.SqlCommand ByWeeks()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string query = "SELECT DATEPART(YEAR, r.Created) AS Year, DATEPART(WEEK, r.Created) AS Week,\n" +
                           "       (DATEPART(WEEK, r.Created)%4 * 7 + 7 ) AS SumDay,\n" +
                           "       SUM(rc.Amount * rc.Price * (1.0 - rc.Discount)) AS summary\n" +
                           "  FROM Purchases.Receipts AS r\n" +
                           "  JOIN Purchases.ReceiptContents AS rc\n" +
                           "    ON r.ReceiptID = rc.ReceiptID\n" +
                           " GROUP BY DATEPART(YEAR, r.Created), DATEPART(WEEK, r.Created)\n" +
                           " ORDER BY DATEPART(YEAR, r.Created), DATEPART(WEEK, r.Created)";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            return cmd;
        }
        public static System.Data.SqlClient.SqlCommand ByVendorsPerMonth( List<int> vendors_ids )
        {
            string where = "";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            if ((vendors_ids != null) && (vendors_ids.Count > 0))
            {
                string[] parameters = new string[vendors_ids.Count];
                for (int i = 0; i < vendors_ids.Count; i++)
                {
                    parameters[i] = string.Format("@Vendor{0}", i);
                    cmd.Parameters.AddWithValue(parameters[i], vendors_ids[i]);
                }
                where += string.Format("WHERE r.Vendor IN( {0} )\n", string.Join(", ", parameters));
            }
            string query = "SELECT DATEPART(YEAR, r.Created) AS Year, DATEPART(MONTH, r.Created) AS Month,\n" +
                           "       r.Vendor, v.VendorName, SUM(rc.Amount * rc.Price * (1.0 - rc.Discount)) AS summary\n" +
                           "  FROM Purchases.Receipts AS r\n" +
                           "  JOIN Purchases.ReceiptContents AS rc\n" +
                           "    ON r.ReceiptID = rc.ReceiptID\n" +
                           "  JOIN Purchases.Vendors AS v\n" +
                           "    ON v.VendorID = r.Vendor\n" +
                           where +
                           " GROUP BY DATEPART(YEAR, r.Created), DATEPART(MONTH, r.Created), r.Vendor, v.VendorName\n" +
                           " ORDER BY DATEPART(YEAR, r.Created), DATEPART(MONTH, r.Created), r.Vendor, v.VendorName";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            return cmd;

        }
    }
}
