using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace DBMethods
{
    public class DBUtils
    {
        public static MySqlConnection GetDBConnection(string username, string password)
        {
            string host = "mysql-kitbox2020.alwaysdata.net";
            int port = 3306;
            string database = "kitbox2020_ecam";


            return DBMySQLUtils.GetDBConnection(host, port, database, "199703_" + username, password);
        }
    }
}
