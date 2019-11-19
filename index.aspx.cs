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
 
            var where = "email = @email And password=@password";
            command.CommandText = Helper.SelectFromWhere("*","Users",where);
            command.Parameters.AddWithValue("@password", TextBoxPassword.Text);
            command.Parameters.AddWithValue("@email", TextBoxEmail.Text);

            connection.Close();
        }

     
    }
}