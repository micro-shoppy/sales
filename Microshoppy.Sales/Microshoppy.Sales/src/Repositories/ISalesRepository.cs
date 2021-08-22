using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microshoppy.Sales.src.Repositories
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
