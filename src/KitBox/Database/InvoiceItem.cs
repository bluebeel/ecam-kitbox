using System;
namespace KitBox
{
	public class InvoiceItem
	{
		protected int id;
		private int orderId;
		private int nbreBloc;
		private string productId;
		private string type;
		private int quantity;
		private double price;

		public InvoiceItem(int orderId, string productId, string type, int quantity, double price)
		{
			this.OrderId = orderId;
			this.ProductId = productId;
			this.Type = type;
			this.Quantity = quantity;
			this.Price = price;
		}

		public int Id
		{
			get { return this.id; }

			set { this.id = value; }
		}

		public int OrderId
		{
			get { return this.orderId; }

			set { this.orderId = value; }
		}

		public int NbreBloc
		{
			get { return this.nbreBloc; }

			set { this.nbreBloc = value; }
		}

		public string ProductId
		{
			get { return this.productId; }

			set { this.productId = value; }
		}

		public string Type
		{
			get { return this.type; }

			set { this.type = value; }
		}

		public int Quantity
		{
			get { return this.quantity; }

			set { this.quantity = value; }
		}

		public double Price
		{
			get { return this.price; }

			set { this.price = value; }
		}
	}
}
