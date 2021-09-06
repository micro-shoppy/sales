using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Sales.Entities;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.Orders.Queries
{
	public class ReadOrderQueryHandler : OrdersHandler<ReadOrderQuery, Order>
	{
		public ReadOrderQueryHandler(IRepository<Order> repo) : base(repo)
		{
		}

		public override Task<Order> Handle(ReadOrderQuery request, CancellationToken cancellationToken)
		{
			return Repo.ReadItem(request.OrderId);
		}
	}
}
