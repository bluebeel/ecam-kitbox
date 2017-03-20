using System;
using System.Collections;
//using Npgsql;
//using NpgsqlTypes;
using UnityNpgsql;
using UnityNpgsqlTypes;


public class Company
{

	private ProductManager productManager;
	private PersonManager personManager;
	private ProviderManager providerManager;
	private InvoiceManager invoiceManager;
	private NpgsqlConnection connection;

	private NpgsqlConnection Init(string host, string db, string user)
	{
		string connectionString;
		connectionString = "Host=" + host + ";" + "Database=" +
			db + ";" + "Username=" + user + ";";

		NpgsqlConnection conn = new NpgsqlConnection(connectionString);

		return conn;
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
		this.personManager = new PersonManager(this.connection);
		this.providerManager = new ProviderManager(this.connection);
		this.invoiceManager = new InvoiceManager(this.connection);
	}

	public ProductManager ProductManager
	{
		get { return this.productManager; }
	}

	public PersonManager PersonManager
	{
		get { return this.personManager; }
	}

	public InvoiceManager InvoiceManager
	{
		get { return this.invoiceManager; }
	}

	public ProviderManager ProviderManager
	{
		get { return this.providerManager; }
	}
}

