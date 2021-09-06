using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microshoppy.Sales.Repositories
{
	public interface IRepository<T>
	{
		Task<T> CreateItem(T item);
		Task<T> ReadItem(Guid id);
		Task<IEnumerable<T>> ReadItems();
		Task<T> UpdateItem(Guid id, T item);
		void DeleteItem(Guid id);
	}
}
