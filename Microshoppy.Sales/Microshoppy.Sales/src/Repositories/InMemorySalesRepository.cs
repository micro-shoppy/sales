using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microshoppy.Sales.Repositories
{
	public class InMemorySalesRepository : ISalesRepository
	{
		private static readonly List<SalesProduct> _repo = new();

		public Task<SalesProduct> CreateProduct(SalesProduct product)
		{
			_repo.Add(product);
			return Task.FromResult(product);
		}

		public Task<SalesProduct> ReadProduct(Guid productId)
		{
			return Task.FromResult(_repo.First(p => p.ProductId == productId));
		}

		public Task<IEnumerable<SalesProduct>> ReadProducts()
		{
			return Task.FromResult(_repo.AsEnumerable());
		}

		public Task<SalesProduct> UpdateProduct(Guid productId, SalesProduct product)
		{
			_repo.Remove(_repo.Find(p => p.ProductId == productId));
			_repo.Add(product);
			return Task.FromResult(product);
		}

		public void DeleteProduct(Guid productId)
		{
			_repo.Remove(_repo.Find(p => p.ProductId == productId));
		}
	}
}
