using System;
using System.Collections.Generic;
using System.Text;

namespace Purchases
{
    public class ReceiptContent{
        // подготовка параметров для SqlCommand таблицы состава чека
        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command){
            command.Parameters.Add("@Receipt", System.Data.SqlDbType.Int, sizeof(int), "ReceiptID");
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
            string sQuery = "UPDATE Purchases.ReceiptContents SET ReceiptID = @Receipt, ProductID = @Product,\n" +
                            "       Amount = @Amount, Price = @Price, Discount = @Dicount, Units = @Units,\n" +
                            "       Buyer = @Buyer, Receiver = @Receiver\n" +
                            "WHERE ContentID = @ContentId";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            cmd.Parameters.Add("@ContentId", System.Data.SqlDbType.Int, 0, "ContentID");
            cmd = ReceiptContent.AddParameters(cmd);
            return cmd;
        }

        public static System.Data.SqlClient.SqlCommand InsertCommand(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO Purchases.ReceiptContents\n" +
                            "           (ReceiptID, ProductID, Amount, Price, Discount, Units,\n" +
                            "            Buyer, Receiver)\n" +
                            "VALUES (@Receipt, @Product, @Amount, @Price, @Dicount, @Units, @Buyer, @Receiver)";
            cmd.Parameters.Add("@ContentId", System.Data.SqlDbType.Int, 0, "ContentID");
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            cmd = ReceiptContent.AddParameters(cmd);
            return cmd;
        }
    }
}
