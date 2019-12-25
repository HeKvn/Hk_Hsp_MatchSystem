using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace DAL
{
    public class Class1
    {
        object result;
        object result1;
        public bool select(Model.Users user)
        {
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            MySqlConnection con = new MySqlConnection(str1);
            con.Open();
            string sqlstr = "select stuid from stu where name=@name and pwd=@pwd";
            MySqlCommand cmd = new MySqlCommand(sqlstr, con);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@pwd", user.pwd);
            result = cmd.ExecuteScalar();
            con.Close();
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool select1(Model.Users user)
        {
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            MySqlConnection con = new MySqlConnection(str1);
            con.Open();
            string sqlstr = "select stuid from stu where name=@name and tel=@tel";
            MySqlCommand cmd = new MySqlCommand(sqlstr, con);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@tel", user.tel);
            result1 = cmd.ExecuteScalar();
            con.Close();
            if (result1 == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
