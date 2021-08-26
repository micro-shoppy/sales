using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.Query
{
	public class ReadSalesProductsQueryHandler : Handler<ReadSalesProductsQuery, IEnumerable<SalesProduct>>
	{
		public ReadSalesProductsQueryHandler(ISalesRepository repo) : base(repo)
		{
		}

		public override Task<IEnumerable<SalesProduct>> Handle(ReadSalesProductsQuery request, CancellationToken cancellationToken)
		{
			return Repo.ReadProducts();
		}
	}
}
