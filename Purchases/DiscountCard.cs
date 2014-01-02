using System;
using System.Collections.Generic;
using System.Text;

namespace Purchases
{
    /// <summary>
    /// Discount card class
    /// </summary>
    public class DiscountCard{
        public static string Table = "Purchases.DiscountCards";

        /// <summary>
        /// Метод выборки дисконтных карт
        /// </summary>
        public static System.Data.SqlClient.SqlCommand Select(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "SELECT dc.CardID, dc.CardOwner, dc.VendorID, dc.CardName,\n" +
                            "       dc.CardNumber, dc.DiscountPercent, dc.DiscountType,\n" +
                            "       dc.Since, dc.Added, dc.Expired,\n" +
                            "       cb.OverallBalance, cb.DiscountBalance,\n" +
                            "       cb.LastReceiptID, cb.Points,\n" +
                            "       pu.Surname, pu.Name, pu.SecondName,\n" +
                            "       pv.VendorName,\n" +
                            "       CASE WHEN cb.CardID IS NULL THEN 0\n" +
                            "       ELSE 1 END AS HasBalance\n" +
                            "  FROM " + DiscountCard.Table + " AS dc\n" +
                            "  LEFT JOIN " + CardBalance.Table + " AS cb\n" +
                            "    ON cb.CardID = dc.CardID\n" +
                            " INNER JOIN Persons.Users AS pu\n" +
                            "         ON pu.UserID = dc.CardOwner\n" +
                            " INNER JOIN Purchases.Vendors AS pv\n" +
                            "         ON pv.VendorID = dc.VendorID\n";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command)
        {
            command.Parameters.Add("@CardOwner", System.Data.SqlDbType.Int, 0, "CardOwner");
            command.Parameters.Add("@VendorID", System.Data.SqlDbType.Int, 0, "VendorID");
            command.Parameters.Add("@CardName", System.Data.SqlDbType.NVarChar, 0, "CardName");
            command.Parameters.Add("@CardNumber", System.Data.SqlDbType.NVarChar, 0, "CardNumber");
            command.Parameters.Add("@DiscountPercent", System.Data.SqlDbType.Decimal, 0, "DiscountPercent");
            command.Parameters.Add("@DiscountType", System.Data.SqlDbType.SmallInt, 0, "DiscountType");
            command.Parameters.Add("@Since", System.Data.SqlDbType.DateTime, 0, "Since");
            command.Parameters.Add("@Expired", System.Data.SqlDbType.DateTime, 0, "Expired");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand Insert()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO " + DiscountCard.Table + "\n" +
                            "            (CardOwner, VendorID, CardName,\n" +
                            "             CardNumber, DiscountPercent, DiscountType,\n" +
                            "             Since, Added, Expired)\n" +
                            "     VALUES (@CardOwner, @VendorID, @CardName,\n" +
                            "             @CardNumber, @DiscountPercent, @DiscountType,\n" +
                            "             @Since, @Added, @Expired)";
            cmd = DiscountCard.AddParameters(cmd);
            cmd.Parameters.Add("@Added", System.Data.SqlDbType.DateTime, 0, "Added");
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        /// <summary>
        /// Занесение новой записи в БД о дисконтной карте
        /// </summary>
        /// <param name="connection">Соединени с БД</param>
        /// <param name="row">Строка</param>
        /// <param name="message">Выходное сообщение об ошибке, если метод возвращает ложь</param>
        /// <returns>Метод возвращает истину, если не возникло ошибок; ложь - в противном случае</returns>
        public static bool Insert(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "INSERT INTO " + DiscountCard.Table + "\n" +
                                "            (CardOwner, VendorID, CardName,\n" +
                                "             CardNumber, DiscountPercent, DiscountType,\n" +
                                "             Since, Added, Expired)\n" +
                                "     VALUES (@CardOwner, @VendorID, @CardName,\n" +
                                "             @CardNumber, @DiscountPercent, @DiscountType,\n" +
                                "             @Since, @Added, @Expired)";
                cmd.Parameters.AddWithValue("@CardOwner", row["CardOwner"]);
                cmd.Parameters.AddWithValue("@VendorID", row["VendorID"]);
                cmd.Parameters.AddWithValue("@CardName", row["CardName"]);
                cmd.Parameters.AddWithValue("@CardNumber", row["CardNumber"]);
                cmd.Parameters.AddWithValue("@DiscountPercent", row["DiscountPercent"]);
                cmd.Parameters.AddWithValue("@DiscountType", row["DiscountType"]);
                cmd.Parameters.AddWithValue("@Since", row["Since"]);
                cmd.Parameters.AddWithValue("@Added", row["Added"]);
                cmd.Parameters.AddWithValue("@Expired", row["Expired"]);
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                cmd.ExecuteNonQuery();
                connection.Close();
                done = true;
            }catch (System.Exception ex){
                message = ex.Message;
            }finally{
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            return done;
        }

        public static System.Data.SqlClient.SqlCommand Update()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "UPDATE " + DiscountCard.Table + "\n" +
                            "   SET CardOwner = @CardOwner, VendorID = @VendorID, CardName = @CardName,\n" +
                            "       CardNumber = @CardNumber, DiscountPercent = @DiscountPercent, DiscountType = @DiscountType,\n" +
                            "       Since = @Since, Added = @Added, Expired = @Expired\n" +
                            " WHERE CardID = @CardID";
            cmd = DiscountCard.AddParameters(cmd);
            cmd.Parameters.Add("@CardID", System.Data.SqlDbType.Int, 0, "CardID");
            cmd.Parameters.Add("@Added", System.Data.SqlDbType.DateTime, 0, "Added");
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        /// <summary>
        /// Обновление записи в БД о дисконтной карте
        /// </summary>
        /// <param name="connection">Соединени с БД</param>
        /// <param name="row">Строка</param>
        /// <param name="message">Выходное сообщение об ошибке, если метод возвращает ложь</param>
        /// <returns>Метод возвращает истину, если не возникло ошибок; ложь - в противном случае</returns>
        public static bool Update(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, /*byte[] image,*/ out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "UPDATE " + DiscountCard.Table + "\n" +
                                "   SET CardOwner = @CardOwner, VendorID = @VendorID, CardName = @CardName,\n" +
                                "       CardNumber = @CardNumber, DiscountPercent = @DiscountPercent, DiscountType = @DiscountType,\n" +
                                "       Since = @Since, Added = @Added, Expired = @Expired\n" +
                                " WHERE CardID = @CardID";

                cmd.Parameters.AddWithValue("@CardID", row["CardID"]);
                cmd.Parameters.AddWithValue("@CardOwner", row["CardOwner"]);
                cmd.Parameters.AddWithValue("@VendorID", row["VendorID"]);
                cmd.Parameters.AddWithValue("@CardName", row["CardName"]);
                cmd.Parameters.AddWithValue("@CardNumber", row["CardNumber"]);
                cmd.Parameters.AddWithValue("@DiscountPercent", row["DiscountPercent"]);
                cmd.Parameters.AddWithValue("@DiscountType", row["DiscountType"]);
                cmd.Parameters.AddWithValue("@Since", row["Since"]);
                cmd.Parameters.AddWithValue("@Added", row["Added"]);
                cmd.Parameters.AddWithValue("@Expired", row["Expired"]);
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                cmd.ExecuteNonQuery();
                connection.Close();
                done = true;
            }catch (System.Exception ex){
                message = ex.Message;
            }finally{
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            return done;
        }

        /// <summary>
        /// Удаление записи в БД о дисконтной карте
        /// </summary>
        /// <param name="connection">Соединени с БД</param>
        /// <param name="row">Строка</param>
        /// <param name="message">Выходное сообщение об ошибке, если метод возвращает ложь</param>
        /// <returns>Метод возвращает истину, если не возникло ошибок; ложь - в противном случае</returns>
        public static bool Delete(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, /*byte[] image,*/ out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "IF EXISTS (SELECT DiscountCard\n" +
                                "             FROM Purchases.Receipts\n" +
                                "            WHERE Purchases.Receipts.DiscountCard = @CardID ) \n" +
                                "   UPDATE Purchases.DiscountCards\n" +
                                "      SET Expired = GETDATE()\n" +
                                "    WHERE CardID = @CardID\n" +
                                "ELSE\n" +
                                "   DELETE\n" +
                                "     FROM Purchases.DiscountCards\n" +
                                "    WHERE CardID = @CardID";

                cmd.Parameters.AddWithValue("@CardID", row["CardID"]);
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                cmd.ExecuteNonQuery();
                connection.Close();
                done = true;
            }catch (System.Exception ex){
                message = ex.Message;
            }finally{
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            return done;
        }

        /// <summary>
        /// Получение идентификатора последней занесённой записи о дисконтной карте
        /// </summary>
        /// <param name="connection">Соединени с БД</param>
        /// <param name="message">Выходное сообщение об ошибке, если метод возвращает ложь</param>
        /// <returns>Метод возвращает идентификатор последней записи</returns>
        public static Guid LastId( System.Data.SqlClient.SqlConnection connection, out string message ){
            Guid last_id = new Guid(0,0,0, new byte [] {0,0,0,0,0,0,0,0});
            message = "";
            try{
                connection.Open();
                string sQuery = "SELECT NEWID() AS LastID\n" +
                                "  FROM " + DiscountCard.Table;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sQuery);
                cmd.Connection = connection;
                object res = cmd.ExecuteScalar();
                if (!System.Convert.IsDBNull(res)) last_id = (Guid)res;
                connection.Close();
            }catch(System.Exception ex ){
                message = ex.Message;
            }finally{
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            return last_id;
        }

    }
}
