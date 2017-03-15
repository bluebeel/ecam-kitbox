using System;
namespace KitBox
{
	public class Panel : StockProduct
	{
		public enum PanelType
		{
			AR,
			HB,
			GD
		}

		private PanelType panelsType;

		public Panel(ProductType type, string code, Dimensions dim, string color, int stock, int stockMin, double price, int piecepb, PanelType pos) :
		base(type, code, dim, color, stock, stockMin, price, piecepb)
		{
			this.panelsType = pos;
		}

		public PanelType PanelsType
		{
			get { return panelsType; }
		}
	}
}
