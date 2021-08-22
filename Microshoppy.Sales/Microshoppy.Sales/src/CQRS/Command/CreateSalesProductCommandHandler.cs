using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Sales.src.Repositories;

namespace Microshoppy.Sales.src.CQRS.Command
{
	public class CreateSalesProductCommandHandler : Handler<CreateSalesProductCommand, Unit>
	{
		public CreateSalesProductCommandHandler(ISalesRepository repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(CreateSalesProductCommand request, CancellationToken cancellationToken)
		{
			_repo.CreateProduct(new SalesProduct()
			{
				ProductId = request.ProductId,
				NetPrice = request.NetPrice,
				Cost = request.Cost,
				TaxPercentage = request.TaxPercentage
			});
			return Task.FromResult(Unit.Value);
		}
	}
}
