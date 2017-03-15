using System;
using Npgsql;

namespace KitBox
{
	public class ProductFactory
	{
		public ProductFactory()
		{
		}

		public StockProduct getProduct(NpgsqlDataReader reader) {
			Console.WriteLine((string)reader["reference"]);
			switch ((string)reader["reference"])
			{
				case "Panneau GD":
				case "Panneau HB":
				case "Panneau Ar":
					Dimensions specsPanel = new Dimensions((int)reader["width"], (int)reader["height"], (int)reader["depth"]);
					switch ((string)reader["reference"])
					{
						case "Panneau GD":
							return new Panel(ProductType.Panel, (string)reader["code"], specsPanel, (string)reader["color"], (int)reader["stock"], 
						                     (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"], Panel.PanelType.GD);
						case "Panneau HB":
							return new Panel(ProductType.Panel, (string)reader["code"], specsPanel, (string)reader["color"], (int)reader["stock"], 
						                     (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"], Panel.PanelType.HB);
						case "Panneau Ar":
							return new Panel(ProductType.Panel, (string)reader["code"], specsPanel, (string)reader["color"], (int)reader["stock"],
						                     (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"], Panel.PanelType.AR);
					}				 
					break;
				case "Traverse GD":
				case "Traverse Ar":
				case "Traverse Av":
					Dimensions specsTrack = new Dimensions((int)reader["width"], (int)reader["height"], (int)reader["depth"]);
					switch ((string)reader["reference"])
					{
						case "Traverse GD":
							return new Track(ProductType.Track, (string)reader["code"], specsTrack, (string)reader["color"], (int)reader["stock"],
						                     (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"], Track.TrackType.GD);
						case "Traverse Ar":
							return new Track(ProductType.Track, (string)reader["code"], specsTrack, (string)reader["color"], (int)reader["stock"],
											 (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"], Track.TrackType.AR);
						case "Traverse Av":
							return new Track(ProductType.Track, (string)reader["code"], specsTrack, (string)reader["color"], (int)reader["stock"],
											 (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"], Track.TrackType.AV);
					}
					break;
				case "Porte":
					Dimensions specsDoor = new Dimensions((int)reader["width"], (int)reader["height"], (int)reader["depth"]);
					return new Door(ProductType.Door, (string)reader["code"], specsDoor, (string)reader["color"], (int)reader["stock"],
											 (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"]);
				case "Cornières":
					Dimensions specsAngle = new Dimensions((int)reader["width"], (int)reader["height"], (int)reader["depth"]);
					return new Angle(ProductType.Angle, (string)reader["code"], specsAngle, (string)reader["color"], (int)reader["stock"],
											 (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"]);
				case "Tasseau":
					Dimensions specsCleat = new Dimensions((int)reader["width"], (int)reader["height"], (int)reader["depth"]);
					return new Cleat(ProductType.Cleat, (string)reader["code"], specsCleat, (string)reader["color"], (int)reader["stock"],
											 (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"]);
				case "Coupelles":
					Dimensions specsCoupelles = new Dimensions((int)reader["width"], (int)reader["height"], (int)reader["depth"]);
					return new StockProduct(ProductType.Coupelle, (string)reader["code"], specsCoupelles, (string)reader["color"], (int)reader["stock"],
				                            (int)reader["stock_min"], (double)reader["price"], (int)reader["piece_per_bloc"]);
			}
			return null;
		}
	}
}
