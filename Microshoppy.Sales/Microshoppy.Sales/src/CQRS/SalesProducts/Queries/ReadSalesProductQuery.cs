using System;
using MediatR;

namespace Microshoppy.Sales.CQRS.SalesProducts.Queries
{
	public class ReadSalesProductQuery : IRequest<SalesProduct>
	{
		public Guid ProductId { get; set; }
	}
}
