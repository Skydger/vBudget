using System;
using System.Collections.Generic;
using System.Text;

namespace Producer
{
    public class ProductTypes{
        static private string sTable = "Producer.ProductTypes";
        public static System.Data.SqlClient.SqlCommand Select( Guid category_id ){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "";
            if (category_id != Guid.Empty)
            {
                sWhere = "WHERE Category = @Category\n";
                cmd.Parameters.AddWithValue("@Category", category_id);
            }
            string sQuery = "SELECT TypeId, Category, Name, Comment\n" +
                            "  FROM Producer.ProductTypes\n" +
                            sWhere +
                            "ORDER BY Name";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        

        // подготовка параметров для SqlCommand таблицы типов продуктов
        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command){
            command.Parameters.Add("@Category", System.Data.SqlDbType.Int, 0, "Category");
            command.Parameters.Add("@Type", System.Data.SqlDbType.Int, 0, "TypeId");
            command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 0, "Name");
            command.Parameters.Add("@Comment", System.Data.SqlDbType.NVarChar, 0, "Comment");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand Insert(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "IF NOT EXISTS (SELECT Category, TypeId FROM " + sTable + "\n" +
                            "                WHERE (Category = @Category AND TypeId = @Type) OR\n" +
                            "                      (Category = @Category AND Name = @Name) )\n" +
                            "INSERT INTO " + sTable  + "\n" +
                            "           (Category, TypeId, Name, Comment)\n" +
                            "VALUES (@Category, @Type, @Name, @Comment)";
            cmd = ProductTypes.AddParameters(cmd);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        public static System.Data.SqlClient.SqlCommand Update(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "UPDATE " + sTable + "\n" +
                            "   SET Category = @CategoryNew, TypeId = @TypeNew, Name = @Name,\n" +
                            "       Comment = @Comment\n" +
                            " WHERE Category = @Category AND TypeId = @Type";
            cmd = ProductTypes.AddParameters(cmd);
            cmd.Parameters.Add("@CategoryNew", System.Data.SqlDbType.Int, 0, "Category");
            cmd.Parameters.Add("@TypeNew", System.Data.SqlDbType.Int, 0, "TypeId");
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        public static int NextId( System.Data.SqlClient.SqlConnection connection, Guid category_id, out string message ){
            int next_id = -1;
            message = "";
            try{
                if (category_id != Guid.Empty){
                    connection.Open();
                    string sQuery = "SELECT MAX(TypeId)+1 AS NextID\n" +
                                    "  FROM " + sTable + "\n" +
                                    "WHERE Category = @Category";
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sQuery);
                    cmd.Parameters.AddWithValue("@Category", category_id);
                    cmd.Connection = connection;
                    object res = cmd.ExecuteScalar();
                    if (System.Convert.IsDBNull(res)) next_id = 1;
                    else next_id = (int)res;
                    connection.Close();
                }else
                    message = "Необходимо указать категорию!";
            }catch(System.Exception ex ){
                message = ex.Message;
            }
            return next_id;
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
                                "  LEFT JOIN Purchases.ReceiptContents AS rc\n"+
                                "    ON rc.ProductID = p.ProductID\n" +
                                " WHERE p.Category = @Category AND\n" +
                                "       p.Type = @Type";
                cmd.Parameters.AddWithValue("@Category", row["Category"]);
                cmd.Parameters.AddWithValue("@Type", row["TypeId"]);
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

        public static bool Insert(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "INSERT INTO " + sTable + "\n" +
                                "           (Category, TypeId, Name, Comment)\n" +
                                "VALUES (@Category, @Type, @Name, @Comment)";
                cmd.Parameters.AddWithValue("@Category", row["Category"]);
                cmd.Parameters.AddWithValue("@Type", row["TypeId"]);
                cmd.Parameters.AddWithValue("@Name", row["Name"]);
                cmd.Parameters.AddWithValue("@Comment", row["Comment"]);
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                cmd.ExecuteNonQuery();
                done = true;
            }catch (System.Exception ex){
                message = ex.Message;
            }finally{
                connection.Close();
            }
            return done;
        }
        public static bool Update(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message)
        {
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "UPDATE " + sTable + "\n" +
                                "   SET Category = @Category, TypeId = @Type, Name = @Name,\n" +
                                "       Comment = @Comment\n" +
                                " WHERE Category = @CategoryOld AND TypeId = @TypeOld";
                cmd.Parameters.AddWithValue("@Category", row["Category", System.Data.DataRowVersion.Current]);
                cmd.Parameters.AddWithValue("@Type", row["TypeId", System.Data.DataRowVersion.Current]);
                cmd.Parameters.AddWithValue("@CategoryOld", row["Category", System.Data.DataRowVersion.Original]);
                cmd.Parameters.AddWithValue("@TypeOld", row["TypeId", System.Data.DataRowVersion.Original]);
                cmd.Parameters.AddWithValue("@Name", row["Name"]);
                cmd.Parameters.AddWithValue("@Comment", row["Comment"]);
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                cmd.ExecuteNonQuery();
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



        public static bool Delete(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message)
        {
            bool done = false;
            message = "";
            try
            {
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "DELETE FROM " + sTable + "\n" +
                                " WHERE Category = @Category AND TypeId = @Type";
                cmd.Parameters.AddWithValue("@Category", row["Category"]);
                cmd.Parameters.AddWithValue("@Type", row["TypeId"]);
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                cmd.ExecuteNonQuery();
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
