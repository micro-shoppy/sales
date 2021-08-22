using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Microshoppy.Sales.src.CQRS.Query
{
	public class ReadSalesProductsQuery : IRequest<IEnumerable<SalesProduct>>
	{
	}
}
