using MySql.Data.MySqlClient;

namespace MethodsDB
{
    /// <summary>
    /// This is the class used to connect the program with the database.
    /// </summary>
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
