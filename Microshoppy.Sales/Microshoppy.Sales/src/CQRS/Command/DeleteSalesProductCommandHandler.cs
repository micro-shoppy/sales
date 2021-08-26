using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.Command
{
	public class DeleteSalesProductCommandHandler : Handler<DeleteSalesProductCommand, Unit>
	{
		public DeleteSalesProductCommandHandler(ISalesRepository repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(DeleteSalesProductCommand request, CancellationToken cancellationToken)
		{
			Repo.DeleteProduct(request.ProductId);
			return Task.FromResult(Unit.Value);
		}
	}
}
