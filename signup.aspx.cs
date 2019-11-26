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
            if (Session["sessionUser"] != null)
            {
                Response.Redirect("home.aspx");
            }
            else if (Session["sessionAdmin"] != null)
            {
                Response.Redirect("admin.aspx");
            }
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;

        }

        protected void btn_signup_Click(object sender, EventArgs e)
        {
            connection.Open();
            
            //Check the email
            command.CommandText = Helper.SelectFromWhere("id", "Users", "email=@email");
            command.Parameters.AddWithValue("@email", TextBoxSignupEmail.Text);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //If the email is taken right a message
                reader.Close();
                lb_msg.Text = "email already in use";

            }
            else
            {
                reader.Close();
                var fields = "full_name,email,password,role,active";
                var values = "@full_name,@email,@password,'user',1";
                command.CommandText = Helper.InsertInto("users", fields, values);
                command.Parameters.AddWithValue("@password", TextBoxSignupPassword.Text);
                command.Parameters.AddWithValue("@email", TextBoxSignupEmail.Text);
                command.Parameters.AddWithValue("@full_name", TextBoxSignupName.Text);
                command.ExecuteNonQuery();

                lb_msg_ok.Text = "account created";
            }

            connection.Close();

            //var reader = command.ExecuteReader();

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

        }
    }
}