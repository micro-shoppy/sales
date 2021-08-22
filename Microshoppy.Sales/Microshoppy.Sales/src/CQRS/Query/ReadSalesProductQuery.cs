using System;
using MediatR;

namespace Microshoppy.Sales.src.CQRS.Query
{
	public class ReadSalesProductQuery : IRequest<SalesProduct>
	{
		public Guid ProductId { get; set; }
	}
}
