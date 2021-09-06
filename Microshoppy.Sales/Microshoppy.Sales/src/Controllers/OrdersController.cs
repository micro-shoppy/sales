using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Microshoppy.Sales.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : Controller
	{
		private readonly ILogger<OrdersController> _logger;
		private readonly IMediator _mediator;

		public OrdersController(ILogger<OrdersController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

	}
}
