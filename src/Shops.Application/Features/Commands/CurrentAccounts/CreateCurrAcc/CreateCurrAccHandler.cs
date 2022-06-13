using AutoMapper;
using MediatR;
using Shops.Application.Commons;
using Shops.Application.Exceptions;
using Shops.Application.Repositories.Writes;
using Shops.Domain.Entities;

namespace Shops.Application.Features.Commands.CurrentAccounts.CreateCurrAcc
{
    public class CreateCurrAccHandler : IRequestHandler<CreateCurrAccRequest, CreateCurrAccResponse>
    {
        private readonly ICurrentAccountWriteRepository _currAccWriteRepository;
        private readonly IMapper _mapper;

        public CreateCurrAccHandler(ICurrentAccountWriteRepository currAccWriteRepository, IMapper mapper)
        {
            _currAccWriteRepository = currAccWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCurrAccResponse> Handle(CreateCurrAccRequest request, CancellationToken cancellationToken)
        {
            var currentAccount = _mapper.Map<CurrentAccount>(request);

            var result = await _currAccWriteRepository.AddAsync(currentAccount, cancellationToken);

            if (!result)
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, new { CurrentAccount = Messages.NotFoundCurrentAccount });
            }

            if (await _currAccWriteRepository.SaveAsync(cancellationToken) > 0)
            {
                return new CreateCurrAccResponse
                {
                    Message = Messages.SuccessCurrentAccount,
                    Success = true
                };
            }

            throw new RestException(System.Net.HttpStatusCode.BadRequest, new { CurrentAccount = Messages.NotFoundCurrentAccount });
        }
    }
}