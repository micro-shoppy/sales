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
	public class UpdateOrderCommandHandler : OrdersHandler<UpdateOrderCommand, Unit>
	{
		public UpdateOrderCommandHandler(IRepository<Order> repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
		{
			Repo.UpdateItem(request.OrderId, new Order()
			{
				OrderId = request.OrderId,
				OrderedProducts = request.OrderedProducts,
				UserId = request.UserId
			});
			return Task.FromResult(Unit.Value);
		}
	}
}
