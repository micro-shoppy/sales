using System;
using MediatR;

namespace Microshoppy.Sales.CQRS.Command
{
	public class DeleteSalesProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }
	}
}
