using MediatR;
using Microshoppy.Sales.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Microshoppy.Sales.CQRS
{
	public abstract class Handler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		protected readonly ISalesRepository Repo;

		protected Handler(ISalesRepository repo)
		{
			Repo = repo;
		}

		public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
	}
}
