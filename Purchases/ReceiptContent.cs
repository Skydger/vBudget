using System;
using System.Collections.Generic;
using System.Text;

namespace Purchases
{
    public class ReceiptContent{
        // подготовка параметров для SqlCommand таблицы состава чека
        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command){
            command.Parameters.Add("@ContentId", System.Data.SqlDbType.UniqueIdentifier, 0, "ContentID");
            command.Parameters.Add("@Receipt", System.Data.SqlDbType.UniqueIdentifier, 0, "ReceiptID");
            command.Parameters.Add("@Position", System.Data.SqlDbType.Int, sizeof(int), "Position");
            command.Parameters.Add("@Product", System.Data.SqlDbType.Int, sizeof(int), "ProductID");
            command.Parameters.Add("@Amount", System.Data.SqlDbType.Decimal, 0, "Amount");
            command.Parameters.Add("@Price", System.Data.SqlDbType.Decimal, 0, "Price");
            command.Parameters.Add("@Dicount", System.Data.SqlDbType.Decimal, 0, "Discount");
            command.Parameters.Add("@Units", System.Data.SqlDbType.NVarChar, 0, "Units");
            command.Parameters.Add("@Buyer", System.Data.SqlDbType.Int, 0, "Buyer");
            command.Parameters.Add("@Receiver", System.Data.SqlDbType.Int, 0, "Receiver");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand UpdateCommand(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "UPDATE Purchases.ReceiptContents SET ReceiptID = @Receipt, Position = @Position,\n"+
                            "       ProductID = @Product, Amount = @Amount, Price = @Price, Discount = @Dicount,\n"+
                            "       Units = @Units, Buyer = @Buyer, Receiver = @Receiver\n" +
                            "WHERE ContentID = @ContentId";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            cmd.Parameters.Add("@ContentId", System.Data.SqlDbType.UniqueIdentifier, 0, "ContentID");
            cmd = ReceiptContent.AddParameters(cmd);
            return cmd;
        }

        public static System.Data.SqlClient.SqlCommand InsertCommand(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO Purchases.ReceiptContents\n" +
                            "           (ReceiptID, Position, ProductID, Amount, Price, Discount, Units,\n" +
                            "            Buyer, Receiver)\n" +
                            "VALUES (@Receipt, @Position, @Product, @Amount, @Price, @Dicount, @Units, @Buyer, @Receiver)";
            //cmd.Parameters.Add("@ContentId", System.Data.SqlDbType.UniqueIdentifier, 0, "ContentID");
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            cmd = ReceiptContent.AddParameters(cmd);
            return cmd;
        }

        public static System.Data.SqlClient.SqlCommand DeleteCommand()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "DELETE FROM Purchases.ReceiptContents\n" +
                            " WHERE ContentID = @ContentId";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            cmd.Parameters.Add("@ContentId", System.Data.SqlDbType.Int, 0, "ContentID");
            cmd = ReceiptContent.AddParameters(cmd);
            return cmd;
        }
        public static System.Data.SqlClient.SqlCommand DeleteAllCommand()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "DELETE FROM Purchases.ReceiptContents\n" +
                            " WHERE ReceiptID = @Receipt";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            cmd.Parameters.Add("@Receipt", System.Data.SqlDbType.Int, sizeof(int), "ReceiptID");
            cmd = ReceiptContent.AddParameters(cmd);
            return cmd;
        }

        public static System.Data.SqlClient.SqlCommand ExistsCommand(int ProductID)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string query = "SELECT *\n" +
                           "  FROM Producer.Products AS p\n" +
                           "  JOIN Purchases.ReceiptContents AS c\n" +
                           "    ON c.ProductID = p.ProductID\n" +
                           "  JOIN Purchases.Receipts AS r\n" +
                           "    ON r.ReceiptID = c.ReceiptID\n" +
                           " WHERE p.ProductID = @ProductID";

            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            return cmd;
        }

        public static bool ChangeProduct( System.Data.SqlClient.SqlConnection connection,
                                          System.Data.SqlClient.SqlTransaction tran,
                                          object old_product_id, object new_product_id, out string error)
        {
            bool done = false;
            error = "";
            try
            {
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string query = "UPDATE Purchases.ReceiptContents SET ProductID = @NewProduct\n" +
                                "WHERE ProductID = @OldProduct";
                cmd.Parameters.AddWithValue("@NewProduct", new_product_id);
                cmd.Parameters.AddWithValue("@OldProduct", old_product_id);
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = connection;
                if (tran != null) cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                connection.Close();
                done = true;
            }
            catch (System.Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }

            return done;
        }

    }
}
