using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shops.Application.Commons;
using Shops.Application.Dtos;
using Shops.Application.Exceptions;
using Shops.Application.Repositories.Reads;

namespace Shops.Application.Features.Queries.CurrentAccountTypes
{
    public class GetAllCurrentAccountTypeHandler : IRequestHandler<GetAllCurrentAccountTypeResponse, IList<CurrentAccountTypeDto>>
    {
        private readonly ICurrentAccountTypeReadRepository _currentAccountTypeReadRepository;
        private readonly IMapper _mapper;

        public GetAllCurrentAccountTypeHandler(ICurrentAccountTypeReadRepository currentAccountTypeReadRepository, IMapper mapper)
        {
            _currentAccountTypeReadRepository = currentAccountTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<IList<CurrentAccountTypeDto>> Handle(GetAllCurrentAccountTypeResponse request, CancellationToken cancellationToken)
        {
            var result = await _currentAccountTypeReadRepository.GetAll(true).ToListAsync(cancellationToken);

            if (result is null)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { CurrentAccountType = Messages.NotFoundCurrentAccountTypeList });
            }

            var data = _mapper.Map<IList<CurrentAccountTypeDto>>(result);
            return data;
        }
    }
}