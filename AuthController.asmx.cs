using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace Notes
{
    /// <summary>
    /// Summary description for AuthController
    /// </summary>
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AuthController : System.Web.Services.WebService
    {
        SqlConnection connection;
        SqlCommand command;

        //LOGIN CONTROLLER
        [WebMethod]
        public string[] Login(string password, string email, string role)
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;


            var where = "email=@email And password=@password And role=@role";
            command.CommandText = Helper.SelectFromWhere("*", "Users", where);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@role", role);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Application["test"] = reader[0].ToString();
                string[] response = new string[] { "success", "user created" };

                switch (role)
                {
                    case "user":
                        //Redirect to user homepage after login
                        Session["sessionUser"] = reader[0].ToString();
                        Session["user_id"] = reader[0];
                        Session["name"] = reader[1];
                        Session["email"] = reader[2];
                        response[2] = "home.aspx";
                        break;
                    case "admin":
                        //Redirect to admin
                        Session["sessionAdmin"] = reader[0].ToString();
                        Session["user_id"] = reader[0];
                        Session["name"] = reader[1];
                        Session["email"] = reader[2];
                        response[2] = "admin.aspx";
                        break;
                    default:
                        //Response.Redirect("home.aspx");
                        break;
                        
                }
                reader.Close();
                return response;

            }
            else
            {
                reader.Close();
                connection.Close();
                string[] response = new string[] { "error", "It seams your credentials are incorrect or your account is deactivated","index.aspx" };
                return response;
            }

            

        }



        //SIGNUP CONTROLLER
        [WebMethod]
        public string[] Signup(string email,string password,string full_name)
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;

            connection.Open();

            //Check the email
            command.CommandText = Helper.SelectFromWhere("id", "Users", "email=@email");
            command.Parameters.AddWithValue("@email", email);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //If the email is taken right a message
                reader.Close();
                string[] response = new string[] { "error","email already in use" };
                return response;
            }
            else
            {
                reader.Close();
                var fields = "full_name, email, password,role,active";
                var values = "@full_name, @emailAgain, @password,'user',1";
                command.CommandText = Helper.InsertInto("users", fields, values);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@emailAgain", email);
                command.Parameters.AddWithValue("@full_name", full_name);
                command.ExecuteNonQuery();

                string[] response = new string[] { "success", "account created" };
                connection.Close();
                return response;
            }
        }


    }
}
