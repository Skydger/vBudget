using System;
using System.Collections.Generic;
using System.Text;

namespace Producer{
    public class Categories{
        // основная таблица
        static private string Table = "Producer.Categories";

        // выборка категорий продуктов
        public static System.Data.SqlClient.SqlCommand Select( Guid category_id ){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string where = "";
            if (category_id != Guid.Empty)
            {
                where = " WHERE CategoryID = @CategoryID\n";
                cmd.Parameters.AddWithValue("@CategoryID", category_id);
            }
            string sQuery = "SELECT CategoryID, CategoryName\n" +
                            "  FROM " + Categories.Table + "\n" +
                            where +
                            "ORDER BY CategoryName";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command)
        {
            command.Parameters.Add("@CategoryName", System.Data.SqlDbType.NVarChar, 0, "CategoryName");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand Insert()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO " + Categories.Table + "\n" +
                            "           (CategoryName)\n" +
                            "VALUES (@CategoryName)";
            cmd = Categories.AddParameters(cmd);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        public static System.Data.SqlClient.SqlCommand Update()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "UPDATE " + Categories.Table + "\n" +
                            "   SET CategoryName = @CategoryName\n" +
                            " WHERE CategoryID = @CategoryID";
            cmd = Categories.AddParameters(cmd);
            cmd.Parameters.Add("@CategoryID", System.Data.SqlDbType.UniqueIdentifier, 0, "CategoryID");
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }


        // Занесение новой записи в БД
        public static bool Insert(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "INSERT INTO " + Categories.Table + "\n" +
                                "           (CategoryName)\n" +
                                "VALUES (@CategoryName)";

                cmd.Parameters.AddWithValue("@CategoryName", row["CategoryName"]);
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
        // Обновление записи
        public static bool Update(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "UPDATE " + Categories.Table + "\n" +
                                "   SET CategoryName = @CategoryName\n" +
                                " WHERE CategoryID = @CategoryID";

                cmd.Parameters.AddWithValue("@CategoryName", row["CategoryName"]);
                cmd.Parameters.AddWithValue("@CategoryID", row["CategoryID"]);
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
        public static bool Delete(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message)
        {
            bool done = false;
            message = "";
            try
            {
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "DELETE FROM " + Categories.Table + "\n" +
                                " WHERE CategoryID = @CategoryID";
                cmd.Parameters.AddWithValue("@CategoryID", row["CategoryID"]);
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
        public static Guid NewId( System.Data.SqlClient.SqlConnection connection, out string message ){
            Guid new_id = Guid.Empty;
            message = "";
            try{
                connection.Open();
                string sQuery = "SELECT NEWID() AS NewCategoryID\n" +
                                "  FROM " + Categories.Table;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sQuery);
                cmd.Connection = connection;
                object res = cmd.ExecuteScalar();
                if (!System.Convert.IsDBNull(res))
                    new_id = (Guid)res;
                connection.Close();
            }catch(System.Exception ex ){
                message = ex.Message;
            }finally{
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            return new_id;
        }
        public static bool Exists(System.Data.SqlClient.SqlConnection connection, string category_name, out bool exists, out string message)
        {
            bool ret = false;
            exists = false;
            message = "";
            Guid cat_id = Guid.Empty;
            try
            {
                connection.Open();
                string sQuery = "SELECT CategoryID\n" +
                                "  FROM " + Categories.Table + "\n" +
                                " WHERE CategoryName = @Category";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sQuery);
                cmd.Parameters.AddWithValue("@Category", category_name );
                cmd.Connection = connection;
                object res = cmd.ExecuteScalar();
                if (res != null && !System.Convert.IsDBNull(res)) cat_id = (Guid)res;
                connection.Close();
                exists = (cat_id != Guid.Empty);
                ret = true;
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
            return ret;
        }
        public static bool Exists(System.Data.SqlClient.SqlConnection connection,
                          System.Data.DataRow row,
                          out int products,
                          out int receipts,
                          out string message)
        {
            bool done = false;
            products = 0;
            receipts = 0;
            message = "";
            try
            {
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "SELECT COUNT(DISTINCT p.ProductID) AS prod_amount,\n" +
                                "       COUNT(DISTINCT rc.ReceiptID) AS rec_amount\n" +
                                "  FROM Producer.Products AS p\n" +
                                "  LEFT JOIN Purchases.ReceiptContents AS rc\n" +
                                "    ON rc.ProductID = p.ProductID\n" +
                                " WHERE p.Category = @Category";
                cmd.Parameters.AddWithValue("@Category", row["CategoryID"]);
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    products = (int)dr[0];
                    receipts = (int)dr[1];
                }
                done = true;
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return done;
        }
    }
}
