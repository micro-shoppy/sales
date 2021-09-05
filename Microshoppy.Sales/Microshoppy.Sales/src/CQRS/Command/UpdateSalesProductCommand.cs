using System;
using System.Collections.Generic;
using MediatR;

namespace Microshoppy.Sales.CQRS.Command
{
	public class UpdateSalesProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }

		public double Cost { get; set; }

		public double NetPrice { get; set; }

		public double TaxPercentage { get; set; }
	}
}
