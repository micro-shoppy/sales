using System;
using System.Collections.Generic;
using MediatR;
using Microshoppy.Sales.Entities;

namespace Microshoppy.Sales.CQRS.Orders.Queries
{
	public class ReadOrdersPerUserQuery : IRequest<IEnumerable<Order>>
	{
		public Guid UserId { get; set; }
	}
}
