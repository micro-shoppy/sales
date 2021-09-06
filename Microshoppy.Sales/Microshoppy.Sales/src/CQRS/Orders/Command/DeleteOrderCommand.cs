﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Microshoppy.Sales.CQRS.Orders.Command
{
	public class DeleteOrderCommand : IRequest<Unit>
	{
		public Guid OrderId { get; set; }
	}
}
