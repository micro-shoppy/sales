using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Sales.Entities;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.Orders.Command
{
	public class DeleteOrderCommandHandler : OrdersHandler<DeleteOrderCommand, Unit>
	{
		public DeleteOrderCommandHandler(IRepository<Order> repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
		{
			Repo.DeleteItem(request.OrderId);
			return Task.FromResult(Unit.Value);
		}
	}
}
