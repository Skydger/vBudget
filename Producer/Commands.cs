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
        public static System.Data.SqlClient.SqlCommand Products(int category_in, int product_id ){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string whr = "";
            if (category_in >= 0){
                whr += "\nWHERE Category = @Category";
                cmd.Parameters.AddWithValue("@Category", category_in);
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
