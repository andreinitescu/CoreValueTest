using System.Collections.Generic;
using System.Text;

namespace CoreValueTest
{
	// sort of aggregate with transactional boundaries
	public class Order
	{
		// ubiqitous language
		public static Order CreateForCustomer(string customerName) => new Order(customerName);

		public string CustomerName { get; }

		private readonly List<Product> _products;

		public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

		public decimal TotalPrice { get; private set; }
		
		private Order(string customerName)
		{
			CustomerName = customerName;
			_products = new List<Product>();
			TotalPrice = 0m;
		}

		public void AddProduct(Product product)
		{
			//TODO: validation

			TotalPrice += product.CalculatePrice();
			_products.Add(product);
		}

		public string OrderSummary()
		{
			var summaryStringBuilder = new StringBuilder($"ORDER SUMMARY FOR {CustomerName}: \r\n");
			_products.ForEach(product => summaryStringBuilder.AppendLine($"{product.ProductName}: {product.Summary()}"));
			return summaryStringBuilder.ToString();
		}
	}
}