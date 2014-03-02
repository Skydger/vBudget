using System;
using System.Collections.Generic;
using System.Text;

namespace Producer
{
    public class Maker{
        private static string Table = "Producer.Makers";
        public static System.Data.SqlClient.SqlCommand Select(Guid maker_category){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "";
            if( maker_category != Guid.Empty ){
                sWhere += (sWhere.Length > 0 ? "      AND " : "    WHERE ");
                sWhere += "MakerCategory = @MakerCategory\n";
                cmd.Parameters.AddWithValue("@MakerCategory", maker_category);
            }
/*
            if ( (type_ids != null) && (type_ids.Length > 0 ) ){
                sWhere += (sWhere.Length > 0 ? "      AND " : "    WHERE ");
                string[] parameters = new string[type_ids.Length];
                for (int i = 0; i < type_ids.Length; i++){
                    parameters[i] = string.Format( "@Type{0}", type_ids[i] );
                    cmd.Parameters.AddWithValue(parameters[i], type_ids[i]);
                }
                sWhere += string.Format("p.Type IN ( {0} )", string.Join(", ", parameters));

            }
 */
            string sQuery = "SELECT m.MakerID, m.Name, m.MakerCategory, m.Vendor,\n" +
                            "       m.WebSite, m.Address, m.Created, m.Updated,\n" +
                            "       c.CategoryName\n" +
                            "  FROM " + Maker.Table + " AS m\n" +
                            "  JOIN Producer.Categories AS c\n" +
                            "    ON m.MakerCategory = c.CategoryID\n" +
                            sWhere +
                            "ORDER BY Name";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command)
        {
            command.Parameters.Add("@MakerID", System.Data.SqlDbType.UniqueIdentifier, 0, "MakerID");
            command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 0, "Name");
            command.Parameters.Add("@MakerCategory", System.Data.SqlDbType.Int, 0, "MakerCategory");
            command.Parameters.Add("@Vendor", System.Data.SqlDbType.NVarChar, 0, "Vendor");
            command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 0, "Address");
            command.Parameters.Add("@WebSite", System.Data.SqlDbType.NVarChar, 0, "WebSite");
            command.Parameters.Add("@Created", System.Data.SqlDbType.DateTime, 0, "Created");
            command.Parameters.Add("@Updated", System.Data.SqlDbType.DateTime, 0, "Updated");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand Insert()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO " + Maker.Table + "\n" +
                            "       (MakerID, Name, MakerCategory, Vendor, Address, WebSite, Created, Updated)\n" +
                            "VALUES (@MakerID, @Name, @MakerCategory, @Vendor, @Address, @WebSite, GETDATE(), GETDATE())";
            cmd = Maker.AddParameters(cmd);
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
                string sQuery = "INSERT INTO " + Maker.Table + "\n" +
                                "       (MakerID, Name, MakerCategory, Vendor, Address, Created, Updated)\n" +
                                "VALUES (@MakerID, @Name, @MakerCategory, @Vendor, @Address, GETDATE(), GETDATE())";
                cmd.Parameters.AddWithValue("@MakerID", row["MakerID"]);
                cmd.Parameters.AddWithValue("@Name", row["Name"]);
                cmd.Parameters.AddWithValue("@MakerCategory", row["MakerCategory"]);
                cmd.Parameters.AddWithValue("@Vendor", row["Vendor"]);
                cmd.Parameters.AddWithValue("@Address", row["Address"]);
                //cmd.Parameters.AddWithValue("@Created", row["Created"]);
                //cmd.Parameters.AddWithValue("@Updated", row["Updated"]);
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
            string sQuery = "UPDATE " + Maker.Table + "\n" +
                                "   SET Name = @Name,\n" +
                                "       MakerCategory = @MakerCategory,\n" +
                                "       Vendor = @Vendor,\n" +
                                "       Address = @Address,\n" +
                                "       WebSite = @WebSite,\n" +
                                "       Updated = GETDATE()\n" +
                                " WHERE MakerID = @MakerID";
            cmd = Maker.AddParameters(cmd);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        /// <summary>
        /// Обновление записи
        /// </summary>
        /// <param name="connection">Соединение</param>
        /// <param name="row">Строка типа System.Data.DataRow - запись в таблице изготовителей</param>
        /// <param name="message">Выходной параметр строки ошибки, если метод возвращает false</param>
        /// <returns>Возвращает true в случае успеха, false - в случае ошибки.</returns>
        public static bool Update(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "UPDATE " + Maker.Table + "\n" +
                                "   SET Name = @Name,\n" +
                                "       MakerCategory = @MakerCategory,\n" +
                                "       Vendor = @Vendor,\n" +
                                "       Address = @Address,\n" +
                                "       WebSite = @WebSite,\n" + 
                                "       Updated = GETDATE()\n" +
                                " WHERE MakerID = @MakerId";

                cmd.Parameters.AddWithValue("@Name", row["Name"]);
                cmd.Parameters.AddWithValue("@MakerCategory", row["MakerCategory"]);
                cmd.Parameters.AddWithValue("@Vendor", row["Vendor"]);
                cmd.Parameters.AddWithValue("@Address", row["Address"]);
                cmd.Parameters.AddWithValue("@WebSite", row["WebSite"]);
                cmd.Parameters.AddWithValue("@MakerID", row["MakerID"]);
                //cmd.Parameters.AddWithValue("@Updated", row["Updated"]);
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


        public static bool Delete(System.Data.SqlClient.SqlConnection connection,
                                  System.Data.SqlClient.SqlTransaction tran,
                                  System.Data.DataRow row, out string message)
        {
            bool done = false;
            message = "";
            try
            {
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "DELETE FROM " + Maker.Table + "\n" +
                                " WHERE MakerID = @MakerID";
                cmd.Parameters.AddWithValue("@MakerID", row["MakerID"]);
                cmd.Connection = connection;
                if (tran != null) cmd.Transaction = tran;
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
        /// Method to get a new identifier for maker
        /// </summary>
        /// <param name="connection">MS SQL database connection</param>
        /// <param name="message">Error string in case of error</param>
        /// <returns>Returns a new uniqueidentifier, Guid.Empty in case of error</returns>
        public static Guid NewId( System.Data.SqlClient.SqlConnection connection, out string message ){
            Guid new_id = Guid.Empty;
            message = "";
            try{
                connection.Open();
                string sQuery = "SELECT NEWID() AS MakerNewID\n" +
                                "  FROM " + Maker.Table;
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

    }
}
