using System;
using MySql.Data.MySqlClient;

namespace MethodsDB
{
    /// <summary>
    /// This is the class used to get the connection with the database.
    /// </summary>
    public class DBMySQLUtils
    {
        public static MySqlConnection
        GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                 + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
