using System;
using System.Collections.Generic;
using System.Text;

namespace Producer
{
    public class Maker{
        private static string Table = "Producer.Makers";
        public static System.Data.SqlClient.SqlCommand Select(int maker_category){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "";
            if( maker_category > 0 ){
                sWhere += (sWhere.Length > 0 ? "      AND " : "    WHERE ");
                sWhere += "MakerCategory = " + maker_category.ToString() + "\n";
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
            string sQuery = "SELECT m.MakerId, m.Name, m.MakerCategory, m.Vendor,\n" +
                            "       c.CategoryName\n" +
                            "  FROM " + Maker.Table + " AS m\n" +
                            "  JOIN [Producer].[Categories] AS c\n" +
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
            command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 0, "Name");
            command.Parameters.Add("@MakerCategory", System.Data.SqlDbType.Int, 0, "MakerCategory");
            command.Parameters.Add("@Vendor", System.Data.SqlDbType.NVarChar, 0, "Vendor");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand Insert()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO " + Maker.Table + "\n" +
                            "           (Name, MakerCategory, Vendor)\n" +
                            "VALUES (@Name, @MakerCategory, @Vendor)";
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
                                "           (Name, MakerCategory, Vendor)\n" +
                                "VALUES (@Name, @MakerCategory, @Vendor)";
                cmd.Parameters.AddWithValue("@Name", row["Name"]);
                cmd.Parameters.AddWithValue("@MakerCategory", row["MakerCategory"]);
                cmd.Parameters.AddWithValue("@Vendor", row["Vendor"]);
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
                                "       Vendor = @Vendor\n" +
                                " WHERE MakerId = @MakerId";
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
                                "       Vendor = @Vendor\n" +
                                " WHERE MakerId = @MakerId";

                cmd.Parameters.AddWithValue("@Name", row["Name"]);
                cmd.Parameters.AddWithValue("@MakerCategory", row["MakerCategory"]);
                cmd.Parameters.AddWithValue("@Vendor", row["Vendor"]);
                cmd.Parameters.AddWithValue("@MakerId", row["MakerId"]);
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
        /// Получение последнего идентификатора в таблице изготовителей
        /// </summary>
        /// <param name="connection">Соединение</param>
        /// <param name="message">Выходной параметр строки ошибки, если метод возвращает -1</param>
        /// <returns>Возвращает идентификатор последней записи в таблице в случае успеха, -1 - в случае ошибки.</returns>
        public static int LastId( System.Data.SqlClient.SqlConnection connection, out string message ){
            int last_id = -1;
            message = "";
            try{
                connection.Open();
                string sQuery = "SELECT MAX(MakerId) AS LastID\n" +
                                "  FROM " + Maker.Table;
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
