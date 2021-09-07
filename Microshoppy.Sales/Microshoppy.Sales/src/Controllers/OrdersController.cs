using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Sales.CQRS.Orders.Command;
using Microshoppy.Sales.CQRS.Orders.Queries;
using Microshoppy.Sales.CQRS.SalesProducts.Commands;
using Microshoppy.Sales.CQRS.SalesProducts.Queries;
using Microshoppy.Sales.Entities;

namespace Microshoppy.Sales.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly ILogger<OrdersController> _logger;
		private readonly IMediator _mediator;

		public OrdersController(ILogger<OrdersController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IEnumerable<Order>> ReadAllOrders()
		{
			_logger.Info("Reading all products");
			return await _mediator.Send(new ReadOrdersQuery());
		}

		[HttpGet]
		[Route("{orderId}")]
		public async Task<Order> ReadOrder(Guid orderId)
		{
			_logger.Info($"Reading product with ID {orderId}");
			return await _mediator.Send(new ReadOrderQuery()
			{
				OrderId = orderId
			});
		}

		[HttpPost]
		public void CreateOrder(CreateOrderCommand command)
		{
			_logger.Info("Creating new product...");
			_mediator.Send(command);
		}

	}
}
