using System;
using System.Collections.Generic;
using System.Text;

namespace Purchases
{
    public class Receipt{
        private int iReceiptId;
        private string sNumber;
        private DateTime dtPayed;
        private decimal dPrice;
        private decimal dDiscount;
        private int iDiscountCard;
        private string sComment;
        private int iVendor;
        private short sDeleted;


        // подготовка параметров для SqlCommand таблицы чека
        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command){
            command.Parameters.Add("@Payed", System.Data.SqlDbType.DateTime, 0, "Payed");
            command.Parameters.Add("@Price", System.Data.SqlDbType.Decimal, 0, "Price");
            command.Parameters.Add("@Discount", System.Data.SqlDbType.Decimal, 0, "Discount");
            command.Parameters.Add("@DiscountCard", System.Data.SqlDbType.Int, 0, "DiscountCard");
            command.Parameters.Add("@Comment", System.Data.SqlDbType.NVarChar, 0, "Comment");
            command.Parameters.Add("@Vendor", System.Data.SqlDbType.Int, 0, "Vendor");
            command.Parameters.Add("@Deleted", System.Data.SqlDbType.Int, 0, "Deleted");
            command.Parameters.Add("@Number", System.Data.SqlDbType.NVarChar, 0, "Number");
            command.Parameters.Add("@Created", System.Data.SqlDbType.DateTime, 0, "Created");
            command.Parameters.Add("@Updated", System.Data.SqlDbType.DateTime, 0, "Updated");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand InsertCommand( System.Data.DataRow row ){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO Purchases.Receipts\n" +
                            "           (Payed, Price, Discount, DiscountCard, Comment, Vendor,\n" +
                            "            Deleted, Number, Created, Updated)\n" +
                            "VALUES (@Payed, @Price, @Discount, @DiscountCard, @Comment, @Vendor,\n" +
                            "        @Deleted, @Number, @Created, @Updated);"; //\n" +
//                            "SELECT @ReceiptID = SCOPE_IDENTITY()";
            cmd.Parameters.AddWithValue("@Payed", row["Payed"]);
            cmd.Parameters.AddWithValue("@Price", row["Price"]);
            cmd.Parameters.AddWithValue("@Discount", row["Discount"]);
            cmd.Parameters.AddWithValue("@DiscountCard", row["DiscountCard"]);
            cmd.Parameters.AddWithValue("@Comment", row["Comment"]);
            cmd.Parameters.AddWithValue("@Vendor", row["Vendor"]);
            cmd.Parameters.AddWithValue("@Deleted", row["Deleted"]);
            cmd.Parameters.AddWithValue("@Number", row["Number"]);
            cmd.Parameters.AddWithValue("@Created", row["Created"]);
            cmd.Parameters.AddWithValue("@Updated", row["Updated"]);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
//            cmd = Receipt.AddParameters(cmd);
            return cmd;
        }
        public static System.Data.SqlClient.SqlCommand UpdateCommand( System.Data.DataRow row ){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "UPDATE Purchases.Receipts\n" +
                            "   SET Payed = @Payed, Price = @Price, Discount = @Discount,\n" +
                            "       DiscountCard = @DiscountCard, Comment = @Comment, Vendor = @Vendor,\n" +
                            "       Deleted = @Deleted, Number = @Number, Created = @Created, Updated = @Updated\n" +
                            " WHERE ReceiptID = @ReceiptID";
            cmd.Parameters.AddWithValue("@ReceiptID", row["ReceiptID"]);
            cmd.Parameters.AddWithValue("@Payed", row["Payed"]);
            cmd.Parameters.AddWithValue("@Price", row["Price"]);
            cmd.Parameters.AddWithValue("@Discount", row["Discount"]);
            cmd.Parameters.AddWithValue("@DiscountCard", row["DiscountCard"]);
            cmd.Parameters.AddWithValue("@Comment", row["Comment"]);
            cmd.Parameters.AddWithValue("@Vendor", row["Vendor"]);
            cmd.Parameters.AddWithValue("@Deleted", row["Deleted"]);
            cmd.Parameters.AddWithValue("@Number", row["Number"]);
            cmd.Parameters.AddWithValue("@Created", row["Created"]);
            cmd.Parameters.AddWithValue("@Updated", row["Updated"]);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
//            cmd = Receipt.AddParameters(cmd);
            return cmd;
        }

    }
}
