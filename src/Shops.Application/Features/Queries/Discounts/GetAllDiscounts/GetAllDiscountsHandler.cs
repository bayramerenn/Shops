using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shops.Application.Commons;
using Shops.Application.Dtos;
using Shops.Application.Exceptions;
using Shops.Application.Repositories.Reads;

namespace Shops.Application.Features.Queries.Discounts.GetAllDiscounts
{
    public class GetAllDiscountsHandler : IRequestHandler<GetAllDiscountsResponse, IList<DiscountDto>>
    {
        private readonly IDiscountReadRepository _discountReadRepository;
        private readonly IMapper _mapper;

        public GetAllDiscountsHandler(IDiscountReadRepository discountReadRepository, IMapper mapper)
        {
            _discountReadRepository = discountReadRepository;
            _mapper = mapper;
        }

        public async Task<IList<DiscountDto>> Handle(GetAllDiscountsResponse request, CancellationToken cancellationToken)
        {
            var result = await _discountReadRepository.GetAll(true).ToListAsync(cancellationToken);

            if (result is null)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { discounts = Messages.NotFoundDiscountList });
            }

            return _mapper.Map<IList<DiscountDto>>(result);
        }
    }
}