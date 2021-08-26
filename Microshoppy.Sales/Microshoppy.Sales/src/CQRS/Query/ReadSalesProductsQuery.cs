using System.Collections.Generic;
using MediatR;

namespace Microshoppy.Sales.CQRS.Query
{
	public class ReadSalesProductsQuery : IRequest<IEnumerable<SalesProduct>>
	{
	}
}
