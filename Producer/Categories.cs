using System;
using System.Collections.Generic;
using System.Text;

namespace Producer{
    public class Categories{
        // основная таблица
        static private string Table = "Producer.Categories";

        // выборка категорий продуктов
        public static System.Data.SqlClient.SqlCommand Select( int category_id ){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "SELECT CategoryID, CategoryName\n" +
                            "  FROM " + Categories.Table + "\n" +
                            "ORDER BY CategoryName";
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

        public static int LastId( System.Data.SqlClient.SqlConnection connection, out string message ){
            int last_id = -1;
            message = "";
            try{
                connection.Open();
                string sQuery = "SELECT MAX(CategoryID) AS LastID\n" +
                                "  FROM " + Categories.Table;
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
        public static bool Exists(System.Data.SqlClient.SqlConnection connection, string category_name, out bool exists, out string message)
        {
            bool ret = false;
            exists = false;
            message = "";
            int cat_id = -1;
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
                if (!System.Convert.IsDBNull(res)) cat_id = (int)res;
                connection.Close();
                exists = (cat_id != -1);
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
    }
}
