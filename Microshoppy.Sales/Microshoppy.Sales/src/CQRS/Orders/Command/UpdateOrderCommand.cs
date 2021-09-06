using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Microshoppy.Sales.CQRS.Orders.Command
{
	public class UpdateOrderCommand : IRequest<Unit>
	{
		public Guid OrderId { get; set; }
		public Guid UserId { get; set; }
		public Dictionary<Guid, int> OrderedProducts { get; set; }
	}
}
