using System;
using System.Collections.Generic;
using System.Text;

namespace Purchases
{
    public class Vendor{
        private static string Table = "Purchases.Vendors";

        public static System.Data.SqlClient.SqlCommand Select(int type_id){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "";
            if (type_id >= 0){
                sWhere = "WHERE v.VendorType = @VendorType\n";
                cmd.Parameters.AddWithValue("@VendorType", type_id);
            }
            string sQuery = "SELECT v.VendorID, v.VendorName, v.VendorType, v.Phones, v.Address,\n" +
                            "       v.Logo, v.INoTP, v.Web, v.Created, v.Updated, v.Deleted,\n" +
                            "       vp.TypeName\n" +
                            "FROM " + Vendor.Table + " AS v\n" +
                            "LEFT JOIN Purchases.VendorTypes AS vp\n" +
                            "       ON vp.TypeID = v.VendorType\n" +
                            sWhere +
                            "ORDER BY v.VendorName";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        // Поиск продавца по наименованию
        public static System.Data.SqlClient.SqlCommand Select( string name ){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "";
            if (name.Length > 0){
                name = "%" + name + "%";
                sWhere = "WHERE v.VendorName like @VendorName\n";
                cmd.Parameters.AddWithValue("@VendorName", name);
            }
            string sQuery = "SELECT v.VendorID, v.VendorName, v.VendorType, v.Phones, v.Address,\n" +
                            "       v.Logo, v.INoTP, v.Web, v.Created, v.Updated, v.Deleted,\n" +
                            "       vp.TypeName\n" +
                            "FROM " + Vendor.Table + " AS v\n" +
                            "LEFT JOIN Purchases.VendorTypes AS vp\n" +
                            "       ON vp.TypeID = v.VendorType\n" +
                            sWhere +
                            "ORDER BY v.VendorName";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        // Занесение новой записи в БД о продавце
        public static bool Insert(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "INSERT INTO " + Vendor.Table + "\n" +
                                "            (VendorName, VendorType, Phones, Address, Logo,\n" +
                                "             INoTP, Web, Created, Updated, Deleted)\n" +
                                "     VALUES (@VendorName, @VendorType, @Phones, @Address, @Logo,\n" +
                                "             @INoTP, @Web, @Created, @Updated, @Deleted)";

                cmd.Parameters.AddWithValue("@VendorName", row["VendorName"]);
                cmd.Parameters.AddWithValue("@VendorType", row["VendorType"]);
                cmd.Parameters.AddWithValue("@Phones", row["Phones"]);
                cmd.Parameters.AddWithValue("@Address", row["Address"]);
                cmd.Parameters.AddWithValue("@Logo", row["Logo"]);
                cmd.Parameters.AddWithValue("@INoTP", row["INoTP"]);
                cmd.Parameters.AddWithValue("@Web", row["Web"]);
                cmd.Parameters.AddWithValue("@Created", row["Created"]);
                cmd.Parameters.AddWithValue("@Updated", row["Updated"]);
                cmd.Parameters.AddWithValue("@Deleted", row["Deleted"]);
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

        // Обновление записи в БД о продавце
        public static bool Update(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, /*byte[] image,*/ out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "UPDATE " + Vendor.Table + "\n" +
                                "   SET VendorName = @VendorName, VendorType = @VendorType, Phones = @Phones,\n" +
                                "       Address = @Address, Logo = @Logo, INoTP = @INoTP, Web = @Web,\n" +
                                "       Updated = @Updated, Deleted = @Deleted\n" +
                                " WHERE VendorID = @VendorID";

                cmd.Parameters.AddWithValue("@VendorID", row["VendorID"]);
                cmd.Parameters.AddWithValue("@VendorName", row["VendorName"]);
                cmd.Parameters.AddWithValue("@VendorType", row["VendorType"]);
                cmd.Parameters.AddWithValue("@Phones", row["Phones"]);
                cmd.Parameters.AddWithValue("@Address", row["Address"]);
                cmd.Parameters.AddWithValue("@Logo", row["Logo"]);
//                cmd.Parameters.AddWithValue("@Logo", image);
                cmd.Parameters.AddWithValue("@INoTP", row["INoTP"]);
                cmd.Parameters.AddWithValue("@Web", row["Web"]);
//                cmd.Parameters.AddWithValue("@Created", row["Created"]);
                cmd.Parameters.AddWithValue("@Updated", row["Updated"]);
                cmd.Parameters.AddWithValue("@Deleted", row["Deleted"]);
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

        // Получить последний занесённый ID
        public static int LastId( System.Data.SqlClient.SqlConnection connection, out string message ){
            int last_id = -1;
            message = "";
            try{
                connection.Open();
                string sQuery = "SELECT MAX(VendorID) AS LastID\n" +
                                "  FROM " + Vendor.Table;
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
