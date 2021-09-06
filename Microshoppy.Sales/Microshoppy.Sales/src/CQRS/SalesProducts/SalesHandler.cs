using MediatR;
using Microshoppy.Sales.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Microshoppy.Sales.CQRS.SalesProducts
{
	public abstract class SalesHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		protected readonly IRepository<SalesProduct> Repo;

		protected SalesHandler(IRepository<SalesProduct> repo)
		{
			Repo = repo;
		}

		public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
	}
}
