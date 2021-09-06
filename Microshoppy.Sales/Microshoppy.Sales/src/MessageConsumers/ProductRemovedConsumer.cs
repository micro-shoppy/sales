using MassTransit;
using MicroShoppy.Contract.Events;
using Microshoppy.Sales.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Microshoppy.Sales.MessageConsumers
{
	public class ProductRemovedConsumer : IConsumer<IProductRemoved>
	{
		private readonly IRepository<SalesProduct> _repo;
		private ILogger<ProductRemovedConsumer> _logger;

		public ProductRemovedConsumer(IRepository<SalesProduct> repo, ILogger<ProductRemovedConsumer> logger)
		{
			_repo = repo;
			_logger = logger;
		}
		public Task Consume(ConsumeContext<IProductRemoved> context)
		{
			_repo.DeleteItem(context.Message.ProductId);

			return Task.FromResult(0);
		}
	}
}
