using MediatR;
using Shops.Application.Dtos;

namespace Shops.Application.Features.Queries.CurrentAccountTypes
{
    public class GetAllCurrentAccountTypeResponse : IRequest<IList<CurrentAccountTypeDto>>
    {
    }
}