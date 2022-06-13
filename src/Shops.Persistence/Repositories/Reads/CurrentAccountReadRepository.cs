using Shops.Application.Repositories.Reads;
using Shops.Domain.Entities;
using Shops.Persistence.Context;

namespace Shops.Persistence.Repositories.Reads
{
    public class CurrentAccountReadRepository : ReadRepository<CurrentAccount>, ICurrentAccountReadRepository
    {
        public CurrentAccountReadRepository(ShopsDbContext context) : base(context)
        {
        }
    }
}