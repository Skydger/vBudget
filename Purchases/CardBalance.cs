using System;
using System.Collections.Generic;
using System.Text;

namespace Purchases
{
    /// <summary>
    /// Discount cards balance class
    /// </summary>
    public class CardBalance
    {
        public static string Table = "Purchases.CardBalance";

        /// <summary>
        /// Method to select discount cards' balance
        /// </summary>
        public static System.Data.SqlClient.SqlCommand Select(object card_id)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "SELECT cb.CardID, cb.OverallBalance, cb.DiscountBalance,\n" +
                            "       cb.LastReceiptID, cb.Points\n" +
                            "  FROM " + CardBalance.Table + " AS cb\n";
            if (card_id != null)
            {
                Guid cid = (Guid)card_id;
                if (cid != Guid.Empty)
                {
                    sQuery += " WHERE cb.CardID = @Card";
                    cmd.Parameters.AddWithValue("@Card", cid);
                }
            }
            else
            {
                sQuery += " WHERE cb.CardID = IS NULL";
            }
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        public static System.Data.SqlClient.SqlCommand UnpivotedSelect(Guid card_id)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string where = "";
            if (card_id != Guid.Empty)
            {
                where = "WHERE CardID = @Card";
                cmd.Parameters.AddWithValue("@Card", card_id);
            }
            string sQuery = string.Format("SELECT Names, CardData\n" +
                                          "   FROM (SELECT CardID, ISNULL(OverallBalance, 0.0) AS OverallBalance,\n" +
                                          "               ISNULL(DiscountBalance, 0.0) AS DiscountBalance,\n" +
                                          "               ISNULL(Points, 0) AS Points\n" +
                                          "          FROM [BudgetNew].[Purchases].[CardBalance]\n" +
                                          "         {0}) AS base\n" +
                                          "UNPIVOT ( CardData FOR Names IN\n" +
                                          "        ([OverallBalance], [DiscountBalance], [Points])) AS upvt", where);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command)
        {
            command.Parameters.Add("@Card", System.Data.SqlDbType.UniqueIdentifier, 0, "CardID");
            command.Parameters.Add("@OverallBalance", System.Data.SqlDbType.Decimal, 0, "OverallBalance");
            command.Parameters.Add("@DiscountBalance", System.Data.SqlDbType.Decimal, 0, "DiscountBalance");
            command.Parameters.Add("@LastReceipt", System.Data.SqlDbType.UniqueIdentifier, 0, "LastReceiptID");
            command.Parameters.Add("@Points", System.Data.SqlDbType.Decimal, 0, "Points");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand Insert()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO " + CardBalance.Table + "\n" +
                            "            (CardID, OverallBalance, DiscountBalance,\n" +
                            "             LastReceiptID, Points)\n" +
                            "     VALUES (@Card, @OverallBalance, @DiscountBalance,\n" +
                            "             @LastReceipt, @Points)\n";
            cmd = CardBalance.AddParameters(cmd);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        /// <summary>
        /// Method to insert new row into the card balance table
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="row">Database row</param>
        /// <param name="message">If method returns 'false' this parameter contains a detailed error</param>
        /// <returns>'true' if no error occurs, 'false' in other case</returns>
        public static bool Insert(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message)
        {
            bool done = false;
            message = "";
            try
            {
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "INSERT INTO " + CardBalance.Table + "\n" +
                                "            (CardID, OverallBalance, DiscountBalance,\n" +
                                "             LastReceiptID, Points)\n" +
                                "     VALUES (@Card, @OverallBalance, @DiscountBalance,\n" +
                                "             @LastReceipt, @Points)\n";
                cmd.Parameters.AddWithValue("@Card", row["CardID"]);
                cmd.Parameters.AddWithValue("@OverallBalance", row["OverallBalance"]);
                cmd.Parameters.AddWithValue("@DiscountBalance", row["DiscountBalance"]);
                cmd.Parameters.AddWithValue("@LastReceipt", row["LastReceiptID"]);
                cmd.Parameters.AddWithValue("@Points", row["Points"]);
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                cmd.ExecuteNonQuery();
                connection.Close();
                done = true;
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            return done;
        }

        public static System.Data.SqlClient.SqlCommand Update()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "UPDATE " + CardBalance.Table + "\n" +
                            "   SET OverallBalance = @OverallBalance, DiscountBalance = @DiscountBalance,\n" +
                            "       LastReceiptID = @LastReceipt, Points = @Points\n" +
                            " WHERE CardID = @Card";
            cmd = CardBalance.AddParameters(cmd);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        /// <summary>
        /// Method to update discount card's balance data
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="row">Database row</param>
        /// <param name="message">If method returns 'false' this parameter contains a detailed error</param>
        /// <returns>'true' if no error occurs, 'false' in other case</returns>
        public static bool Update(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, /*byte[] image,*/ out string message)
        {
            bool done = false;
            message = "";
            try
            {
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "UPDATE " + CardBalance.Table + "\n" +
                                "   SET OverallBalance = @OverallBalance, DiscountBalance = @DiscountBalance,\n" +
                                "       LastReceiptID = @LastReceipt, Points = @Points\n" +
                                " WHERE CardID = @Card";

                cmd.Parameters.AddWithValue("@Card", row["CardID"]);
                cmd.Parameters.AddWithValue("@OverallBalance", row["OverallBalance"]);
                cmd.Parameters.AddWithValue("@DiscountBalance", row["DiscountBalance"]);
                cmd.Parameters.AddWithValue("@LastReceiptID", row["LastReceipt"]);
                cmd.Parameters.AddWithValue("@Points", row["Points"]);
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                cmd.ExecuteNonQuery();
                connection.Close();
                done = true;
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            return done;
        }
        /// <summary>
        /// Method to get new unique identifier from database engine
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="message">If method returns 'false' this parameter contains a detailed error</param>
        /// <returns>If no error occur a new Guid, otherwise method returns Guid.Empty, </returns>
        public static Guid NewID(System.Data.SqlClient.SqlConnection connection, out string message)
        {
            Guid last_id = new Guid(0, 0, 0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            message = "";
            try
            {
                connection.Open();
                string sQuery = "SELECT NEWID() AS LastID\n" +
                                "  FROM " + CardBalance.Table;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sQuery);
                cmd.Connection = connection;
                object res = cmd.ExecuteScalar();
                if (!System.Convert.IsDBNull(res)) last_id = (Guid)res;
                connection.Close();
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            return last_id;
        }

    }
}
