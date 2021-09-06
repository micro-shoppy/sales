using System.Collections.Generic;
using MediatR;

namespace Microshoppy.Sales.CQRS.SalesProducts.Queries
{
	public class ReadSalesProductsQuery : IRequest<IEnumerable<SalesProduct>>
	{
	}
}
