using Shops.Application.Repositories.Reads;
using Shops.Domain.Entities;
using Shops.Persistence.Context;

namespace Shops.Persistence.Repositories.Reads
{
    public class DiscountReadRepository : ReadRepository<Discount>, IDiscountReadRepository
    {
        public DiscountReadRepository(ShopsDbContext context) : base(context)
        {
        }
    }
}