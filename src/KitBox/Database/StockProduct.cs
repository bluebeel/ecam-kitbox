using System;

namespace KitBox
{
	public enum ProductType
	{
		Panel,
		Angle,
		Door,
		Cleat,
		Track,
		Coupelle
	}
	public class StockProduct
	{
		private string code;
		private Dimensions dimensions;
		private string color;
		private int stock;
		private int stockMin;
		private double price;
		private int piecePerBloc;
		private ProductType type;

		/*(ProductType type, string code, Dimensions dim, Color color, int stock, int stockMin, double price, int piecepb) :
		base(type, code, dim, color, stock, stockMin, price, piecepb)*/

		public StockProduct(ProductType type, string code, Dimensions dim, string color, int stock, int stockMin, double price, int piecepb)
		{
			this.type = type;
			this.code = code;
			this.dimensions = dim;
			this.color = color;
			this.stock = stock;
			this.stockMin = stockMin;
			this.price = price;
			this.piecePerBloc = piecepb;
		}

		public ProductType Type
		{
			get { return type; }
		}

		public string Code
		{
			get { return code; }
		}

		public Dimensions Dimensions
		{
			get { return dimensions; }
		}

		public string Color
		{
			get { return color; }
		}

		public int Stock
		{
			get { return stock; }
		}

		public int StockMin
		{
			get { return stockMin; }
		}

		public double Price
		{
			get { return price; }
		}

		public int PiecePerBloc
		{
			get { return piecePerBloc; }
		}
	}
}