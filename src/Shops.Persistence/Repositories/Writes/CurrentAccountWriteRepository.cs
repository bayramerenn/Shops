using Shops.Application.Repositories.Writes;
using Shops.Domain.Entities;
using Shops.Persistence.Context;

namespace Shops.Persistence.Repositories.Writes
{
    public class CurrentAccountWriteRepository : WriteRepository<CurrentAccount>, ICurrentAccountWriteRepository
    {
        public CurrentAccountWriteRepository(ShopsDbContext context) : base(context)
        {
        }
    }
}