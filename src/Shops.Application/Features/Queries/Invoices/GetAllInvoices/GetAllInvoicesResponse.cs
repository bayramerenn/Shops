using MediatR;
using Shops.Application.Dtos;

namespace Shops.Application.Features.Queries.Invoices.GetAllInvoices
{
    public class GetAllInvoicesResponse : IRequest<IList<InvoiceListDto>>
    {
    }
}