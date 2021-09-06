using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using MicroShoppy.Contract.Events;
using Microshoppy.Sales.Entities;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.Orders.Command
{
	public class CreateOrderCommandHandler : OrdersHandler<CreateOrderCommand, Unit>
	{
		private readonly IPublishEndpoint _publishEndpoint;
		public CreateOrderCommandHandler(IRepository<Order> repo, IPublishEndpoint publishEndpoint) : base(repo)
		{
			_publishEndpoint = publishEndpoint;
		}

		public override Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			var newOrder = new Order
			{
				OrderId = Guid.NewGuid(),
				OrderedProducts = request.OrderedProducts,
				UserId = request.UserId,
				Status = Status.Placed
			};
			Repo.CreateItem(newOrder);
			_publishEndpoint.Publish<IOrderPlaced>(new 
			{
				newOrder.OrderId,
				newOrder.UserId,
				newOrder.OrderedProducts
			}, cancellationToken);
			return Task.FromResult(Unit.Value);
		}
	}
}
