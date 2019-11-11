using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Notes
{
    public class SqlModel
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
    }
}