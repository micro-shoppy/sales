using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Microshoppy.Sales.CQRS.Orders;
using Microshoppy.Sales.Entities;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.Orders.Queries
{
	public class ReadOrdersQueryHandler : OrdersHandler<ReadOrdersQuery, IEnumerable<Order>>
	{
		public ReadOrdersQueryHandler(IRepository<Order> repo) : base(repo)
		{
		}

		public override Task<IEnumerable<Order>> Handle(ReadOrdersQuery request, CancellationToken cancellationToken)
		{
			return Repo.ReadItems();
		}
	}
}
