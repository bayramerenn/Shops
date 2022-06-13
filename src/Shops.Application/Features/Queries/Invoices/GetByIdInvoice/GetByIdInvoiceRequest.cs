using MediatR;

namespace Shops.Application.Features.Queries.Invoices.GetByIdInvoice
{
    public class GetByIdInvoiceRequest : IRequest<GetByIdInvoiceResponse>
    {
        public Guid Id { get; set; }

        public GetByIdInvoiceRequest(Guid id)
        {
            Id = id;
        }
    }
}