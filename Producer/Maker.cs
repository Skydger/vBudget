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
            string sQuery = "   SELECT MakerId, Name, MakerCategory, Vendor\n" +
                            "     FROM " + Maker.Table + "\n" +
                            sWhere +
                            "ORDER BY Name";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
    }
}
