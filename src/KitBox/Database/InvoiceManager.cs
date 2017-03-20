using System;
using UnityNpgsql;
using UnityNpgsqlTypes;
using System.Collections.Generic;

public class InvoiceManager
{
	private NpgsqlConnection connection;
	private NpgsqlCommand command;

	public InvoiceManager(NpgsqlConnection conn)
	{
		this.connection = conn;
	}

	public Invoice SelectInvoice(DateTime date)
	{
		Invoice invoice = null;
		this.connection.Open();
		string select = "SELECT * FROM \"purchase\" WHERE(date_order=:date_order)";
		this.command = new NpgsqlCommand(select, this.connection);

		this.command.Parameters.Add(new NpgsqlParameter("date_order", NpgsqlDbType.Date)).Value = date;

		NpgsqlDataReader reader = this.command.ExecuteReader();
		while (reader.Read())
		{
			invoice = new Invoice((int)reader["id_customer"], (string)reader["status"], (double)reader["price"]);
			invoice.Id = (int)reader["id"];
		}
		reader.Close();
		this.connection.Close();
		return invoice;
	}

	public Invoice InsertInvoice(Invoice invoice)
	{
		this.connection.Open();
		string insert = "INSERT INTO \"purchase\"(date_order, id_customer, status, price) values(:date_order, :id_customer, :status, :price)";
		this.command = new NpgsqlCommand(insert, this.connection);

		this.command.Parameters.Add(new NpgsqlParameter("date_order", NpgsqlDbType.Date)).Value = invoice.Date;
		this.command.Parameters.Add(new NpgsqlParameter("id_customer", NpgsqlDbType.Varchar)).Value = invoice.UserId;
		this.command.Parameters.Add(new NpgsqlParameter("status", NpgsqlDbType.Varchar)).Value = invoice.Status;
		this.command.Parameters.Add(new NpgsqlParameter("price", NpgsqlDbType.Double)).Value = invoice.Price;

		this.command.ExecuteNonQuery();

		this.connection.Close();

		invoice.Id = SelectInvoice(invoice.Date).Id;

		return invoice;
	}

	public Invoice UpdateInvoice(Invoice invoice)
	{
		this.connection.Open();
		string update = "UPDATE \"purchase\" SET date_order:date_order, id_customer:id_customer, status:status, price:price) WHERE(id =:id);";
		this.command = new NpgsqlCommand(update, this.connection);

		this.command.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer)).Value = invoice.Id;
		this.command.Parameters.Add(new NpgsqlParameter("date_order", NpgsqlDbType.Date)).Value = invoice.Date;
		this.command.Parameters.Add(new NpgsqlParameter("id_customer", NpgsqlDbType.Varchar)).Value = invoice.UserId;
		this.command.Parameters.Add(new NpgsqlParameter("status", NpgsqlDbType.Varchar)).Value = invoice.Status;
		this.command.Parameters.Add(new NpgsqlParameter("price", NpgsqlDbType.Double)).Value = invoice.Price;

		this.command.ExecuteNonQuery();

		this.connection.Close();

		return SelectInvoice(invoice.Date);
	}

	public List<Invoice> SelectAllInvoice()
	{
		this.connection.Open();
		string select = "SELECT * FROM \"purchase\"";
		this.command = new NpgsqlCommand(select, this.connection);
		NpgsqlDataReader reader = this.command.ExecuteReader();
		List<Invoice> invoices = new List<Invoice>();
		while (reader.Read())
		{
			Invoice invoice = new Invoice((int)reader["id_customer"], (string)reader["status"], (double)reader["price"]);
			invoice.Id = (int)reader["id"];
			invoices.Add(invoice);
		}

		reader.Close();
		this.connection.Close();

		return invoices;
	}

	public List<InvoiceItem> SelectInvoiceItem(Invoice invoice)
	{
		this.connection.Open();
		string select = "SELECT * FROM \"purchase\" RIGHT JOIN \"orderitem\" ON " + invoice.Id + " = orderitem.Id";
		this.command = new NpgsqlCommand(select, this.connection);
		NpgsqlDataReader reader = this.command.ExecuteReader();
		List<InvoiceItem> invoices = new List<InvoiceItem>();

		while (reader.Read())
		{
			InvoiceItem item = new InvoiceItem((int)reader.GetValue(6), (string)reader.GetValue(8), (string)reader.GetValue(9), (int)reader.GetValue(10), (double)reader.GetValue(11));
			item.Id = (int)reader.GetValue(5);
			invoices.Add(item);
		}

		reader.Close();
		this.connection.Close();

		return invoices;
	}

	public List<InvoiceItem> SelectAllInvoiceItem()
	{
		this.connection.Open();
		string select = "SELECT * FROM \"purchase\" FULL JOIN \"orderitem\" ON purchase.Id = orderitem.Id";
		this.command = new NpgsqlCommand(select, this.connection);
		NpgsqlDataReader reader = this.command.ExecuteReader();
		List<InvoiceItem> invoices = new List<InvoiceItem>();

		while (reader.Read())
		{
			InvoiceItem item = new InvoiceItem((int)reader.GetValue(6), (string)reader.GetValue(8), (string)reader.GetValue(9), (int)reader.GetValue(10), (double)reader.GetValue(11));
			item.Id = (int)reader.GetValue(5);
			invoices.Add(item);
		}

		reader.Close();
		this.connection.Close();

		return invoices;
	}
}

