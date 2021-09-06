using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.SalesProducts.Commands
{
	public class DeleteSalesProductCommandHandler : SalesHandler<DeleteSalesProductCommand, Unit>
	{
		public DeleteSalesProductCommandHandler(IRepository<SalesProduct> repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(DeleteSalesProductCommand request, CancellationToken cancellationToken)
		{
			Repo.DeleteItem(request.ProductId);
			return Task.FromResult(Unit.Value);
		}
	}
}
