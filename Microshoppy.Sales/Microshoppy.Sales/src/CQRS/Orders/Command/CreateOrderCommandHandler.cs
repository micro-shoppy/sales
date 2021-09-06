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
	public class CreateOrderCommandHandler : OrdersHandler<CreateOrderCommand, Unit>
	{
		public CreateOrderCommandHandler(IRepository<Order> repo) : base(repo)
		{
		}

		public override Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			Repo.CreateItem(new Order
			{
				OrderId = Guid.NewGuid(),
				OrderedProducts = request.OrderedProducts,
				UserId = request.UserId
			});
			return Task.FromResult(Unit.Value);
		}
	}
}
