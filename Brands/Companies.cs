using System;
using System.Collections.Generic;
using System.Text;

namespace Brands
{
    public class Companies
    {
        private static string Table = "Brands.Companies";

        public static System.Data.SqlClient.SqlCommand Select(Guid company_id)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "";
            if (company_id != Guid.Empty)
            {
                sWhere += (sWhere.Length > 0 ? " AND" : "WHERE");
                sWhere = " c.CompanyID = @CompanyID\n";
                cmd.Parameters.AddWithValue("@CompanyID", company_id);
            }
            string sQuery = "SELECT CompanyID, ParentID, CompanyName, [Address], WebSite, Phones\n" +
                            "  FROM " + Companies.Table + " AS c\n" +
                            sWhere +
                            "ORDER BY c.CompanyName";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        public static System.Data.SqlClient.SqlCommand SelectTree(Guid company_id)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "";
            if (company_id != Guid.Empty)
            {
                sWhere += (sWhere.Length > 0 ? " AND" : "WHERE");
                sWhere = " c.CompanyID = @CompanyID OR c.ParentID = @CompanyID\n";
                cmd.Parameters.AddWithValue("@CompanyID", company_id);
            }
            string sQuery = "WITH CompaniesTree\n" +
                            "  AS (SELECT cm.CompanyID, cm.ParentID, cm.CompanyName,\n" +
                            "             cm.[Address], cm.WebSite, cm.Phones, 0 AS CompanyLevel\n" +
                            "        FROM Brands.Companies AS cm\n" +
                            "       WHERE cm.ParentID IS NULL\n" +
                            "       UNION ALL\n" +
                            "      SELECT cs.CompanyID, cs.ParentID, cs.CompanyName,\n" +
                            "             cs.[Address], cs.WebSite, cs.Phones, ct.CompanyLevel + 1 AS CompanyLevel\n" +
                            "        FROM Brands.Companies AS cs\n" +
                            "        JOIN CompaniesTree AS ct\n" +
                            "          ON ct.CompanyID = cs.ParentID\n" +
                            "       WHERE cs.ParentID IS NOT NULL\n" +
                            ")\n" +
                            "SELECT *\n" +
                            "  FROM CompaniesTree AS c" +
                            sWhere;
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        /// <summary>
        /// Method to insert a new company to database
        /// </summary>
        /// <param name="connection">SQL connection</param>
        /// <param name="row">A row of type System.Data.DataRow - a single company</param>
        /// <param name="message">Error message, if method returns 'false' itself</param>
        /// <returns>Returns 'true' in success, 'false' - in other cases.</returns>
        public static bool Insert(System.Data.SqlClient.SqlConnection connection, ref System.Data.DataRow row, out string message)
        {
            bool done = false;
            message = "";
            try
            {
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "SELECT NEWID() AS NewCompanyID\n" +
                                "  FROM " + Companies.Table;
                cmd.CommandText = sQuery;
                cmd.Connection = connection;
                object res = cmd.ExecuteScalar();
                if (!System.Convert.IsDBNull(res))
                {
                    Guid new_id = (Guid)res;
                    row["CompanyID"] = new_id;

                    sQuery = "INSERT INTO " + Companies.Table + "\n" +
                             "       (CompanyID, ParentID, CompanyName, [Address], WebSite, Phones, Created, Updated)\n" +
                             "VALUES (@CompanyID, @ParentID, @CompanyName, @Address, @WebSite, @Phones, GETDATE(), GETDATE())";
                    cmd.Parameters.AddWithValue("@CompanyID", row["CompanyID"]);
                    cmd.Parameters.AddWithValue("@ParentID", row["ParentID"]);
                    cmd.Parameters.AddWithValue("@CompanyName", row["CompanyName"]);
                    cmd.Parameters.AddWithValue("@Address", row["Address"]);
                    cmd.Parameters.AddWithValue("@WebSite", row["WebSite"]);
                    cmd.Parameters.AddWithValue("@Phones", row["Phones"]);
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sQuery;
                    cmd.ExecuteNonQuery();
                    done = true;
                }
                connection.Close();
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
        /// Method to update a company
        /// </summary>
        /// <param name="connection">SQL connection</param>
        /// <param name="row">A row of type System.Data.DataRow - a single company</param>
        /// <param name="message">Error message, if method returns 'false' itself</param>
        /// <returns>Returns 'true' in success, 'false' - in other cases.</returns>
        public static bool Update(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message)
        {
            bool done = false;
            message = "";
            try
            {
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "UPDATE " + Companies.Table + "\n" +
                                "   SET ParentID = @ParentID,\n" +
                                "       CompanyName = @Name,\n" +
                                "       Address = @Address,\n" +
                                "       WebSite = @WebSite,\n" +
                                "       Phones = @Phones,\n" +
                                "       Updated = GETDATE()\n" +
                                " WHERE CompanyID = @CompanyID";

                cmd.Parameters.AddWithValue("@CompanyName", row["CompanyName"]);
                cmd.Parameters.AddWithValue("@ParentID", row["ParentID"]);
                cmd.Parameters.AddWithValue("@Address", row["Address"]);
                cmd.Parameters.AddWithValue("@WebSite", row["WebSite"]);
                cmd.Parameters.AddWithValue("@CompanyID", row["CompanyID"]);
                cmd.Parameters.AddWithValue("@Phones", row["Phones"]);
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

    }
}
