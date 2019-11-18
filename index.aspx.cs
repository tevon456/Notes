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

            try
            {

            }
            catch (Exception)
            {
                throw;
            }

            connection.Open();
      
            var where = "email = @email And password=@password";
            command.CommandText = Helper.SelectFromWhere("*","Users",where);
            Helper.ParamaterFromInput("@email", TextBoxEmail.Text);
            Helper.ParamaterFromInput("@password", TextBoxPassword.Text);

            connection.Close();
        }

     
    }
}