using System;

namespace kitbox
{
	public class Customer
	{
		protected int id;
		private string name;
		private string address;
		private string phone;
		private string email;
		// need to implement the hashed password
		protected string password;

		public Customer(string name, string adress, string phone, string email, string password)
		{
			this.Name = name;
			this.Address = adress;
			this.Phone = phone;
			this.Email = email;
			this.password = password;
		}

		public int Id
		{
			get { return this.id; }

			set { this.id = value; }
		}

		public string Password
		{
			get { return this.password; }

			set { this.password = value; }
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
	}
}
