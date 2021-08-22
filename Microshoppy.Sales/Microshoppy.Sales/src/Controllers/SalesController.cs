using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microshoppy.Sales.src.CQRS.Command;
using Microshoppy.Sales.src.CQRS.Query;

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
		public void CreateProduct(SalesProduct product)
		{
			_logger.Info($"Creating new product: {product}");
			_mediator.Send(new CreateSalesProductCommand()
			{
				ProductId = Guid.NewGuid(),
				Cost = product.Cost,
				NetPrice = product.NetPrice,
				TaxPercentage = product.TaxPercentage
			});
		}

		[HttpPost]
		[Route("{productId}")]
		public void UpdateProduct(Guid productId, SalesProduct product)
		{
			_logger.Info($"Updating product with ID {productId} to {product}");
			_mediator.Send(new UpdateSalesProductCommand()
			{
				ProductId = productId,
				Cost = product.Cost,
				NetPrice = product.NetPrice,
				TaxPercentage = product.TaxPercentage
			});
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

	public static class ProdLogger
	{
		public static void Info(this ILogger logger, string info)
		{
			logger.Log(LogLevel.Information, $"[INFO] {info}");
		}
	}

}
