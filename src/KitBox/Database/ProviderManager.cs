using System;
using UnityNpgsql;
using UnityNpgsqlTypes;
using System.Collections.Generic;

public class ProviderManager
{
	private NpgsqlConnection connection;
	private NpgsqlCommand command;

	public ProviderManager(NpgsqlConnection conn)
	{
		this.connection = conn;
	}

	public Provider SelectProvider(string nameSociety)
	{
		Provider provider = null;
		this.connection.Open();
		string select = "SELECT * FROM \"provider\" WHERE(nameSociety=:name_society)";
		this.command = new NpgsqlCommand(select, this.connection);

		this.command.Parameters.Add(new NpgsqlParameter("name_society", NpgsqlDbType.Varchar)).Value = nameSociety;

		NpgsqlDataReader reader = this.command.ExecuteReader();
		while (reader.Read())
		{
			provider = new Provider((string)reader["name_society"], (string)reader["name_shop"], (string)reader["address"], (string)reader["city"]);
			provider.Id = (int)reader["id"];
		}
		reader.Close();
		this.connection.Close();
		return provider;
	}

	public Provider InsertProvider(Provider provider)
	{
		this.connection.Open();
		string insert = "INSERT INTO \"provider\"(name_society, name_shop, address, city) values(:name_society, :name_shop, :address, :city)";
		this.command = new NpgsqlCommand(insert, this.connection);

		this.command.Parameters.Add(new NpgsqlParameter("name_society", NpgsqlDbType.Varchar)).Value = provider.Society;
		this.command.Parameters.Add(new NpgsqlParameter("name_shop", NpgsqlDbType.Varchar)).Value = provider.Shop;
		this.command.Parameters.Add(new NpgsqlParameter("address", NpgsqlDbType.Varchar)).Value = provider.Address;
		this.command.Parameters.Add(new NpgsqlParameter("city", NpgsqlDbType.Varchar)).Value = provider.City;

		this.command.ExecuteNonQuery();

		this.connection.Close();

		provider.Id = SelectProvider(provider.Society).Id;

		return provider;
	}

	public Provider UpdateProvider(Provider provider)
	{
		this.connection.Open();
		string update = "UPDATE \"customer\" SET name_society:name_society, name_shop:name_shop, address:address, city:city) WHERE(id =:id);";
		this.command = new NpgsqlCommand(update, this.connection);

		this.command.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Varchar)).Value = provider.Id;
		this.command.Parameters.Add(new NpgsqlParameter("name_society", NpgsqlDbType.Varchar)).Value = provider.Society;
		this.command.Parameters.Add(new NpgsqlParameter("name_shop", NpgsqlDbType.Varchar)).Value = provider.Shop;
		this.command.Parameters.Add(new NpgsqlParameter("address", NpgsqlDbType.Varchar)).Value = provider.Address;
		this.command.Parameters.Add(new NpgsqlParameter("city", NpgsqlDbType.Varchar)).Value = provider.City;
		this.command.ExecuteNonQuery();

		this.connection.Close();

		return SelectProvider(provider.Society);
	}

	public List<Provider> SelectAllProvider()
	{
		this.connection.Open();
		string select = "SELECT * FROM \"provider\"";
		this.command = new NpgsqlCommand(select, this.connection);
		NpgsqlDataReader reader = this.command.ExecuteReader();
		List<Provider> providers = new List<Provider>();
		while (reader.Read())
		{
			Provider provider = new Provider((string)reader["name_society"], (string)reader["name_shop"], (string)reader["address"], (string)reader["city"]);
			provider.Id = (int)reader["id"];
			providers.Add(provider);
		}

		reader.Close();
		this.connection.Close();

		return providers;
	}


}
