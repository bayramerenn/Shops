using AutoMapper;
using MediatR;
using Shops.Application.Commons;
using Shops.Application.Exceptions;
using Shops.Application.Repositories.Writes;
using Shops.Domain.Entities;

namespace Shops.Application.Features.Commands.Invoices.CreateInvoice
{
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceRequest, CreateInvoiceResponse>
    {
        private readonly IInvoiceWriteRepository _invoiceWriteRepository;
        private readonly IMapper _mapper;

        public CreateInvoiceHandler(IInvoiceWriteRepository invoiceWriteRepository, IMapper mapper)
        {
            _invoiceWriteRepository = invoiceWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateInvoiceResponse> Handle(CreateInvoiceRequest request, CancellationToken cancellationToken)
        {
            var invoice = _mapper.Map<Invoice>(request);

            var result = await _invoiceWriteRepository.AddAsync(invoice, cancellationToken);
            if (!result)
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, new { Invoice = Messages.NotFoundInvoice });
            }

            if (await _invoiceWriteRepository.SaveAsync(cancellationToken) > 0)
            {
                return new CreateInvoiceResponse
                {
                    Message = Messages.SuccessInvoice,
                    Success = true
                };
            }

            throw new RestException(System.Net.HttpStatusCode.BadRequest, new { Invoice = Messages.NotFoundInvoice });
        }
    }
}