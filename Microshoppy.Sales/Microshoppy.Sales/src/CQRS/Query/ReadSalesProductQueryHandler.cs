using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Sales.src.Repositories;

namespace Microshoppy.Sales.src.CQRS.Query
{
	public class ReadSalesProductQueryHandler : Handler<ReadSalesProductQuery, SalesProduct>
	{
		public ReadSalesProductQueryHandler(ISalesRepository repo) : base(repo)
		{
		}

		public override Task<SalesProduct> Handle(ReadSalesProductQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_repo.ReadProduct(request.ProductId));
		}
	}
}
