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
    public partial class signup : System.Web.UI.Page
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

        protected void btn_signup_Click(object sender, EventArgs e)
        {
            connection.Open();

            command.Parameters.AddWithValue("@password", TextBoxSignupPassword.Text);
            command.Parameters.AddWithValue("@email", TextBoxSignupEmail.Text);
            command.Parameters.AddWithValue("@full_name", TextBoxSignupName.Text);

            var fields = "full_name,email,password,role,active";
            var values = "@full_name,@email,@password,'user',1";
            command.CommandText = Helper.InsertInto("users", fields, values);

            command.ExecuteNonQuery();
            lb_msg.Text = "inserting data";

            var reader = command.ExecuteReader();

            //if (reader.Read())
            //{
                //initalize a session name and associated session value
              //  Session["sessionId"] = reader[0].ToString();
              //  reader.Close();
            //}
            //else
            //{
              //  reader.Close();
                //lb_msg.Text = "Something went wrong when processing your request";
            //}

            connection.Close();
        }
    }
}