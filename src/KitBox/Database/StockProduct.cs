using System.Drawing;

namespace KitBox
{
	public class StockProduct
	{
		private string reference;
		private string code;
		private Dimensions dimensions;
		private Color color;
		private int stock;
		private int stockMin;
		private double price;
		private int piecePerBloc;

		public StockProduct(string reference, string code, Dimensions dim, Color color, int stock, int stockMin, double price, int piecepb)
		{
			this.reference = reference;
			this.code = code;
			this.dimensions = dim;
			this.color = color;
			this.stock = stock;
			this.stockMin = stockMin;
			this.price = price;
			this.piecePerBloc = piecepb;
		}

		public string Reference
		{
			get { return reference; }
		}

		public string Code
		{
			get { return code; }
		}

		public Dimensions Dimensions
		{
			get { return dimensions; }
		}

		public Color Color
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