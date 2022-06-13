using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shops.Application.Commons;
using Shops.Application.Dtos;
using Shops.Application.Exceptions;
using Shops.Application.Repositories.Reads;

namespace Shops.Application.Features.Queries.Invoices.GetAllInvoices
{
    public class GetAllInvoicesHandler : IRequestHandler<GetAllInvoicesResponse, IList<InvoiceListDto>>
    {
        private readonly IInvoiceReadRepository _invoiceReadRepository;
        private readonly IMapper _mapper;

        public GetAllInvoicesHandler(IInvoiceReadRepository invoiceReadRepository, IMapper mapper)
        {
            _invoiceReadRepository = invoiceReadRepository;
            _mapper = mapper;
        }

        public async Task<IList<InvoiceListDto>> Handle(GetAllInvoicesResponse request, CancellationToken cancellationToken)
        {
            var result = await _invoiceReadRepository.GetAll(true).Include(c => c.CurrentAccount).ToListAsync(cancellationToken);

            if (result is null)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { invoices = Messages.NotFoundInvoiceList });
            }

            return _mapper.Map<IList<InvoiceListDto>>(result);
        }
    }
}