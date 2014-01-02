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
        static protected System.Data.SqlClient.SqlCommand AddParameters(System.Data.SqlClient.SqlCommand command)
        {
            command.Parameters.Add("@Login", System.Data.SqlDbType.Int, 0, "Login");
            command.Parameters.Add("@Surname", System.Data.SqlDbType.NVarChar, 0, "Surname");
            command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 0, "Name");
            command.Parameters.Add("@SecondName", System.Data.SqlDbType.NVarChar, 0, "SecondName");
            command.Parameters.Add("@UserType", System.Data.SqlDbType.Int, 0, "UserType");
            return command;
        }

        public static System.Data.SqlClient.SqlCommand Insert()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "INSERT INTO " + Users.Table + "\n" +
                            "           (Login, Surname, Name, SecondName, UserType)\n" +
                            "VALUES (@Login, @Surname, @Name, @SecondName, @UserType)";
            cmd = Users.AddParameters(cmd);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        public static System.Data.SqlClient.SqlCommand Update()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string sQuery = "UPDATE " + Users.Table + "\n" +
                            "   SET Login = @Login, Surname = @Surname, Name = Name,\n" +
                            "       SecondName = @SecondName, UserType = @UserType\n" +
                            " WHERE UserID = @UserID";
            cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int, 0, "UserID");
            cmd = Users.AddParameters(cmd);
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }
    }
}
