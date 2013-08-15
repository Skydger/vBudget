using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics
{
    public class Products{

        /*
            SELECT rc.ProductID, rc.Price, r.Vendor, v.VendorName
              FROM Purchases.ReceiptContents AS rc
        INNER JOIN Purchases.Receipts AS r
                ON r.ReceiptID = rc.ReceiptID
        INNER JOIN Purchases.Vendors AS v
                ON v.VendorID = r.Vendor
        --     WHERE rc.ProductID = 16
          ORDER BY rc.ProductID
     
            SELECT rc.ProductID, p.ProductName, COUNT(rc.ProductID), SUM(rc.Amount), AVG(rc.Price)
              FROM Purchases.ReceiptContents AS rc
        INNER JOIN Producer.Products AS p
                ON p.ProductID = rc.ProductID
        GROUP BY rc.ProductID, p.ProductName
        ORDER BY 3 DESC
        */

        public static System.Data.SqlClient.SqlCommand ProductPrices(int product){
            string sQuery = "SELECT DISTINCT v.VendorName, rc.Price, CAST(rc.Price AS VARCHAR(50)) + ' - ' + v.VendorName AS PricaAndVendor\n" +
                            "  FROM Purchases.ReceiptContents AS rc\n" +
                            " RIGHT JOIN Purchases.Receipts AS r\n" +
                            "    ON rc.ReceiptID = r.ReceiptID\n" +
                            "  JOIN Purchases.Vendors AS v\n" +
                            "    ON v.VendorID = r.Vendor\n" +
                            " WHERE ProductID = @product\n" +
                            " ORDER BY rc.Price DESC";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Parameters.AddWithValue("@product", product);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        /// <summary>
        /// SqlCommand to gain units list used in receipts
        /// </summary>
        /// <returns></returns>
        public static System.Data.SqlClient.SqlCommand UnitsList(){
            string sQuery = "SELECT DISTINCT Units\n" +
                            "  FROM Purchases.ReceiptContents\n" +
                            " ORDER BY Units DESC\n";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
    }


}
