using System;

namespace Microshoppy.Sales
{
	public class SalesProduct 
	{ 
		public Guid ProductId { get; set; }

		public decimal Cost { get; set; }

		public decimal NetPrice { get; set; }

		public decimal TaxPercentage { get; set; }
	}
}
