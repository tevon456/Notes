using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Notes
{
    //User defined class
    public class Helper
    {
        SqlConnection connection;
        SqlCommand command;
        public void Init()
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[""].ConnectionString;
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text; 
        }
        //User defined methods available across the Notes namespace

        //A method that amkes composing Select queries a bit easier 
        public static string SelectFromWhere(string select, string from, string where)
        {
            string query = "Select " + select + " from " + from + " Where " + where + "";
            return query;
        }

        // A method tha makes composing insert queries easier 
        public static string InsertInto(string into, string fields, string values)
        {
            string query = "INSERT INTO " + into + "(" + fields + ") VALUES (" + values +")";
            return query;
        }

        public static string DeleteFrom(string table, string condition)
        {
            string query = "DELETE FROM "+table+" WHERE "+condition+" ";
            return query;
        }

        

    }
}