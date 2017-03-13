using System;
namespace KitBox
{
	public class Invoice
	{
		protected int id;
		private DateTime date;
		private int userId;
		private string status;
		private double price;

		//Add DateTime to the constructor
		public Invoice(int user, string status, double price)
		{
			this.UserId = user;
			this.Status = status;
			this.Price = price;
		}

		public int Id
		{
			get { return this.id; }

			set { this.id = value; }
		}

		public DateTime Date
		{
			get { return this.date; }

			set { this.date = value; }
		}

		public int UserId
		{
			get { return this.userId; }

			set { this.userId = value; }
		}

		public string Status
		{
			get { return this.status; }

			set { this.status = value; }
		}

		public double Price
		{
			get { return this.price; }

			set { this.price = value; }
		}
	}
}
