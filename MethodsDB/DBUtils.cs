using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace DBMethods
{
    public class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "mysql-kitbox2020.alwaysdata.net";
            int port = 3306;
            string database = "kitbox2020_ecam";
            string username = "199703";
            string password = "groupe2020";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
