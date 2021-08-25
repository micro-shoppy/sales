using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.Command
{
	public class UpdateSalesProductCommandHandler : Handler<UpdateSalesProductCommand, Unit>
	{
		public UpdateSalesProductCommandHandler(ISalesRepository repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(UpdateSalesProductCommand request, CancellationToken cancellationToken)
		{
			_repo.UpdateProduct(request.ProductId, new SalesProduct()
			{
				ProductId = request.ProductId,
				Cost = request.Cost,
				NetPrice = request.NetPrice,
				TaxPercentage = request.TaxPercentage
			});
			return Task.FromResult(Unit.Value);
		}
	}
}
