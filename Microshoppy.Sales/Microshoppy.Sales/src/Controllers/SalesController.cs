using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microshoppy.Sales.CQRS.SalesProducts.Commands;
using Microshoppy.Sales.CQRS.SalesProducts.Queries;

namespace Microshoppy.Sales.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SalesController : ControllerBase
	{
		private readonly ILogger<SalesController> _logger;
		private readonly IMediator _mediator;

		public SalesController(ILogger<SalesController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IEnumerable<SalesProduct>> ReadAllProducts()
		{
			_logger.Info("Reading all products");
			return await _mediator.Send(new ReadSalesProductsQuery());
		}

		[HttpGet]
		[Route("{productId}")]
		public async Task<SalesProduct> ReadProduct(Guid productId)
		{
			_logger.Info($"Reading product with ID {productId}");
			return await _mediator.Send(new ReadSalesProductQuery()
			{
				ProductId = productId
			});
		}

		[HttpPost]
		public void CreateProduct(CreateSalesProductCommand command)
		{
			_logger.Info($"Creating new product...");
			_mediator.Send(command);
		}

		[HttpPost]
		[Route("{productId}")]
		public void UpdateProduct(Guid productId, UpdateSalesProductCommand command)
		{
			_logger.Info($"Updating product with ID {productId} to {command}");
			command.ProductId = productId;
			_mediator.Send(command);
		}

		[HttpDelete]
		[Route("{productId}")]
		public void DeleteProduct(Guid productId)
		{
			_logger.Info($"Deleting product with ID {productId}");
			_mediator.Send(new DeleteSalesProductCommand()
			{
				ProductId = productId
			});
		}
	}

}
