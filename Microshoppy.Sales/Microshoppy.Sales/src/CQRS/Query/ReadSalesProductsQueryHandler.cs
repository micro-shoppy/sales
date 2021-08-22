using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Sales.src.Repositories;

namespace Microshoppy.Sales.src.CQRS.Query
{
	public class ReadSalesProductsQueryHandler : Handler<ReadSalesProductsQuery, IEnumerable<SalesProduct>>
	{
		public ReadSalesProductsQueryHandler(ISalesRepository repo) : base(repo)
		{
		}

		public override Task<IEnumerable<SalesProduct>> Handle(ReadSalesProductsQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_repo.ReadProducts());
		}
	}
}
