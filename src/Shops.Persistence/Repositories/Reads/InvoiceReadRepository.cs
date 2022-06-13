using Shops.Application.Repositories.Reads;
using Shops.Domain.Entities;
using Shops.Persistence.Context;

namespace Shops.Persistence.Repositories.Reads
{
    public class InvoiceReadRepository : ReadRepository<Invoice>, IInvoiceReadRepository
    {
        public InvoiceReadRepository(ShopsDbContext context) : base(context)
        {
        }
    }
}