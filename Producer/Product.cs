using System;
using System.Collections.Generic;
using System.Text;

namespace Producer
{
    public class Product{

        public enum OrderColumn { ProductID = 0, ProductName = 1, Category = 2, Type = 3, Maker = 4, Barcode = 5 }
        static private string sTable = "Producer.Products";

        public static System.Data.SqlClient.SqlCommand Select(int category_id, int[] type_ids, Guid [] product_ids, List<OrderColumn> order_by)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "", sOrder = "";
            if( category_id > 0 ){
                sWhere += (sWhere.Length > 0 ? "      AND " : "    WHERE ");
                sWhere += "p.Category = " + category_id.ToString() + "\n";
            }
            if ( (type_ids != null) && (type_ids.Length > 0 ) ){
                sWhere += (sWhere.Length > 0 ? "      AND " : "    WHERE ");
                string[] parameters = new string[type_ids.Length];
                for (int i = 0; i < type_ids.Length; i++){
                    parameters[i] = string.Format( "@Type{0}", type_ids[i] );
                    cmd.Parameters.AddWithValue(parameters[i], type_ids[i]);
                }
                sWhere += string.Format("p.Type IN ( {0} )", string.Join(", ", parameters));

            }
            //if ((category_id <= 0) && ( (type_ids == null) || (type_ids.Length == 0 )) ){
            //    sWhere += "    WHERE p.Category IS NULL AND p.Type IS NULL\n";
            //}
            if (product_ids != null && product_ids.Length > 0 )
            {
                int params_added = 0;
                //sWhere += "p.ProductID = " + product_id.ToString() + "\n";
                //sWhere += "p.ProductID = @Product\n";
                //cmd.Parameters.AddWithValue("@Product", product_id );
                List<string> parameters = new List<string>();
                for (int i = 0; i < product_ids.Length; i++)
                {
                    if (product_ids[i] != Guid.Empty)
                    {
                        string param = string.Format("@Product{0}", i);
                        parameters.Add(param);
                        cmd.Parameters.AddWithValue(param, product_ids[i]);
                        params_added++;
                    }
                }
                if (params_added > 0)
                {
                    sWhere += (sWhere.Length > 0 ? "      AND " : "    WHERE ");
                    sWhere += string.Format("p.ProductID IN ( {0} )", string.Join(", ", parameters.ToArray()));
                }
            }
            if ( (order_by != null) && (order_by.Count > 0) )
            {
                sOrder = "";
                foreach (OrderColumn col in order_by)
                {
                    if (sOrder.Length == 0) sOrder = "    ORDER BY ";
                    else sOrder += ", ";
                    sOrder += string.Format("p.{0}", col.ToString());
                }
            }

            string sQuery = "   SELECT p.ProductID, p.ProductName, p.Category, p.Type, p.Maker, p.Barcode,\n" +
                            "          p.Comment, p.Created, p.Updated, p.Deleted,\n" +
                            "          m.Name AS MakerName, m.MakerCategory, m.Vendor,\n" +
                            "          c.CategoryID, c.CategoryName,\n" +
                            "          pt.Name AS TypeName, pt.Comment\n" +
                            "     FROM " + sTable + " AS p\n" +
                            "LEFT JOIN Producer.Makers AS m\n" +
                            "       ON m.MakerId = p.Maker\n" +
                            "LEFT JOIN Producer.Categories AS c\n" +
                            "       ON c.CategoryID = p.Category\n" +
                            "LEFT JOIN Producer.ProductTypes AS pt\n" +
                            "       ON pt.TypeId = p.Type AND\n" +
                            "          pt.Category = p.Category\n" +
                            sWhere +
                            sOrder;
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        public static System.Data.SqlClient.SqlCommand Select( string name, List<OrderColumn> order_by ){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sWhere = "", sOrder = "";
            if ( name.Length > 0){
                sWhere += (sWhere.Length > 0 ? "      AND " : "    WHERE ");
                sWhere += "p.ProductName like @ProductName OR p.Barcode like @ProductName\n";
                cmd.Parameters.AddWithValue("@ProductName", string.Format("%{0}%", name) );
            }
            if ((order_by != null) && (order_by.Count > 0))
            {
                sOrder = "";
                foreach (OrderColumn col in order_by)
                {
                    if (sOrder.Length == 0) sOrder = "\nORDER BY ";
                    else sOrder += ", ";
                    sOrder += string.Format("p.{0}", col.ToString());
                }
            }

            string sQuery = "   SELECT p.ProductID, p.ProductName, p.Category, p.Type, p.Maker, p.Barcode,\n" +
                            "          p.Comment, p.Created, p.Updated, p.Deleted,\n" +
                            "          m.Name AS MakerName, m.MakerCategory, m.Vendor,\n" +
                            "          c.CategoryName,\n" +
                            "          pt.Name AS TypeName, pt.Comment\n" +
                            "     FROM " + sTable + " AS p\n" +
                            "LEFT JOIN Producer.Makers AS m\n" +
                            "       ON m.MakerId = p.Maker\n" +
                            "LEFT JOIN Producer.Categories AS c\n" +
                            "       ON c.CategoryID = p.Category\n" +
                            "LEFT JOIN Producer.ProductTypes AS pt\n" +
                            "       ON pt.TypeId = p.Type AND\n" +
                            "          pt.Category = p.Category\n" +
                            sWhere +
                            sOrder;
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }


        // подготовка параметров для SqlCommand таблицы продуктов
        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command){
            command.Parameters.Add("@ProductID", System.Data.SqlDbType.UniqueIdentifier, 0, "ProductID");
            command.Parameters.Add("@ProductName", System.Data.SqlDbType.NVarChar, 0, "ProductName");
            command.Parameters.Add("@Category", System.Data.SqlDbType.Int, 0, "Category");
            command.Parameters.Add("@Type", System.Data.SqlDbType.Int, 0, "Type");
            command.Parameters.Add("@Maker", System.Data.SqlDbType.Int, 0, "Maker");
            command.Parameters.Add("@Barcode", System.Data.SqlDbType.NVarChar, 0, "Barcode");
            command.Parameters.Add("@Comment", System.Data.SqlDbType.NVarChar, 0, "Comment");
            command.Parameters.Add("@Updated", System.Data.SqlDbType.DateTime, 0, "Updated");
            command.Parameters.Add("@Deleted", System.Data.SqlDbType.Bit, 0, "Deleted");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand Insert(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO Producer.Products\n" +
                            "           (ProductID, ProductName, Category, Type, Maker, Barcode,\n" +
                            "            Comment, Created, Updated, Deleted)\n" +
                            "VALUES (@ProductID, @ProductName, @Category, @Type, @Maker, @Barcode,\n" +
                            "        @Comment, @Created, @Updated, @Deleted)";
            cmd = Product.AddParameters(cmd);
            cmd.Parameters.Add("@Created", System.Data.SqlDbType.DateTime, 0, "Created");
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        public static System.Data.SqlClient.SqlCommand Update(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "UPDATE Producer.Products\n" +
                            "   SET (ProductName = @ProductName, Category = @Category, Type = @Type, Maker = @Maker,\n" +
                            "        Barcode = @Barcode, Comment = @Comment, Updated = @Updated, Deleted = @Deleted)\n" +
                            " WHERE ProductID = @ProductID";
            cmd = Product.AddParameters(cmd);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        public static bool Insert(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "INSERT INTO " + sTable + "\n" +
                                "           (ProductID, ProductName, Category, Type, Maker, Barcode,\n" +
                                "            Comment, Created, Updated, Deleted)\n" +
                                "VALUES (@ProductID, @ProductName, @Category, @Type, @Maker, @Barcode,\n" +
                                "        @Comment, @Created, @Updated, @Deleted)";

                cmd.Parameters.AddWithValue("@ProductID", row["ProductID"]);
                cmd.Parameters.AddWithValue("@ProductName", row["ProductName"]);
                cmd.Parameters.AddWithValue("@Category", row["Category"]);
                cmd.Parameters.AddWithValue("@Type", row["Type"]);
                cmd.Parameters.AddWithValue("@Maker", row["Maker"]);
                cmd.Parameters.AddWithValue("@Barcode", row["Barcode"]);
                cmd.Parameters.AddWithValue("@Comment", row["Comment"]);
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

        public static bool Update(System.Data.SqlClient.SqlConnection connection, System.Data.DataRow row, out string message){
            bool done = false;
            message = "";
            try{
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "UPDATE Producer.Products\n" +
                                "   SET ProductName = @ProductName, Category = @Category, Type = @Type, Maker = @Maker,\n" +
                                "       Barcode = @Barcode, Comment = @Comment, Updated = @Updated, Deleted = @Deleted\n" +
                                " WHERE ProductID = @ProductID";
                cmd.Parameters.AddWithValue("@ProductName", row["ProductName"]);
                cmd.Parameters.AddWithValue("@Category", row["Category"]);
                cmd.Parameters.AddWithValue("@Type", row["Type"]);
                cmd.Parameters.AddWithValue("@Maker", row["Maker"]);
                cmd.Parameters.AddWithValue("@Barcode", row["Barcode"]);
                cmd.Parameters.AddWithValue("@Comment", row["Comment"]);
                cmd.Parameters.AddWithValue("@Created", row["Created"]);
                cmd.Parameters.AddWithValue("@Updated", row["Updated"]);
                cmd.Parameters.AddWithValue("@Deleted", row["Deleted"]);
                cmd.Parameters.AddWithValue("@ProductID", row["ProductID"]);
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

        public static Guid NewID( System.Data.SqlClient.SqlConnection connection, int category_id, out string message ){
            Guid last_id = Guid.Empty;
            message = "";
            try{
                //if (category_id > 0){
                    connection.Open();
                    string sQuery = "SELECT NEWID() AS New_Id\n" +
                                    "  FROM " + sTable + "\n" +
                                    "WHERE Category = " + category_id.ToString();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sQuery);
                    cmd.Connection = connection;
                    object res = cmd.ExecuteScalar();
                    if (System.Convert.IsDBNull(res)) last_id = Guid.Empty;
                    else last_id = (Guid)res;
                    connection.Close();
                //}else
                //    message = "Необходимо указать категорию!";
            }catch(System.Exception ex ){
                message = ex.Message;
            }
            return last_id;
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
                string sQuery = "DELETE FROM Producer.Products\n" +
                                " WHERE ProductID = @ProductID";
                cmd.Parameters.AddWithValue("@ProductID", row["ProductID"]);
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

    }
}
