using MediatR;

namespace Shops.Application.Features.Commands.CurrentAccounts.CreateCurrAcc
{
    public class CreateCurrAccRequest : IRequest<CreateCurrAccResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAffiliate { get; set; }
        public Guid CurrentAccountTypeId { get; set; }
    }
}