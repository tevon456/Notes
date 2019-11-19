using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Notes
{
    public class Helper
    {
        SqlConnection connection;
        SqlCommand command;
        public void Init()
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[""].ConnectionString;
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text; 
        }

        public static string SelectFromWhere(string select, string from, string where)
        {
            string query = "Select" + select + " from " + from + " Where " + where;
            return query;
        }

        
    }
}