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
            if (Session["sessionUser"] != null)
            {
                Response.Redirect("home.aspx");
            }else if (Session["sessionAdmin"] != null)
            {
                Response.Redirect("admin.aspx");
            }
                connection = new SqlConnection();
                command = new SqlCommand();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                
                //Storing key value application state for later
                Application["Version"] = "1.1.4";
                Application["Creators"] = " Tevon Davis, Gerard Neil and Daquane Hunter";
                Page.Title = Request.QueryString["test"];
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

                //Accept the selected value from the login select and then redirect to that page
                switch (DropDownListRole.SelectedValue.ToString())
                {
                    case "user":
                        //Redirect to user homepage after login
                        Session["sessionUser"] = reader[0].ToString();
                        Response.Redirect("home.aspx");
                        break;
                    case "admin":
                        //Redirect to admin
                        Session["sessionAdmin"] = reader[0].ToString();
                        Response.Redirect("admin.aspx");
                        break;
                    default:
                        Response.Redirect("home.aspx");
                        break;
                }
                reader.Close();
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