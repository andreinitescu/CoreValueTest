using System;
 
namespace CoreValueTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var testOrder = Order.CreateForCustomer("John Doe");
			testOrder.AddProduct(new Product
			{
				ProductName = "Pulled Pork",
				Price = 6.99m,
				Weight = 0.5m,
				PricingMethod = PricingMethod.PerPound
			});
			testOrder.AddProduct(new Product
			{
				ProductName = "Coke",
				Price = 3m,
				Quantity = 2,
				PricingMethod = PricingMethod.PerItem
			});

			Console.WriteLine(testOrder.OrderSummary());
			Console.WriteLine("Total Price: $" + testOrder.TotalPrice);
			Console.ReadKey();
		}
	}
}
