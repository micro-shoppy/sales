using MediatR;
using Microshoppy.Sales.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Sales.Entities;

namespace Microshoppy.Sales.CQRS.Orders
{
	public abstract class OrdersHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		protected readonly IRepository<Order> Repo;

		protected OrdersHandler(IRepository<Order> repo)
		{
			Repo = repo;
		}

		public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
	}
}
