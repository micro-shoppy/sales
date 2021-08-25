using System;
using System.Collections.Generic;

namespace Microshoppy.Sales.Repositories
{
	public interface ISalesRepository
	{
		SalesProduct CreateProduct(SalesProduct product);
		SalesProduct ReadProduct(Guid productId);
		IEnumerable<SalesProduct> ReadProducts();
		SalesProduct UpdateProduct(Guid productId, SalesProduct product);
		void DeleteProduct(Guid productId);
	}
}
