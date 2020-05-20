using System;
using MySql.Data.MySqlClient;

namespace StockDB
{
	public class StockMethod
	{


		public static MySqlDataReader SearchComponent(string name, int height, int width, int depth, string color, MySqlConnection conn)
		{
			string query = "SELECT * FROM Piece" + " WHERE " + "REF ='" + name + "' AND hauteur ='" + height + "' AND largeur ='" + width + "' AND profondeur ='" + depth + "' AND Couleur ='" + color + "'" ;
			MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();

			return reader;

			//DANS LE READER RECUPERER LA VALEUR DU STOCK POUR POUVOIR L'ENVOYER DANS LA METHODE D'UPDATE DU STOCK

		}

		public static MySqlDataReader SearchOrderByName(string customerName, MySqlConnection conn)
		{
			string query = "SELECT * FROM Orders" + " WHERE " + "Customer ='" + customerName + "'";
			MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();

			return reader;
		}

		public static MySqlDataReader SearchOrderByNum(string numOrder, MySqlConnection conn)
		{
			string query = "SELECT * FROM Orders" + " WHERE " + "NumOrder ='" + numOrder + "'";
			MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();

			return reader;
		}

		public static void AddPart(string reference, string code, int dimension, int height, int width, int depth, string color, int inStock, int minStock, int priceCustomer, int qttyPart, int priceFour1, int delayFour1, int priceFour2, int delayFour2,  MySqlConnection conn)
		{

			string query = "INSERT INTO PIECE (Ref, Code, Dimension(cm), hauteur, profondeur, largeur,Couleur, Enstock, Stock minimum, Prix-Client, Nb-Pièces/casier, Prix-Fourn 1, Delai-Fourn 1, Prix-Fourn 2, Delai-Fourn 2) VALUE('" + reference + "','" + code + "','" + dimension + "','" + height + "','" + width + "','" + depth + "','" + color + "','" + inStock + "','" + minStock + "','" + priceCustomer + "','" + qttyPart + "','" + priceFour1 + "','" + delayFour1 + "','" + priceFour2 + "','" + delayFour2 + "')";
			MySqlCommand cmd = new MySqlCommand(query, conn);
			cmd.ExecuteNonQuery();
		}

		public static void Addqtty(int code,int qtty, MySqlConnection conn)
		{
			string query1 = "SELECT * FROM Piece" + " WHERE " + "Code ='" + code + "'";
			MySqlDataReader reader = new MySqlCommand(query1, conn).ExecuteReader();
			int stock = 0;
			while (reader.Read())
			{
				stock = reader.GetInt32("stock");
			}
			reader.Close();
			int newStock = qtty + stock;
			conn.Open();
			string query2 = "UPDATE Piece SET Enstock = '" + newStock + "' WHERE Code ='" + code +"'";
			MySqlDataAdapter SDA = new MySqlDataAdapter(query2, conn);
			SDA.SelectCommand.ExecuteNonQuery();
			conn.Close();
		}

		public static void Deleteqtty(int code, int qtty, MySqlConnection conn)
		{
			string query1 = "SELECT * FROM Piece" + " WHERE " + "Code ='" + code + "'";
			MySqlDataReader reader = new MySqlCommand(query1, conn).ExecuteReader();
			int stock = 0;
			while(reader.Read())
			{
				stock = reader.GetInt32("stock");
			}
			reader.Close();
			int newStock = stock - qtty;
			conn.Open();
			string query2 = "UPDATE Piece SET Enstock = '" + qtty + "' WHERE Code ='" + code + "'";
			MySqlDataAdapter SDA = new MySqlDataAdapter(query2, conn);
			SDA.SelectCommand.ExecuteNonQuery();
			conn.Close();
		}
	}
}
