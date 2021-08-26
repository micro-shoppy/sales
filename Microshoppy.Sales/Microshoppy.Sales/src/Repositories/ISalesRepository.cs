using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microshoppy.Sales.Repositories
{
	public interface ISalesRepository
	{
		Task<SalesProduct> CreateProduct(SalesProduct product);
		Task<SalesProduct> ReadProduct(Guid productId);
		Task<IEnumerable<SalesProduct>> ReadProducts();
		Task<SalesProduct> UpdateProduct(Guid productId, SalesProduct product);
		void DeleteProduct(Guid productId);
	}
}
