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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

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
		[Route("all")]
		[Authorize(Roles="Admin")]
		public async Task<IEnumerable<Order>> ReadAllOrders()
		{
			_logger.Info("Reading all products");
			return await _mediator.Send(new ReadOrdersQuery());
		}

		[HttpGet]
		[Authorize]
		public async Task<IEnumerable<Order>> ReadUserOrders()
		{
			var userid = Guid.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sub));
			_logger.Info("Reading all user products");
			return await _mediator.Send(new ReadOrdersPerUserQuery{UserId = userid });
		}

		[HttpGet]
		[Authorize]
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
		[Authorize]
		public void CreateOrder(CreateOrderCommand command)
		{
			_logger.Info("Creating new product...");
			_mediator.Send(command);
		}

	}
}
