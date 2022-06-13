using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shops.Application.Commons;
using Shops.Application.Dtos;
using Shops.Application.Exceptions;
using Shops.Application.Handler;
using Shops.Application.Repositories.Reads;
using Shops.Domain.Entities;
using Shops.Domain.Enums;

namespace Shops.Application.Features.Queries.Invoices.GetByIdInvoice
{
    public class GetByIdInvoiceHandler : IRequestHandler<GetByIdInvoiceRequest, GetByIdInvoiceResponse>
    {
        private readonly IInvoiceReadRepository _invoiceReadRepository;
        private readonly ICurrentAccountReadRepository _currentAccountReadRepository;
        private readonly IMapper _mapper;
        private readonly IDiscountReadRepository _discountReadRepository;
        private readonly List<string> _discountsApplied;

        public GetByIdInvoiceHandler(IInvoiceReadRepository invoiceReadRepository, IMapper mapper, ICurrentAccountReadRepository currentAccountReadRepository, IDiscountReadRepository discountReadRepository)
        {
            _invoiceReadRepository = invoiceReadRepository;
            _mapper = mapper;
            _currentAccountReadRepository = currentAccountReadRepository;
            _discountReadRepository = discountReadRepository;
            _discountsApplied = new List<string>();
        }

        public async Task<GetByIdInvoiceResponse> Handle(GetByIdInvoiceRequest request, CancellationToken cancellationToken)
        {
            var result = await _invoiceReadRepository.Table.Include(c => c.CurrentAccount).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (result is null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { invoice = Messages.NotFoundGetIdInvoice(result.Id) });

            var currentAccount = await _currentAccountReadRepository.Table.Include(c => c.CurrentAccountType).FirstOrDefaultAsync(x => x.Id == result.CurrentAccountId, cancellationToken);

            if (currentAccount is null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { currentAccount = Messages.NotFoundInvoiceGetCustomer(result.CurrentAccountId) });

            var discountHandler = await GetNetAmount(currentAccount, result.Amount, result.IsGrocery, cancellationToken);

            var invoiceDto = _mapper.Map<InvoiceDto>(result);
            invoiceDto.NetAmount = discountHandler.GetDiscountAmount();
            invoiceDto.CurrentAccountTypeDesc = currentAccount.CurrentAccountType.CurrentAccountTypeDesc;

            if (invoiceDto.NetAmount >= 100)
            {
                var foldHandler = new FoldDiscount(invoiceDto.NetAmount
                    , await GetPercentage(DiscountContasts.FOLD_DISCOUNT, cancellationToken));
                invoiceDto.NetAmount = foldHandler.GetDiscountAmount();
            }

            invoiceDto.DiscountsApplied = _discountsApplied.ToArray();

            return new GetByIdInvoiceResponse
            {
                InvoiceDto = invoiceDto
            };
        }

        private async Task<DiscountHandler> GetNetAmount(CurrentAccount currentAccount, decimal amount, bool isGrocery, CancellationToken cancellationToken)
        {
            var year = DateTime.Now.Year - currentAccount.CreatedDate.Year;

            if (currentAccount.CurrentAccountType.CurrentAccountTypeDesc == nameof(CurrentAccountTypeEnum.Person))
            {
                return new EmployeeDiscountHandler(amount
                    , await GetPercentage(DiscountContasts.EMPLOYEE_DISCOUNT, cancellationToken));
            }
            else
            {
                if (isGrocery)
                {
                    if (currentAccount.IsAffiliate)
                    {
                        return new AffliateDiscountHandler(amount,
                            await GetPercentage(DiscountContasts.AFFLIATE_DISCOUNT, cancellationToken));
                    }
                    else if (year >= 2)
                    {
                        return new OldCustomerDiscountHandler(amount,
                            await GetPercentage(DiscountContasts.OLDCUSTOMER_DISCOUNT, cancellationToken));
                    }
                }
            }
            return new NotDiscountHandler(amount);
        }

        private async Task<double> GetPercentage(string discountCode, CancellationToken cancellationToken)
        {
            var discount = await _discountReadRepository.GetWhere(x => x.DiscountCode == discountCode).FirstOrDefaultAsync(cancellationToken);
            _discountsApplied.Add(discount.DiscountName);
            return discount.Percentage;
        }
    }
}