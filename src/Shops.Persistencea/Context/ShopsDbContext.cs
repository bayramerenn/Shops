using Microsoft.EntityFrameworkCore;
using Shops.Domain.Common;
using Shops.Domain.Entities;

namespace Shops.Persistence.Context
{
    public class ShopsDbContext : DbContext
    {
        public ShopsDbContext(DbContextOptions<ShopsDbContext> options) : base(options)
        {
        }

        public DbSet<CurrentAccount> CurrentAccounts { get; set; }
        public DbSet<CurrentAccountType> CurrentAccountTypes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}