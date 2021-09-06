using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.SalesProducts.Queries
{
	public class ReadSalesProductsQueryHandler : SalesHandler<ReadSalesProductsQuery, IEnumerable<SalesProduct>>
	{
		public ReadSalesProductsQueryHandler(IRepository<SalesProduct> repo) : base(repo)
		{
		}

		public override Task<IEnumerable<SalesProduct>> Handle(ReadSalesProductsQuery request, CancellationToken cancellationToken)
		{
			return Repo.ReadItems();
		}
	}
}
