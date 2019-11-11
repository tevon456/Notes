using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Notes
{
    public partial class index : System.Web.UI.Page
    {
        SqlConnection connection;
        SqlCommand command;
        protected void Page_Load(object sender, EventArgs e)
        {
       
                connection = new SqlConnection();
                command = new SqlCommand();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;     
        }

        private static string SelectFromWhere(string select, string from, string where)
        {
            string query = "Select" + select + " from " + from + " Where " + where;
            return query;
        }

        protected void btn_login_Click(object sender,EventArgs e)
        {
            connection.Open();
            command.CommandText = SelectFromWhere("*","Users","email = @email And password=@password");
            connection.Close();
        }
    }
}