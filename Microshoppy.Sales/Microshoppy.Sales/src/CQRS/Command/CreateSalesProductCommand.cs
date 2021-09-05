using System;
using MediatR;

namespace Microshoppy.Sales.CQRS.Command
{
	public class CreateSalesProductCommand : IRequest<Unit>
	{
		public double Cost { get; set; }

		public double NetPrice { get; set; }

		public double TaxPercentage { get; set; }
	}
}
