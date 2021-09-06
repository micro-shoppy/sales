using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microshoppy.Sales.Entities;

namespace Microshoppy.Sales.CQRS.Orders.Queries
{
	public class ReadOrderQuery : IRequest<Order>
	{
		public Guid OrderId { get; set; }
	}
}
