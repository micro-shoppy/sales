using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Microshoppy.Sales.src.CQRS.Command
{
	public class DeleteSalesProductCommand : IRequest<Unit>
	{
		public Guid ProductId { get; set; }
	}
}
