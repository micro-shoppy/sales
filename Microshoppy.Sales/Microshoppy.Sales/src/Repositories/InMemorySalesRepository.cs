using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microshoppy.Sales.Repositories
{
	public class InMemorySalesRepository : IRepository<SalesProduct>
	{
		private static readonly List<SalesProduct> Repo = new();

		public Task<SalesProduct> CreateItem(SalesProduct product)
		{
			Repo.Add(product);
			return Task.FromResult(product);
		}

		public Task<SalesProduct> ReadItem(Guid productId)
		{
			return Task.FromResult(Repo.First(p => p.ProductId == productId));
		}

		public Task<IEnumerable<SalesProduct>> ReadItems()
		{
			return Task.FromResult(Repo.AsEnumerable());
		}

		public Task<SalesProduct> UpdateItem(Guid productId, SalesProduct product)
		{
			Repo.Remove(Repo.Find(p => p.ProductId == productId));
			Repo.Add(product);
			return Task.FromResult(product);
		}

		public void DeleteItem(Guid productId)
		{
			Repo.Remove(Repo.Find(p => p.ProductId == productId));
		}
	}
}
