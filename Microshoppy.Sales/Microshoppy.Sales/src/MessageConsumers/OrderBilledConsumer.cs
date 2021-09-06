using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microshoppy.Sales.Repositories;
using MicroShoppy.Contract.Events;
using Microshoppy.Sales.Entities;
using Microsoft.Extensions.Logging;

namespace Microshoppy.Sales.MessageConsumers
{
	public class OrderBilledConsumer : IConsumer<IOrderBilled>
	{
		private readonly IRepository<Order> _repo;
		private readonly ILogger<OrderBilledConsumer> _logger;
		private readonly IPublishEndpoint _publishEndpoint;

		public OrderBilledConsumer(
			IRepository<Order> repo, 
			ILogger<OrderBilledConsumer> logger,
			IPublishEndpoint publishEndpoint)
		{
			_repo = repo;
			_logger = logger;
			_publishEndpoint = publishEndpoint;
		}
		public Task Consume(ConsumeContext<IOrderBilled> context)
		{
			var billedOrder =  _repo.ReadItems().Result.First(o => o.OrderId == context.Message.OrderId);
			billedOrder.Status = Status.Completed;
			_repo.UpdateItem(context.Message.OrderId, billedOrder);
			_publishEndpoint.Publish<IOrderCompleted>(new {context.Message.OrderId});
			return Task.FromResult(0);
		}
	}
}
