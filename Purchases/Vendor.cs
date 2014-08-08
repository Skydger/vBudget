using System;
using System.Collections.Generic;
using System.Text;

namespace Purchases
{
    public class Vendor{
        private static string Table = "Purchases.Vendors";

        public static System.Data.SqlClient.SqlCommand Select(int type_id, Guid company_id){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "";
            if (type_id >= 0){
                sWhere = "WHERE v.VendorType = @VendorType\n";
                cmd.Parameters.AddWithValue("@VendorType", type_id);
            }
            if (company_id != null && company_id != Guid.Empty)
            {
                sWhere += (sWhere.Length > 0 ? " AND" : "WHERE");
                sWhere += " cm.CompanyID = @CompanyID\n";
                cmd.Parameters.AddWithValue("@CompanyID", company_id);
            }
            string sQuery = "SELECT v.VendorID, v.ParentCompany, v.VendorName, v.VendorType, v.Phones, v.Address,\n" +
                            "       v.Logo, v.INoTP, v.Web, v.Created, v.Updated, v.Deleted, vp.TypeName,\n" +
                            "       CASE WHEN cm.CompanyName IS NULL THEN '' ELSE cm.CompanyName + ', ' END +\n" +
                            "       v.VendorName + ' ' + v.Address AS VendorNameAddress, cm.CompanyName,\n" +
                            "       ISNULL(rp.ReceiptsCount, 0) AS ReceiptsCount\n" +
                            "  FROM " + Vendor.Table + " AS v\n" +
                            "  LEFT JOIN Purchases.VendorTypes AS vp\n" +
                            "       ON vp.TypeID = v.VendorType\n" +
                            "  LEFT JOIN Brands.Companies AS cm\n" +
                            "       ON cm.CompanyID = v.ParentCompany\n" +
                            "  LEFT JOIN (SELECT Vendor, COUNT(ReceiptID) AS ReceiptsCount\n" +
                            "               FROM Purchases.Receipts AS r\n" +
                            "              GROUP BY Vendor) AS rp\n" +
                            "    ON rp.Vendor = v.VendorID\n" +
                            sWhere +
                            "ORDER BY v.VendorName";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        /// <summary>
        /// Selects all Vendors by name and company guid
        /// </summary>
        /// <param name="name">Vendor name likeness</param>
        /// <param name="company_id">Company id if present</param>
        /// <returns></returns>
        public static System.Data.SqlClient.SqlCommand Select(string name, Guid company_id)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "";
            if (name.Length > 0){
                name = "%" + name + "%";
                sWhere = "WHERE v.VendorName like @VendorName\n";
                cmd.Parameters.AddWithValue("@VendorName", name);
            }
            if (company_id != null && company_id != Guid.Empty)
            {
                sWhere += (sWhere.Length > 0 ? " AND" : "WHERE");
                sWhere += " cm.CompanyID = @CompanyID\n";
                cmd.Parameters.AddWithValue("@CompanyID", company_id);
            }
            string sQuery = "SELECT v.VendorID, v.ParentCompany, v.VendorName, v.VendorType, v.Phones, v.Address,\n" +
                            "       v.Logo, v.INoTP, v.Web, v.Created, v.Updated, v.Deleted, vp.TypeName,\n" +
                            "       CASE WHEN cm.CompanyName IS NULL THEN '' ELSE cm.CompanyName + ', ' END +\n" +
                            "       v.VendorName + ' ' + v.Address AS VendorNameAddress, cm.CompanyName\n" +
                            "  FROM " + Vendor.Table + " AS v\n" +
                            "  LEFT JOIN Purchases.VendorTypes AS vp\n" +
                            "       ON vp.TypeID = v.VendorType\n" +
                            "  LEFT JOIN Brands.Companies AS cm\n" +
                            "       ON cm.CompanyID = v.ParentCompany\n" +
                            sWhere +
                            "ORDER BY v.VendorName";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        // подготовка параметров для SqlCommand таблицы продуктов
        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command)
        {
            command.Parameters.Add("@VendorID", System.Data.SqlDbType.UniqueIdentifier, 0, "VendorID");
            command.Parameters.Add("@CompanyID", System.Data.SqlDbType.UniqueIdentifier, 0, "ParentCompany");
            command.Parameters.Add("@VendorName", System.Data.SqlDbType.NVarChar, 0, "VendorName");
            command.Parameters.Add("@VendorType", System.Data.SqlDbType.Int, 0, "VendorType");
            command.Parameters.Add("@Phones", System.Data.SqlDbType.NVarChar, 0, "Phones");
            command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 0, "Address");
            command.Parameters.Add("@Logo", System.Data.SqlDbType.VarBinary, 0, "Logo");
            command.Parameters.Add("@INoTP", System.Data.SqlDbType.NVarChar, 0, "INoTP");
            command.Parameters.Add("@Web", System.Data.SqlDbType.NVarChar, 0, "Web");
            command.Parameters.Add("@Updated", System.Data.SqlDbType.DateTime, 0, "Updated");
            command.Parameters.Add("@Deleted", System.Data.SqlDbType.Bit, 0, "Deleted");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand Insert()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO " + Vendor.Table + "\n" +
                            "            (VendorID, ParentCompany, VendorName, VendorType, Phones, Address, Logo,\n" +
                            "             INoTP, Web, Created, Updated, Deleted)\n" +
                            "     VALUES (@VendorID, @CompanyID, @VendorName, @VendorType, @Phones, @Address, @Logo,\n" +
                            "             @INoTP, @Web, @Created, @Updated, @Deleted)";
            cmd = Vendor.AddParameters(cmd);
            cmd.Parameters.Add("@Created", System.Data.SqlDbType.DateTime, 0, "Created");
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
                                "            (VendorID, ParentCompany, VendorName, VendorType, Phones, Address, Logo,\n" +
                                "             INoTP, Web, Created, Updated, Deleted)\n" +
                                "     VALUES (@VendorID, @CompanyID, @VendorName, @VendorType, @Phones, @Address, @Logo,\n" +
                                "             @INoTP, @Web, @Created, @Updated, @Deleted)";
                cmd.Parameters.AddWithValue("@VendorID", row["VendorID"]);
                cmd.Parameters.AddWithValue("@CompanyID", row["ParentCompany"]);
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

        public static System.Data.SqlClient.SqlCommand Update()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "UPDATE " + Vendor.Table + "\n" +
                            "   SET VendorName = @VendorName, VendorType = @VendorType, Phones = @Phones,\n" +
                            "       ParentCompany = @CompanyID,\n" +
                            "       Address = @Address, Logo = @Logo, INoTP = @INoTP, Web = @Web,\n" +
                            "       Updated = @Updated, Deleted = @Deleted\n" +
                            " WHERE VendorID = @VendorID";
            cmd = Vendor.AddParameters(cmd);
            cmd.Parameters.Add("@VendorID", System.Data.SqlDbType.UniqueIdentifier, 0, "VendorID");
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
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
                                "       ParentCompany = @CompanyID,\n" +
                                "       Address = @Address, Logo = @Logo, INoTP = @INoTP, Web = @Web,\n" +
                                "       Updated = @Updated, Deleted = @Deleted\n" +
                                " WHERE VendorID = @VendorID";

                cmd.Parameters.AddWithValue("@VendorID", row["VendorID"]);
                cmd.Parameters.AddWithValue("@CompanyID", row["ParentCompany"]);
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

        /// <summary>
        /// Get new identifier for vendor
        /// </summary>
        /// <param name="connection">SqlConnection object</param>
        /// <param name="message">Error message if error occurs</param>
        /// <returns>Returns empty identifier if error occurs, the new identifier otherwise</returns>
        public static Guid NewId( System.Data.SqlClient.SqlConnection connection, out string message ){
            Guid new_id = Guid.Empty;
            message = "";
            try{
                connection.Open();
                string sQuery = "SELECT NEWID() AS NewVendorID\n" +
                                "  FROM " + Vendor.Table;
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
