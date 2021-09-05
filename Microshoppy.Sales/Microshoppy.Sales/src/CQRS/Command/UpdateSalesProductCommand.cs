using System;
using System.Collections.Generic;
using MediatR;

namespace Microshoppy.Sales.CQRS.Command
{
	public class UpdateSalesProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }

		public decimal Cost { get; set; }

		public decimal NetPrice { get; set; }

		public decimal TaxPercentage { get; set; }
	}
}
