using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial;
using MySql.Data.MySqlClient;

namespace ConnectMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();
                Console.WriteLine("Connection successful!");
                SqlAdd("ClientMagasin","Age", "Nom", 20 ,"Myngheer", conn);
                SqlSelect("Nom", "ClientMagasin", conn);
                SqlDelete("ClientMagasin","NumClient",25,conn);
                SqlSelect("Nom", "ClientMagasin", conn);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();

        }

        static void SqlAdd(string table, string paramage,string paramname,int valueAge, string valueNom, MySqlConnection conn)
        {

            string query = "INSERT INTO "+ table+"("+paramname+","+paramage+") VALUE('"+valueNom+"',"+valueAge+")";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Rajouté");
        }

        static void SqlDelete(string table, string paramID, int valueID, MySqlConnection conn)
        {
            string query = "DELETE FROM " + table + " WHERE " + paramID + "=" + valueID;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Supprimé");
        }

        static void SqlSelect(string paramID, string table, MySqlConnection conn)
        {
            string query = "SELECT " + paramID + " FROM " + table;
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader[paramID]);
            }
            reader.Close();
           
        }
    }
}
