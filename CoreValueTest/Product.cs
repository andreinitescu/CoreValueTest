namespace CoreValueTest
{

	//decided to leave this as simple poco type because no time left, but it seems to me that this is sort of an entity
	public class Product
	{
		private const decimal DefaultProductPrice = 0m;
		private const string DefaultProductDesctiption = "Empty Product";

		public string ProductName;
		public decimal Price;
		public decimal? Weight;
		public int? Quantity;
		public PricingMethod PricingMethod;

		public decimal CalculatePrice()
		{
			switch (PricingMethod)
			{
				case PricingMethod.PerPound:
					//TODO: nullabble?
					return (Weight.Value * Price);
				case PricingMethod.PerItem:
					//TODO: nullabble?
					return (Quantity.Value * Price);
				default:
					return DefaultProductPrice;
			}
		}

		public string Summary()
		{
			switch (PricingMethod)
			{
				case PricingMethod.PerPound:
					return $" ${CalculatePrice()} ({Weight} pounds at {Price} per pound)";
				case PricingMethod.PerItem:
					return $" ${CalculatePrice()} ({Quantity} + items at {Price} each)";
				default:
					return DefaultProductDesctiption;
			}
		}
	}
}