using System;
using Npgsql;

namespace KitBox
{
	public class Company
	{
		private ProductManager productManager;
		private CustomerManager customerManager;
		private NpgsqlConnection connection;

		private NpgsqlConnection Init(string host, string db, string user)
		{
			string connectionString;
			connectionString = "Host=" + host + ";" + "Database=" +
			db + ";" + "Username=" + user + ";";

			return new NpgsqlConnection(connectionString);
		}

		public Company(string host, string db, string user)
		{
			try
			{
				this.connection = Init(host, db, user);
			}
			catch (Exception e)
			{
				throw e;
			}
			this.productManager = new ProductManager(this.connection);
			this.customerManager = new CustomerManager(this.connection);
		}

		public ProductManager ProductManager
		{
			get { return this.productManager; }
		}

		public CustomerManager CustomerManager
		{
			get { return this.customerManager; }
		}
	}
}
