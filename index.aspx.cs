using System;
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

        protected void btn_login_Click(object sender,EventArgs e)
        {

            connection.Open();

            if(DropDownListRole.SelectedValue.ToString() == "")
            { 
               lb_msg.Text = "You haven't selected your user role";
            }

            var where = "email=@email And password=@password And role=@role";
            command.CommandText = Helper.SelectFromWhere("*","Users",where);
            command.Parameters.AddWithValue("@password", TextBoxPassword.Text);
            command.Parameters.AddWithValue("@email", TextBoxEmail.Text);
            command.Parameters.AddWithValue("@role", DropDownListRole.SelectedValue);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                //initalize a session name and associated session value
                Session["sessionId"] = reader[0].ToString();
                lb_msg.Text = "reading";

                reader.Close();
                //Accept the selected value from the login select and then redirect to that page
                switch (DropDownListRole.SelectedValue.ToString())
                {
                    case "user":
                        //Redirect to user homepage after login
                        Response.Redirect("home.aspx");
                        break;
                    case "admin":
                        //Redirect to admin
                        Response.Redirect("admin.aspx");
                        break;
                    default:
                        Response.Redirect("home.aspx");
                        break;
                }
            }
            else
            {

                reader.Close();
                lb_msg.Text = "It seams your credentials are incorrect or your account is deactivated";
            }

            connection.Close();
        }

     
    }
}