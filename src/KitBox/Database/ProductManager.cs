using System;
using Npgsql;
using System.Collections.Generic;

namespace KitBox
{
	public class ProductManager
	{
		private NpgsqlConnection connection;
		private NpgsqlCommand command;

		public ProductManager(NpgsqlConnection conn)
		{
			this.connection = conn;
		}

		public List<Product> SelectAllProduct()
		{
			this.connection.Open();
			string select = "SELECT * FROM \"product\"";
			this.command = new NpgsqlCommand(select, this.connection);
			NpgsqlDataReader reader = this.command.ExecuteReader();
			List<Product> products = new List<Product>();
			while (reader.Read())
			{
				Dimensions specs = new Dimensions((int)reader["height"], (int)reader["depth"], (int)reader["width"]);
				Color color;
				switch ((string)reader["color"])
				{
					case "Blanc":
						color = new Color(255, 255, 255);
						break;
					case "Brun":
						color = new Color(91, 60, 17);
						break;
					case "Noir":
						color = new Color(0, 0, 0);
						break;
					case "Galvanisé":
						color = new Color(224, 223, 219);
						break;
					default:
						color = new Color();
						break;
				}
				Product product = new Product((string)reader["reference"], (string)reader["code"], specs, color, (int)reader["stock"], (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"]);
				products.Add(product);
			}

			reader.Close();
			this.connection.Close();

			return products;
		}
	}
}
