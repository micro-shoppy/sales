using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microshoppy.Sales.Entities;

namespace Microshoppy.Sales.Repositories
{
	public class InMemoryOrdersRepository : IRepository<Order>
	{
		private static readonly List<Order> Repo = new();

		public Task<Order> CreateItem(Order order)
		{
			Repo.Add(order);
			return Task.FromResult(order);
		}

		public Task<Order> ReadItem(Guid orderId)
		{
			return Task.FromResult(Repo.First(o => o.OrderId == orderId));
		}

		public Task<IEnumerable<Order>> ReadItems()
		{
			return Task.FromResult(Repo.AsEnumerable());
		}

		public Task<Order> UpdateItem(Guid orderId, Order order)
		{
			Repo.Remove(Repo.Find(o => o.OrderId == orderId));
			Repo.Add(order);
			return Task.FromResult(order);
		}

		public void DeleteItem(Guid orderId)
		{
			Repo.Remove(Repo.Find(o => o.OrderId == orderId));
		}
	}
}
