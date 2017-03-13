using System;
using System.Linq;
namespace KitBox
{
	public class main
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Company kitbox = new Company("localhost", "kitbox", "bluebeel");
			//Person test = new Person("customer", "bluebeel", "alma", "1976", "example@example.com", "12345");
			//kitbox.PersonManager.InsertPerson(test);
			//Console.WriteLine(kitbox.PersonManager.SelectPerson("customer", "example@example.com"));
			Console.WriteLine(kitbox.ProductManager.SelectAllProduct());
			foreach (StockProduct product in kitbox.ProductManager.SelectAllProduct())
			{
				string productLine = string.Format("{0} - {1} - {2} - {3}",
												   product.Reference,
												   product.Code,
												   product.Stock,
												   product.StockMin);
				Console.WriteLine(productLine);
			}
			/*
			Console.WriteLine(kitbox.ProductManager.SelectAllProduct());
			foreach (StockProduct product in kitbox.ProductManager.SelectAllProduct())
			{
				string productLine = string.Format("{0} - {1} - {2} - {3}",
												   product.Reference,
												   product.Code,
												   product.Stock,
												   product.StockMin);
				Console.WriteLine(productLine);
			}
			// Comment on pourrait filtrer les produits en fonctions du choix de l'utilisateur
			var selected = from product in kitbox.ProductManager.SelectAllProduct()
						   where product.Dimensions.Width == 32 && product.Dimensions.Depth == 32 || 
			                                     product.Dimensions.Width == 32 && product.Dimensions.Depth == 0 || 
			                                     product.Dimensions.Width == 0 && product.Dimensions.Depth == 32
						   select product;
			//Console.WriteLine(selected.ToList());
			foreach (StockProduct product in selected.ToList())
			{
				string productLine = string.Format("{0} - {1} - {2} - {3}",
												   product.Reference,
												   product.Code,
												   product.Stock,
												   product.StockMin);
				Console.WriteLine(productLine);
			}
			Console.WriteLine(kitbox.ProductManager.SelectProduct("COR36BL"));
			*/
			/*
			foreach (Provider provider in kitbox.ProviderManager.SelectAllProvider())
			{
				string productLine = string.Format("{0} - {1} - {2} - {3}",
				                                   provider.Shop,
				                                   provider.Society,
				                                   provider.Address,
				                                   provider.Id);
				Console.WriteLine(productLine);
			}*/
			/*
			foreach (Invoice provider in kitbox.InvoiceManager.SelectAllInvoice())
			{
				foreach (InvoiceItem providers in kitbox.InvoiceManager.SelectInvoiceItem(provider))
				{
					string productLine = string.Format("{0} - {1} - {2} - {3}",
													   providers.Id,
													   providers.OrderId,
													   providers.ProductId,
													   providers.NbreBloc);
					Console.WriteLine(productLine);
				}
			}
			*/
			/*
			foreach (InvoiceItem provider in kitbox.InvoiceManager.SelectAllInvoiceItem())
			{
				string productLine = string.Format("{0} - {1} - {2} - {3}",
				                                   provider.Id,
				                                   provider.OrderId,
				                                   provider.ProductId,
				                                   provider.NbreBloc);
				Console.WriteLine(productLine);
			}
			*/
		}
	}
}
