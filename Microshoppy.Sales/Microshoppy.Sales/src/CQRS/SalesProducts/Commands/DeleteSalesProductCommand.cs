using System;
using MediatR;

namespace Microshoppy.Sales.CQRS.SalesProducts.Commands
{
	public class DeleteSalesProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }
	}
}
