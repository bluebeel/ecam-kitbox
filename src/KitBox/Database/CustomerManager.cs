using System;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;

namespace kitbox
{
	public class CustomerManager
	{
		private NpgsqlConnection connection;
		private NpgsqlCommand command;

		public CustomerManager(NpgsqlConnection conn)
		{
			this.connection = conn;
		}

		public Customer SelectClient(string email)
		{
			Customer customer = null;
			this.connection.Open();
			string select = "SELECT * FROM \"customer\" WHERE(email=:email)";
			this.command = new NpgsqlCommand(select, this.connection);

			this.command.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Varchar)).Value = email;

			NpgsqlDataReader reader = this.command.ExecuteReader();
			while (reader.Read())
			{
				customer = new Customer((string)reader["name"], (string)reader["address"], (string)reader["phone"], (string)reader["email"], (string)reader["password"]);
				customer.Id = (int)reader["id"];
			}
			reader.Close();
			this.connection.Close();
			return customer;
		}

		public Customer InsertClient(Customer customer)
		{
			this.connection.Open();
			string insert = "INSERT INTO \"customer\"(name,address,phone,email, password) values(:name,:address,:phone,:email, :password)";
			this.command = new NpgsqlCommand(insert, this.connection);

			this.command.Parameters.Add(new NpgsqlParameter("name", NpgsqlDbType.Varchar)).Value = customer.Name;
			this.command.Parameters.Add(new NpgsqlParameter("address", NpgsqlDbType.Varchar)).Value = customer.Address;
			this.command.Parameters.Add(new NpgsqlParameter("phone", NpgsqlDbType.Varchar)).Value = customer.Phone;
			this.command.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Varchar)).Value = customer.Email;
			this.command.Parameters.Add(new NpgsqlParameter("password", NpgsqlDbType.Varchar)).Value = customer.Password;

			this.command.ExecuteNonQuery();

			this.connection.Close();

			// Get the id of the customer
			customer.Id = SelectClient(customer.Email).Id;

			return customer;
		}

		public Customer UpdateClient(Customer customer)
		{
			this.connection.Open();
			string update = "UPDATE \"customer\" SET name:name, address:address, phone:phone, email:email, password:password) WHERE(id =:id);";
			this.command = new NpgsqlCommand(update, this.connection);

			this.command.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Varchar)).Value = customer.Id;
			this.command.Parameters.Add(new NpgsqlParameter("name", NpgsqlDbType.Varchar)).Value = customer.Name;
			this.command.Parameters.Add(new NpgsqlParameter("address", NpgsqlDbType.Varchar)).Value = customer.Address;
			this.command.Parameters.Add(new NpgsqlParameter("phone", NpgsqlDbType.Varchar)).Value = customer.Phone;
			this.command.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Varchar)).Value = customer.Email;
			this.command.Parameters.Add(new NpgsqlParameter("password", NpgsqlDbType.Varchar)).Value = customer.Password;

			this.command.ExecuteNonQuery();

			this.connection.Close();

			return SelectClient(customer.Email);
		}

		public List<Customer> SelectAllCustomer()
		{
			this.connection.Open();
			string select = "SELECT * FROM \"customer\"";
			this.command = new NpgsqlCommand(select, this.connection);
			NpgsqlDataReader reader = this.command.ExecuteReader();
			List<Customer> customers = new List<Customer>();
			while (reader.Read())
			{
				Customer customer = new Customer((string)reader["name"], (string)reader["address"], (string)reader["phone"], (string)reader["email"], (string)reader["password"]);
				customer.Id = (int)reader["id"];
				customers.Add(customer);
			}

			reader.Close();
			this.connection.Close();

			return customers;
		}
	}
}
