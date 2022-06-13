using Shops.Application.Repositories.Reads;
using Shops.Domain.Entities;
using Shops.Persistence.Context;

namespace Shops.Persistence.Repositories.Reads
{
    public class CurrentAccountTypeReadRepository : ReadRepository<CurrentAccountType>, ICurrentAccountTypeReadRepository
    {
        public CurrentAccountTypeReadRepository(ShopsDbContext context) : base(context)
        {
        }
    }
}