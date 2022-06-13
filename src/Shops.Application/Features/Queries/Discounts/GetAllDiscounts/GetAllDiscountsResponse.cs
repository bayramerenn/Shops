using MediatR;
using Shops.Application.Dtos;

namespace Shops.Application.Features.Queries.Discounts.GetAllDiscounts
{
    public class GetAllDiscountsResponse : IRequest<IList<DiscountDto>>
    {
    }
}