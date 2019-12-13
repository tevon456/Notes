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
            AuthService.AuthControllerSoapClient client = new AuthService.AuthControllerSoapClient();
            var res = client.Login(TextBoxPassword.Text, TextBoxEmail.Text, DropDownListRole.SelectedValue);
            

            if(res[0] == "success")
            {
                lb_msg.Text = res[2];
                switch (DropDownListRole.SelectedValue)
                {
                    case "user":
                        //Redirect to user homepage after login
                        Session["sessionUser"] = res[3];
                        Session["user_id"] = res[4];
                        Response.Redirect(res[2]);
                        break;
                    case "admin":
                        //Redirect to admin
                        Session["sessionAdmin"] = res[3];
                        Session["user_id"] = res[4];
                        Response.Redirect(res[2]);
                        break;
                    default:
                        Response.Redirect("home.aspx");
                        break;

                }

            }
            else
            {
                lb_msg.Text = res[1];
            }
            
        }

     
    }
}