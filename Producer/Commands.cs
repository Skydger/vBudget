using System;
using System.Collections.Generic;
using System.Text;

namespace Producer
{
    public class Commands{
        public static System.Data.SqlClient.SqlCommand ProductCategories(){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "SELECT CategoryID, CategoryName\n" +
                            "  FROM Producer.Categories\n" +
                            " ORDER BY CategoryName";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
        public static System.Data.SqlClient.SqlCommand Products(int category_id, int product_id ){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string whr = "";
            if (category_id >= 0){
                whr += "\nWHERE Category = @Category";
                cmd.Parameters.AddWithValue("@Category", category_id);
            }
            if (product_id >= 0){
                whr += (whr.Length == 0 ? "\nWHERE " : "\n  AND ");
                whr += "ProductID = @Product";
                cmd.Parameters.AddWithValue("@Product", product_id);
            }

            string sQuery = "SELECT ProductID, ProductName, Category, Type, Maker,\n" +
                            "       Barcode, Comment, Created, Updated, Deleted\n" +
                            "  FROM Producer.Products" +
                            whr +
                            "\nORDER BY ProductName";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

    }
}
