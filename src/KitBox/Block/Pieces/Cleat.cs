using System;
namespace KitBox
{
	public class Cleat : StockProduct
	{
		public Cleat(ProductType type, string code, Dimensions dim, string color, int stock, int stockMin, double price, int piecepb) :
		base(type, code, dim, color, stock, stockMin, price, piecepb)
		{
		}
	}
}
