using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CoreValueTestPizzas
{
	class Program
	{
		static void Main(string[] args)
		{
			string rawJsonOrders = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/pizzas.json");
			IEnumerable<Order> deserializedOrders = JsonConvert.DeserializeObject<IEnumerable<Order>>(rawJsonOrders);
			var mostOrderedPizzaConfigs = 
				//TODO: yes this key is sort of a hack cuz of time pressure
				deserializedOrders.GroupBy(order => string.Join(",", order.Toppings))
				.OrderByDescending(group => group.Count())
				.Take(20);

			foreach (var pizzaConfig in mostOrderedPizzaConfigs)
			{
				Console.WriteLine($"Topping configuration \"{pizzaConfig.Key}\" was ordered {pizzaConfig.Count()} times.");
			}

			Console.ReadLine();
		}
	}
}
