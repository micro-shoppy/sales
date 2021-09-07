using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microshoppy.Sales.Entities;
using Microshoppy.Sales.Repositories;

namespace Microshoppy.Sales.CQRS.Orders.Queries
{
	public class ReadOrdersPerUserQueryHandler : OrdersHandler<ReadOrdersPerUserQuery, IEnumerable<Order>>
	{
		public ReadOrdersPerUserQueryHandler(IRepository<Order> repo) : base(repo)
		{
		}

		public override Task<IEnumerable<Order>> Handle(ReadOrdersPerUserQuery request, CancellationToken cancellationToken)
		{
			return Repo.ReadItems().ContinueWith(o => 
				o.Result.Where(order => order.UserId == request.UserId), 
				cancellationToken);
		}
	}
}
