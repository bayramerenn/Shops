using MediatR;
using Shops.Application.Dtos;

namespace Shops.Application.Features.Queries.CurrentAccounts.GetAllCurrentAccounts
{
    public class GetAllCurrentAccountResponse : IRequest<IList<CurrentAccountDto>>
    { }
}