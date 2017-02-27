using System;

namespace kitbox
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Company kitbox = new Company("localhost", "kitbox", "bluebeel");
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
		}
	}
}