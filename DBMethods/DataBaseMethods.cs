using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DBMethods
{
    public class DataBaseMethods
    {
        public static void SqlAddCustomer(string firstname, string surname, string adress, string email, string phone, MySqlConnection conn)
        {
            string query = String.Format("INSERT INTO ClientMagasin (Nom, Prenom, Adresse, Email, Tel ) VALUE('{0}', '{1}', '{2}', '{3}', '{4}')", firstname, surname, adress, email, phone);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Customer added");
        }
        public static void SqlAdd(string table, string paramage, string paramname, int valueAge, string valueNom, MySqlConnection conn)
        {

            string query = "INSERT INTO " + table + "(" + paramname + "," + paramage + ") VALUE('" + valueNom + "'," + valueAge + ")";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Added");
        }

        public static void SqlDelete(string table, string paramID, int valueID, MySqlConnection conn)
        {
            string query = "DELETE FROM " + table + " WHERE " + paramID + "=" + valueID;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Supprimé");
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
        public static MySqlDataReader SqlLoadComboBox(string param, string table, string value, MySqlConnection conn)
        {
            string query = "SELECT * FROM " + table + " WHERE " + param + "=" + value;
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();


            return reader;

        }
    }
}