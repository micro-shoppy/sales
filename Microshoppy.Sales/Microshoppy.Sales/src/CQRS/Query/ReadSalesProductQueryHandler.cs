using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.Query
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
