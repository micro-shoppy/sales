using MediatR;

namespace Microshoppy.Sales.CQRS.SalesProducts.Commands
{
	public class CreateSalesProductCommand : IRequest<Unit>
	{
		public decimal Cost { get; set; }

		public decimal NetPrice { get; set; }

		public decimal TaxPercentage { get; set; }
	}
}
