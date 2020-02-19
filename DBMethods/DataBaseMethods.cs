using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;  


namespace DBMethods
{
    public static class DataBaseMethods
    {
        public static void SqlAddCustomer(string firstname, string surname, string adress, string email, string phone, string username, string password)
        {
            MySqlConnection conn = DBMethods.DBUtils.GetDBConnection();
            conn.Open();
            password = sha256_hash(password);
            string query = "INSERT INTO users (surname, firstname, address, email, phone, username, password) VALUE('" + firstname + "','" + surname + "','" + adress + "','" + email + "','" + phone + "','" + username + "','" + password + "');";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("Connection closed");
        }
        public static void SqlAdd(string table, string paramage, string paramname, int valueAge, string valueNom, MySqlConnection conn)
        {

            string query = "INSERT INTO " + table + "(" + paramname + "," + paramage + ") VALUE('" + valueNom + "'," + valueAge + ")";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        public static void SqlDelete(string table, string paramID, int valueID, MySqlConnection conn)
        {
            string query = "DELETE FROM " + table + " WHERE " + paramID + "=" + valueID;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        public static void SqlSelect(string paramID, string table, MySqlConnection conn)
        {
            string query = "SELECT " + paramID + " FROM " + table;
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[paramID]);
            }
            reader.Close();

        }
        public static MySqlDataReader SqlSearch(string table, string param, string value, MySqlConnection conn)
        {

            string query = "SELECT * FROM " + table + " WHERE " + param + "=" + value;
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();

            return reader;

        }

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

    }
}