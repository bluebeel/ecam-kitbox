using System;
using System.Drawing;
using UnityNpgsql;
using UnityNpgsqlTypes;
using System.Collections.Generic;

public class ProductManager
{
	private NpgsqlConnection connection;
	private NpgsqlCommand command;

	public ProductManager(NpgsqlConnection conn)
	{
		this.connection = conn;
	}

	public StockProduct GenerateProduct(NpgsqlDataReader reader)
	{
		Dimensions specs = new Dimensions((int)reader["width"], (int)reader["height"], (int)reader["depth"]);
		return new StockProduct((string)reader["reference"], (string)reader["code"], specs, (string)reader["color"], (int)reader["stock"], (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"]);
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
			product = GenerateProduct(reader);
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
			products.Add(GenerateProduct(reader));
		}

		reader.Close();
		this.connection.Close();

		return products;
	}
}

