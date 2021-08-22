using MediatR;
using Microshoppy.Sales.src.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Microshoppy.Sales.src.CQRS
{
	public abstract class Handler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		protected readonly ISalesRepository _repo;

		protected Handler(ISalesRepository repo)
		{
			_repo = repo;
		}

		public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
	}
}
