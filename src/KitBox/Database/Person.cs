using System;
using System.Text;

public class Person
{
	private string role;
	protected int id;
	private string name;
	private string address;
	private string phone;
	private string email;
	// need to implement the hashed password
	protected string password;

	public Person(string role, string name, string adress, string phone, string email, string password)
	{
		this.Name = name;
		this.Address = adress;
		this.Phone = phone;
		this.Email = email;
		this.Password = password;
		this.Role = role;
	}

	public string Role
	{
		get { return this.role; }

		set { this.role = value; }
	}

	public int Id
	{
		get { return this.id; }

		set { this.id = value; }
	}

	public string Password
	{
		get { return this.password; }

		set { this.password = hash(value); }
	}

	public string Name
	{
		get { return this.name; }

		set { this.name = value; }
	}

	public string Address
	{
		get { return this.address; }

		set { this.address = value; }
	}

	public string Phone
	{
		get { return this.phone; }

		set { this.phone = value; }
	}

	public string Email
	{
		get { return this.email; }

		//email regex verification using System standart library
		set
		{
			try
			{
				var mail = new System.Net.Mail.MailAddress(value);
				this.email = value;
			}
			catch
			{
				throw new FormatException("The email is invalid");
			}
		}
	}



	public static string hash(string pswd)
	{
		var bytes = new UTF8Encoding().GetBytes(pswd);
		byte[] hashBytes;
		using (var algorithm = new System.Security.Cryptography.SHA512Managed())
		{
			hashBytes = algorithm.ComputeHash(bytes);
		}
		return Convert.ToBase64String(hashBytes);
	}
}

