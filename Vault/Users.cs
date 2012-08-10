using System;
using System.Collections.Generic;
using System.Text;

namespace Vault
{
    public class Users{
        private static string Table = "Persons.Users";

        public static System.Data.SqlClient.SqlCommand Select(int user_id){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "SELECT p.UserID, p.Login, p.Surname, p.Name, p.SecondName, p.UserType,\n" +
                            "       p.Surname + ' ' + SUBSTRING(p.Name, 1,1) + '. ' + \n" +
                            "       SUBSTRING(p.SecondName, 1,1) + '.' AS UserFullName\n" +
                            "FROM " + Users.Table + " AS p\n" +
                            "ORDER BY p.Surname, p.Name, p.SecondName";
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

    }
}
