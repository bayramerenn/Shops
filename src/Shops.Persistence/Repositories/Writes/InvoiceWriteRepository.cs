using Shops.Application.Repositories.Writes;
using Shops.Domain.Entities;
using Shops.Persistence.Context;

namespace Shops.Persistence.Repositories.Writes
{
    public class InvoiceWriteRepository : WriteRepository<Invoice>, IInvoiceWriteRepository
    {
        public InvoiceWriteRepository(ShopsDbContext context) : base(context)
        {
        }
    }
}