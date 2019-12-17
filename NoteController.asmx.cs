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
    /// Summary description for NoteController
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NoteController : System.Web.Services.WebService
    {

        SqlConnection connection;
        SqlCommand command;

        [WebMethod]
        public string[] CreateNote(string title,string body,string user_id)
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;

            connection.Open();
                
            var fields = "user_id,title,body";
            var values = "@user_id,@title,@body";
            command.CommandText = Helper.InsertInto("Notes", fields, values);
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@body", body);
            command.ExecuteNonQuery();

            string[] response = new string[] { "success", "note created" };
            connection.Close();
            return response;
            
        }


        [WebMethod]
        public string[] DeleteNote(string id)
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;

            connection.Open();
            command.CommandText = Helper.DeleteFrom("Notes","id=@id");
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            string[] response = new string[] { "success", "note deleted" };
            connection.Close();
            return response;
        }
    }
}
