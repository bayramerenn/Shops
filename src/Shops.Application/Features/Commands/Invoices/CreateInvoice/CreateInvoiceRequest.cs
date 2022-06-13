using MediatR;

namespace Shops.Application.Features.Commands.Invoices.CreateInvoice
{
    public class CreateInvoiceRequest : IRequest<CreateInvoiceResponse>
    {
        public decimal Amount { get; set; }
        public bool IsGrocery { get; set; }
        public Guid CurrentAccountId { get; set; }
    }
}