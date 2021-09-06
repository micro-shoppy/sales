using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.SalesProducts.Queries
{
	public class ReadSalesProductQueryHandler : SalesHandler<ReadSalesProductQuery, SalesProduct>
	{
		public ReadSalesProductQueryHandler(IRepository<SalesProduct> repo) : base(repo)
		{
		}

		public override Task<SalesProduct> Handle(ReadSalesProductQuery request, CancellationToken cancellationToken)
		{
			return Repo.ReadItem(request.ProductId);
		}
	}
}
