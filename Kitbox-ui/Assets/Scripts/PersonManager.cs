using System;
using UnityEngine;
//using Npgsql;
//using NpgsqlTypes;
using UnityNpgsql;
using UnityNpgsqlTypes;
using System.Collections.Generic;

public class PersonManager {

	private NpgsqlConnection connection;
	private NpgsqlCommand command;

		public PersonManager(NpgsqlConnection conn)
		{
			this.connection = conn;
		}

		public Person SelectPerson(string role, string email, string password)
		{
			Person person = null;
			string select;
			if (role == "customer") {
			select = "SELECT * FROM \"customer\" WHERE email='" + email + "' AND password='" + Person.hash(password) + "';";
			} else {
			select = "SELECT * FROM \"worker\" WHERE email='" + email + "' AND password='" + Person.hash(password) + "';";
			}
			
			this.connection.Open();
			this.command = new NpgsqlCommand(select, this.connection);
			NpgsqlDataReader reader = this.command.ExecuteReader();
			while (reader.Read())
			{
				person = new Person(role, (string)reader["name"], (string)reader["address"], (string)reader["phone"], (string)reader["email"], (string)reader["password"]);
				person.Id = (int)reader["id"];
			}
			reader.Close();
			this.connection.Close();

			return person;

		}

		public Person InsertPerson(Person person)
		{
			this.connection.Open();
			string insert = "INSERT INTO \"" + person.Role + "\"(name,address,phone,email, password) values(:name,:address,:phone,:email, :password)";
			this.command = new NpgsqlCommand(insert, this.connection);

			this.command.Parameters.Add(new NpgsqlParameter("name", NpgsqlDbType.Varchar)).Value = person.Name;
			this.command.Parameters.Add(new NpgsqlParameter("address", NpgsqlDbType.Varchar)).Value = person.Address;
			this.command.Parameters.Add(new NpgsqlParameter("phone", NpgsqlDbType.Varchar)).Value = person.Phone;
			this.command.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Varchar)).Value = person.Email;
			this.command.Parameters.Add(new NpgsqlParameter("password", NpgsqlDbType.Varchar)).Value = person.Password;

			this.command.ExecuteNonQuery();

			this.connection.Close();

			person.Id = SelectPerson(person.Role ,person.Email, person.Password).Id;

			return person;
		}

		public Person UpdatePerson(Person person)
		{
			this.connection.Open();
			string update = "UPDATE \"" + person.Role + "\" SET name:name, address:address, phone:phone, email:email, password:password) WHERE(id =:id);";
			this.command = new NpgsqlCommand(update, this.connection);

			this.command.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Varchar)).Value = person.Id;
			this.command.Parameters.Add(new NpgsqlParameter("name", NpgsqlDbType.Varchar)).Value = person.Name;
			this.command.Parameters.Add(new NpgsqlParameter("address", NpgsqlDbType.Varchar)).Value = person.Address;
			this.command.Parameters.Add(new NpgsqlParameter("phone", NpgsqlDbType.Varchar)).Value = person.Phone;
			this.command.Parameters.Add(new NpgsqlParameter("email", NpgsqlDbType.Varchar)).Value = person.Email;
			this.command.Parameters.Add(new NpgsqlParameter("password", NpgsqlDbType.Varchar)).Value = person.Password;

			this.command.ExecuteNonQuery();

			this.connection.Close();

			return SelectPerson(person.Role, person.Email, person.Password);
		}

		public List<Person> SelectAllPerson(string role)
		{
			this.connection.Open();
			string select = SelectRole(role);
			this.command = new NpgsqlCommand(select, this.connection);
			NpgsqlDataReader reader = this.command.ExecuteReader();
			List<Person> people = new List<Person>();
			while (reader.Read())
			{
				Person person = new Person(role, (string)reader["name"], (string)reader["address"], (string)reader["phone"], (string)reader["email"], (string)reader["password"]);
				person.Id = (int)reader["id"];
				people.Add(person);
			}

			reader.Close();
			this.connection.Close();

			return people;
		}

		private string SelectRole(string role)
		{
			string select;

			switch (role)
			{
				case "worker":
					select = "SELECT * FROM \"worker\" WHERE(email=:email)";
					break;
				case "customer":
					select = "SELECT * FROM \"customer\" WHERE(email=:email)";
					break;
				default:
					throw new Exception("Invalid Role");
			}

			return select;
		}
	}
