using AutoMapper;
using MediatR;
using Shops.Application.Commons;
using Shops.Application.Dtos;
using Shops.Application.Exceptions;
using Shops.Application.Repositories.Reads;

namespace Shops.Application.Features.Queries.CurrentAccounts.GetByIdCurrentAccount
{
    public class GetByIdCurrentAccountHandler : IRequestHandler<GetByIdCurrentAccountRequest, GetByIdCurrentAccountResponse>
    {
        private readonly ICurrentAccountReadRepository _currAccReadRepository;
        private readonly IMapper _mapper;

        public GetByIdCurrentAccountHandler(ICurrentAccountReadRepository currAccReadRepository, IMapper mapper)
        {
            _currAccReadRepository = currAccReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCurrentAccountResponse> Handle(GetByIdCurrentAccountRequest request, CancellationToken cancellationToken)
        {
            var result = await _currAccReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (result is null)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { CurrentAccount = Messages.NotFoundGetCurrentAccountList(request.Id)});
            }
            return new GetByIdCurrentAccountResponse
            {
                CurrentAccountDto = _mapper.Map<CurrentAccountDto>(result)
            };
        }
    }
}