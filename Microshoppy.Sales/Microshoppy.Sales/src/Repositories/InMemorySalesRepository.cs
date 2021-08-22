using System;
using System.Collections.Generic;
using System.Linq;

namespace Microshoppy.Sales.src.Repositories
{
	public class InMemorySalesRepository : ISalesRepository
	{
		private static readonly List<SalesProduct> _repo = new();

		public SalesProduct CreateProduct(SalesProduct product)
		{
			_repo.Add(product);
			return product;
		}

		public SalesProduct ReadProduct(Guid productId)
		{
			return _repo.Find(p => p.ProductId == productId);
		}

		public IEnumerable<SalesProduct> ReadProducts()
		{
			return _repo.AsEnumerable();
		}

		public SalesProduct UpdateProduct(Guid productId, SalesProduct product)
		{
			_repo.Remove(_repo.Find(p => p.ProductId == productId));
			_repo.Add(product);
			return product;
		}

		public void DeleteProduct(Guid productId)
		{
			_repo.Remove(_repo.Find(p => p.ProductId == productId));
		}
	}
}
