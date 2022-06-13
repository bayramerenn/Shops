using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shops.Application.Commons;
using Shops.Application.Dtos;
using Shops.Application.Exceptions;
using Shops.Application.Repositories.Reads;

namespace Shops.Application.Features.Queries.CurrentAccounts.GetAllCurrentAccounts
{
    public class GetAllCurrentAccountHandler : IRequestHandler<GetAllCurrentAccountResponse, IList<CurrentAccountDto>>
    {
        private readonly ICurrentAccountReadRepository _currAccReadRepository;
        private readonly IMapper _mapper;

        public GetAllCurrentAccountHandler(ICurrentAccountReadRepository currAccReadRepository, IMapper mapper)
        {
            _currAccReadRepository = currAccReadRepository;
            _mapper = mapper;
        }

        public async Task<IList<CurrentAccountDto>> Handle(GetAllCurrentAccountResponse request, CancellationToken cancellationToken)
        {
            var result = await _currAccReadRepository.GetAll(true).Include(c => c.CurrentAccountType).ToListAsync(cancellationToken);

            if (result is null)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { CurrentAccounts = Messages.NotFoundCurrentAccountList });
            }

            return _mapper.Map<IList<CurrentAccountDto>>(result);
        }
    }
}