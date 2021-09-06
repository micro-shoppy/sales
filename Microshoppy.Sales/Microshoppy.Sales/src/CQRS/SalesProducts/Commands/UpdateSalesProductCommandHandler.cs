using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.SalesProducts.Commands
{
	public class UpdateSalesProductCommandHandler : SalesHandler<UpdateSalesProductCommand, Unit>
	{
		public UpdateSalesProductCommandHandler(IRepository<SalesProduct> repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(UpdateSalesProductCommand request, CancellationToken cancellationToken)
		{
			Repo.UpdateItem(request.ProductId, new SalesProduct()
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
