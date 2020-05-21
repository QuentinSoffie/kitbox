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
        public static void SqlAddCustomer(string firstname, string surname, string adress, string email, string phone, MySqlConnection conn)
        {
            conn.Open();
            string query = "INSERT INTO users (surname, firstname, address, email, phone,) VALUE('" + firstname + "','" + surname + "','" + adress + "','" + email + "','" + phone + "');";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("User addes");
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

        public static void SqlUpdateCustomer(string param,string value, int id,  MySqlConnection conn)
        {
            conn.Open();
            string query = "UPDATE users SET" + param + "= '" + value + "' WHERE id ='" + id + "'";
            MySqlDataAdapter SDA = new MySqlDataAdapter(query, conn);
            SDA.SelectCommand.ExecuteNonQuery();
            conn.Close();
        }
        public static MySqlDataReader SqlSearchComponent(string table, string param1, string param2, string param3, string value1, string value2, string value3, MySqlConnection conn)
        {

            string query = "SELECT * FROM " + table + " WHERE " + param1 + "= '" + value1 + "' AND " + param2 + "='" + value2 + "' AND " + param3 + "='" + value3 +"'";
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();

            return reader;

        }

        public static MySqlDataReader SqlSearchCustomer( string id, MySqlConnection conn)
        {
            string query = "SELECT * FROM users WHERE id = '" + id +"'";
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