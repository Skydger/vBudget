using System;
using System.Collections.Generic;
using System.Text;

namespace Purchases
{
    /// <summary>
    /// Класс дисконтных карт
    /// </summary>
    public class DiscountCard{
        private static string Table = "Purchases.DiscountCards";

        /// <summary>
        /// Метод выборки дисконтных карт
        /// </summary>
        public static System.Data.SqlClient.SqlCommand Select(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "    SELECT dc.CardID, dc.CardOwner, dc.VendorID, dc.CardName,\n" +
                            "           dc.CardNumber, dc.DiscountPercent, dc.DiscountType,\n" +
                            "           dc.Since, dc.Added, dc.Expired,\n" +
                            "           pu.Surname, pu.Name, pu.SecondName,\n" +
                            "           pv.VendorName\n" +
                            "      FROM " + DiscountCard.Table + " AS dc\n" +
                            "INNER JOIN Persons.Users AS pu\n" +
                            "        ON pu.UserID = dc.CardOwner\n" +
                            "INNER JOIN Purchases.Vendors AS pv\n" +
                            "        ON pv.VendorID = dc.VendorID\n";
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
                                "      SET Expired = 1\n" +
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
        public static int LastId( System.Data.SqlClient.SqlConnection connection, out string message ){
            int last_id = -1;
            message = "";
            try{
                connection.Open();
                string sQuery = "SELECT MAX(CardID) AS LastID\n" +
                                "  FROM " + DiscountCard.Table;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sQuery);
                cmd.Connection = connection;
                object res = cmd.ExecuteScalar();
                if (System.Convert.IsDBNull(res)) last_id = 0;
                else last_id = (int)res;
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
