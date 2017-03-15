using System;
namespace KitBox
{
	public class Track : StockProduct
	{
		public enum TrackType
		{
			AR,
			AV,
			GD
		}

		private TrackType tracksType;

		public Track(ProductType type, string code, Dimensions dim, string color, int stock, int stockMin, double price, int piecepb, TrackType pos) :
		base(type, code, dim, color, stock, stockMin, price, piecepb)
		{
			this.tracksType = pos;
		}

		public TrackType TracksType
		{
			get { return tracksType; }
		}
	}
}
