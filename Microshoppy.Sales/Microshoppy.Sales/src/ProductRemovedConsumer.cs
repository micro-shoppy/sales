using MassTransit;
using MicroShoppy.Contract.Events;
using Microshoppy.Sales.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Microshoppy.Sales
{
	public class ProductRemovedConsumer : IConsumer<IProductRemoved>
	{
		private readonly ISalesRepository _repo;
		private ILogger<ProductRemovedConsumer> _logger;

		public ProductRemovedConsumer(ISalesRepository repo, ILogger<ProductRemovedConsumer> logger)
		{
			_repo = repo;
			_logger = logger;
		}
		public Task Consume(ConsumeContext<IProductRemoved> context)
		{
			_repo.DeleteProduct(context.Message.ProductId);

			return Task.FromResult(0);
		}
	}
}
