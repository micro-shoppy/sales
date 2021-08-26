using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microshoppy.Sales.Repositories
{
	public class InMemorySalesRepository : ISalesRepository
	{
		private static readonly List<SalesProduct> Repo = new();

		public Task<SalesProduct> CreateProduct(SalesProduct product)
		{
			Repo.Add(product);
			return Task.FromResult(product);
		}

		public Task<SalesProduct> ReadProduct(Guid productId)
		{
			return Task.FromResult(Repo.First(p => p.ProductId == productId));
		}

		public Task<IEnumerable<SalesProduct>> ReadProducts()
		{
			return Task.FromResult(Repo.AsEnumerable());
		}

		public Task<SalesProduct> UpdateProduct(Guid productId, SalesProduct product)
		{
			Repo.Remove(Repo.Find(p => p.ProductId == productId));
			Repo.Add(product);
			return Task.FromResult(product);
		}

		public void DeleteProduct(Guid productId)
		{
			Repo.Remove(Repo.Find(p => p.ProductId == productId));
		}
	}
}
