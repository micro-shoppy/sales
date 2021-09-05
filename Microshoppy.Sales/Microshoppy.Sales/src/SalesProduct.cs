using System;

namespace Microshoppy.Sales
{
	public class SalesProduct 
	{ 
		public Guid ProductId { get; set; }

		public double Cost { get; set; }

		public double NetPrice { get; set; }

		public double TaxPercentage { get; set; }
	}
}
