using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics
{
    public class Contents
    {
        public static System.Data.SqlClient.SqlCommand ByCategories(Guid receipt_id, out string display_member, out string value_member)
        {
            display_member = "CategoryName";
            value_member = "Spent";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string where = "";
            if (receipt_id != Guid.Empty)
            {
                where = " WHERE rc.ReceiptID = @ReceiptID\n";
                cmd.Parameters.AddWithValue("@ReceiptID", receipt_id);
            }
            string query = "SELECT c.CategoryName, SUM(rc.Price * (1.0 - rc.Discount) * rc.Amount) AS Spent\n" +
                           "  FROM Purchases.ReceiptContents AS rc\n" +
                           "  JOIN Producer.Products AS p\n" +
                           "    ON p.ProductID = rc.ProductID\n" +
                           "  JOIN Producer.Categories AS c\n" +
                           "    ON c.CategoryID = p.Category\n" +
                           where +
                           " GROUP BY c.CategoryName\n" +
                           " ORDER BY 2 DESC";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            return cmd;
        }

        public static System.Data.SqlClient.SqlCommand ByProductTypes(Guid receipt_id, out string display_member, out string value_member)
        {
            display_member = "Name";
            value_member = "Spent";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string where = "";
            if (receipt_id != Guid.Empty)
            {
                where = " WHERE rc.ReceiptID = @ReceiptID\n";
                cmd.Parameters.AddWithValue("@ReceiptID", receipt_id);
            }
            string query = "SELECT pt.Name, SUM(rc.Price * (1.0 - rc.Discount) * rc.Amount) AS Spent\n" +
                           "  FROM Purchases.ReceiptContents AS rc\n" +
                           "  JOIN Producer.Products AS p\n" +
                           "    ON p.ProductID = rc.ProductID\n" +
                           "  JOIN Producer.ProductTypes AS pt\n" +
                           "    ON pt.Category = p.Category AND\n" +
                           "       pt.TypeId = p.[Type]\n" +
                           where +
                           " GROUP BY pt.Name\n" +
                           " ORDER BY 2 DESC";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            return cmd;
        }

        public static System.Data.SqlClient.SqlCommand ByReceiver(Guid receipt_id, out string display_member, out string value_member)
        {
            display_member = "UserFullName";
            value_member = "Spent";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string where = "";
            if (receipt_id != Guid.Empty)
            {
                where = " WHERE rc.ReceiptID = @ReceiptID\n";
                cmd.Parameters.AddWithValue("@ReceiptID", receipt_id);
            }
            string query = "SELECT u.Surname + ' ' + SUBSTRING(u.Name, 1,1) + '. ' +\n" +
                           "       SUBSTRING(u.SecondName, 1,1) + '.' AS UserFullName,\n" +
                           "       SUM(rc.Price * (1.0 - rc.Discount) * rc.Amount) AS Spent\n" +
                           "  FROM Purchases.ReceiptContents AS rc\n" +
                           "  JOIN Persons.Users AS u\n" +
                           "    ON u.UserID = rc.Receiver\n" +
                           where +
                           " GROUP BY u.Surname + ' ' + SUBSTRING(u.Name, 1,1) + '. ' +\n" +
                           "       SUBSTRING(u.SecondName, 1,1) + '.'\n" +
                           " ORDER BY 2 DESC";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            return cmd;
        }

        public static System.Data.SqlClient.SqlCommand ByBuyer(Guid receipt_id, out string display_member, out string value_member)
        {
            display_member = "UserFullName";
            value_member = "Spent";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string where = "";
            if (receipt_id != Guid.Empty)
            {
                where = " WHERE rc.ReceiptID = @ReceiptID\n";
                cmd.Parameters.AddWithValue("@ReceiptID", receipt_id);
            }
            string query = "SELECT u.Surname + ' ' + SUBSTRING(u.Name, 1,1) + '. ' +\n" +
                           "       SUBSTRING(u.SecondName, 1,1) + '.' AS UserFullName,\n" +
                           "       SUM(rc.Price * (1.0 - rc.Discount) * rc.Amount) AS Spent\n" +
                           "  FROM Purchases.ReceiptContents AS rc\n" +
                           "  JOIN Persons.Users AS u\n" +
                           "    ON u.UserID = rc.Buyer\n" +
                           where +
                           " GROUP BY u.Surname + ' ' + SUBSTRING(u.Name, 1,1) + '. ' +\n" +
                           "       SUBSTRING(u.SecondName, 1,1) + '.'\n" +
                           " ORDER BY 2 DESC";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            return cmd;
        }
    }
}
