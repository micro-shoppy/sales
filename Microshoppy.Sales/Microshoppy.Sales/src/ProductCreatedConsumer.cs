﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MicroShoppy.Contract.Events;
using Microshoppy.Sales.Repositories;
using Microsoft.Extensions.Logging;

namespace Microshoppy.Sales
{
	public class ProductCreatedConsumer : IConsumer<IProductCreated>
	{
		private readonly ISalesRepository _repo;
		private ILogger<ProductCreatedConsumer> _logger;

		public ProductCreatedConsumer(ISalesRepository repo, ILogger<ProductCreatedConsumer> logger)
		{
			_repo = repo;
			_logger = logger;
		}
		public Task Consume(ConsumeContext<IProductCreated> context)
		{
			_repo.CreateProduct(new SalesProduct
			{
				ProductId = context.Message.ProductId,
				Cost = context.Message.Cost,
				NetPrice = context.Message.NetPrice,
				TaxPercentage = context.Message.TaxPercentage
			});

			return Task.FromResult(0);
		}
	}
}
