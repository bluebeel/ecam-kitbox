using System;

namespace kitbox
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Company kitbox = new Company("localhost", "kitbox", "bluebeel");
			Customer test = new Customer("bluebeel", "alma", "1976", "example@example.com", "12345");
			kitbox.CustomerManager.InsertClient(test);
			Console.WriteLine(kitbox.CustomerManager.SelectClient("example@example.com"));
			/*
			Console.WriteLine(kitbox.ProductManager.SelectAllProduct());
			foreach (Product product in kitbox.ProductManager.SelectAllProduct())
			{
				string productLine = string.Format("{0} - {1} - {2} - {3}",
												   product.Reference,
												   product.Code,
												   product.Stock,
												   product.StockMin);
				Console.WriteLine(productLine);
			}
			*/
		}
	}
}