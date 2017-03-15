using System;
namespace KitBox
{
	public class Angle : StockProduct
	{
		public Angle(ProductType type, string code, Dimensions dim, string color, int stock, int stockMin, double price, int piecepb) :
		base(type, code, dim, color, stock, stockMin, price, piecepb)
		{
		}
	}
}
