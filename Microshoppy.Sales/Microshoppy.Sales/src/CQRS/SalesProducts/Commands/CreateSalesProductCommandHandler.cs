using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.SalesProducts.Commands
{
	public class CreateSalesProductCommandHandler : SalesHandler<CreateSalesProductCommand, Unit>
	{
		public CreateSalesProductCommandHandler(IRepository<SalesProduct> repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(CreateSalesProductCommand request, CancellationToken cancellationToken)
		{
			Repo.CreateItem(new SalesProduct()
			{
				ProductId = Guid.NewGuid(),
				NetPrice = request.NetPrice,
				Cost = request.Cost,
				TaxPercentage = request.TaxPercentage
			});
			return Task.FromResult(Unit.Value);
		}
	}
}
