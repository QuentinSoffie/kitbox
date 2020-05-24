using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

		public static bool CheckStockForOrder(int qtty, int code, MySqlConnection conn)
		{
			string query = "SELECT * FROM Piece WHERE " + "Code ='" + code + "'";
			MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();

			while(reader.Read())
			{
				int inStock = int.Parse(reader["Enstock"].ToString());

				if( inStock >= qtty)
				{
					reader.Close();
					conn.Close();
					return true;
				}
				else
				{
					reader.Close();
					conn.Close();
					return false;
				}
			}

			return false;
		}

		public static List<Dictionary<string,string>> CheckStockForSupplier(MySqlConnection conn)
		{
			List<Dictionary<string,string>> List = new List<Dictionary<string,string>>();

			conn.Open();

			string query = "SELECT * FROM Piece";
			MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();

			while (reader.Read())
			{
				Dictionary<string, string> component = new Dictionary<string, string>
					{
						{ "Ref", reader["Ref"].ToString() },
						{ "Code", reader["Code"].ToString() },
						{ "Dimensions", reader["Dimensions(cm)"].ToString() },
						{ "Height", reader["hauteur"].ToString() },
						{ "Width", reader["largeur"].ToString() },
						{ "Depth", reader["profondeur"].ToString() },
						{ "Color", reader["Couleur"].ToString() },
						{ "CustomerPrice", reader["Prix-Client"].ToString() },
						{ "Stock", reader["Enstock"].ToString() },
						{ "StockMin", reader["Stock minimum"].ToString() },
						{ "SupplierOnePrice", reader["Prix-Fourn 1"].ToString() },
						{ "SupplierTwoPrice", reader["Prix-Fourn2"].ToString() },
						{ "SupplierOneDelay", reader["Delai-Fourn 1"].ToString() },
						{ "SupplierTwoDelay", reader["Delai-Fourn2"].ToString() }
					};
				
				int inStock = int.Parse(component["Stock"].ToString());
				int minStock = int.Parse(component["StockMin"].ToString());

				if (inStock < minStock)
				{
					List.Add(component);
				}
			}

			reader.Close();

			conn.Close();
			return List ;
			}


		public static List<string> GetCodeFromDB(MySqlConnection conn)
		{
			List<string> code = new List<string>() ;
			string query = "SELECT * FROM Piece ";
			MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();

			while(reader.Read())
			{
				code.Add(reader["Code"].ToString());
			}

			reader.Close();

			return code;
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
		public static MySqlDataReader SearchOrderById(string id, MySqlConnection conn)
		{
			string query = "SELECT * FROM Orders" + " WHERE " + "IdClient ='" + id + "'";
			MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();

			return reader;
		}

		public static void AddComponent(string reference, string code, string dimension, int height, int width, int depth, string color, int inStock, int minStock, string priceCustomer, int qttyPart, string priceFour1, int delayFour1, string priceFour2, int delayFour2,  MySqlConnection conn)
		{
			conn.Open();
			string query = "INSERT INTO Piece (Ref, Code, `Dimensions(cm)`, hauteur, profondeur, largeur, Couleur, Enstock, `Stock minimum`, `Prix-Client`, `Nb-Pieces/casier`, `Prix-Fourn 1`, `Delai-Fourn 1`, `Prix-Fourn2`, `Delai-Fourn2`) VALUES ('" + reference + "','" + code + "','" + dimension + "','" + height + "','" + width + "','" + depth + "','" + color + "','" + inStock + "','" + minStock + "','" + priceCustomer + "','" + qttyPart + "','" + priceFour1 + "','" + delayFour1 + "','" + priceFour2 + "','" + delayFour2 + "')";
			MySqlCommand cmd = new MySqlCommand(query, conn);
			cmd.ExecuteNonQuery();
			conn.Close();
		}
		public static void DeleteComponent(string code, MySqlConnection conn)
		{
			conn.Open();
			string query = "DELETE FROM Piece WHERE Code ='" + code +"'";
			MySqlCommand cmd = new MySqlCommand(query, conn);
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		public static bool AddQtty(string code,int qtty, MySqlConnection conn)
		{
			conn.Open();
			string query1 = "SELECT * FROM Piece" + " WHERE " + "Code ='" + code + "'";
			MySqlDataReader reader = new MySqlCommand(query1, conn).ExecuteReader();
			int stock = 0;
			while (reader.Read())
			{
				stock = reader.GetInt32("Enstock");
			}
			reader.Close();
			int newStock = qtty + stock;
			Console.WriteLine("check new quantity");
			if (newStock >= 0)
			{
				Console.WriteLine("updating...");
				string query2 = "UPDATE Piece SET Enstock = '" + newStock + "' WHERE Code ='" + code + "'";
				MySqlDataAdapter SDA = new MySqlDataAdapter(query2, conn);
				SDA.SelectCommand.ExecuteNonQuery();
				conn.Close();
				return true;
			}
			else
			{
				conn.Close();
				return false;
			}
		}

		public static void UpdateSupplierInfo(string code, string param, string value, MySqlConnection conn)
		{
			conn.Open();
			string query = "UPDATE Piece SET " + param +  "= '" + value + "' WHERE Code ='" + code + "'";
			MySqlDataAdapter SDA = new MySqlDataAdapter(query, conn);
			SDA.SelectCommand.ExecuteNonQuery();
			conn.Close();
		}

		public static void UpdateOrderState(string numOrder, string state, MySqlConnection conn)
		{
			conn.Open();
			string query = "UPDATE Orders SET State = '" + state + "' WHERE NumOrder ='" + numOrder + "'";
			MySqlDataAdapter SDA = new MySqlDataAdapter(query, conn);
			SDA.SelectCommand.ExecuteNonQuery();
			conn.Close();
		}
	}
}
