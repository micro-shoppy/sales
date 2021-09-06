using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microshoppy.Sales.Entities
{
	public class Order
	{
		public Guid OrderId { get; set; }
		public Guid UserId { get; set; }
		public Dictionary<Guid, int> OrderedProducts { get; set; }
		public Status Status { get; set; }
	}
}
