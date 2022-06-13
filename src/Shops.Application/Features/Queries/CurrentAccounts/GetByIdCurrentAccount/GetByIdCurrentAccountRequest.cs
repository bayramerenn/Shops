using MediatR;

namespace Shops.Application.Features.Queries.CurrentAccounts.GetByIdCurrentAccount
{
    public class GetByIdCurrentAccountRequest : IRequest<GetByIdCurrentAccountResponse>
    {
        public Guid Id { get; set; }

        public GetByIdCurrentAccountRequest(Guid id)
        {
            Id = id;
        }
    }
}