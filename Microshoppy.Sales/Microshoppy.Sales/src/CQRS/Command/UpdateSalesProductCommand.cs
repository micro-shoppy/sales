using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Microshoppy.Sales.src.CQRS.Command
{
	public class UpdateSalesProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }

		public decimal Cost { get; set; }

		public decimal NetPrice { get; set; }

		public int TaxPercentage { get; set; }
	}
}
