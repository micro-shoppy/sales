using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Sales.src.Repositories;

namespace Microshoppy.Sales.src.CQRS.Command
{
	public class DeleteSalesProductCommandHandler : Handler<DeleteSalesProductCommand, Unit>
	{
		public DeleteSalesProductCommandHandler(ISalesRepository repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(DeleteSalesProductCommand request, CancellationToken cancellationToken)
		{
			_repo.DeleteProduct(request.ProductId);
			return Task.FromResult(Unit.Value);
		}
	}
}
