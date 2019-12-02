using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Notes
{
    public partial class NoteDetails : System.Web.UI.Page
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


            connection.Open();
            var where = "Id=@id And user_id=@user";
            command.CommandText = Helper.SelectFromWhere("*", "Notes", where);
            command.Parameters.AddWithValue("@user", Session["user_id"]);
            command.Parameters.AddWithValue("@id", Request.QueryString["noteID"]);
            
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Title.Text = reader[2].ToString();
                Body.Text = reader[3].ToString();
                reader.Close();
            }
            connection.Close();
        }
    }
}