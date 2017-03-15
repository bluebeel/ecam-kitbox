using System;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Drawing;

namespace KitBox
{
	public class ProductManager
	{
		private NpgsqlConnection connection;
		private NpgsqlCommand command;
		private ProductFactory factory = new ProductFactory();

		public ProductManager(NpgsqlConnection conn)
		{
			this.connection = conn;
		}

		public StockProduct SelectProduct(string code)
		{
			StockProduct product = null;
			this.connection.Open();
			string select = "SELECT * FROM \"product\" WHERE(code=:code)";
			this.command = new NpgsqlCommand(select, this.connection);

			this.command.Parameters.Add(new NpgsqlParameter("code", NpgsqlDbType.Varchar)).Value = code;

			NpgsqlDataReader reader = this.command.ExecuteReader();
			while (reader.Read())
			{
				product = factory.getProduct(reader);
			}
			reader.Close();
			this.connection.Close();
			return product;
		}

		public List<StockProduct> SelectAllProduct()
		{
			this.connection.Open();
			string select = "SELECT * FROM \"product\"";
			this.command = new NpgsqlCommand(select, this.connection);
			NpgsqlDataReader reader = this.command.ExecuteReader();
			List<StockProduct> products = new List<StockProduct>();
			while (reader.Read())
			{
				products.Add(factory.getProduct(reader));
			}

			reader.Close();
			this.connection.Close();

			return products;
		}
	}
}
