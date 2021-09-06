using System.Collections.Generic;
using System;
using MediatR;

namespace Microshoppy.Sales.CQRS.Orders.Command
{
	public class CreateOrderCommand : IRequest<Unit>
	{
		public Guid UserId { get; set; }
		public Dictionary<Guid, int> OrderedProducts { get; set; }
	}
}
