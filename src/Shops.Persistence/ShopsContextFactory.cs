using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shops.Persistence.Context;

namespace Shops.Persistence
{
    public class ShopsContextFactory : IDesignTimeDbContextFactory<ShopsDbContext>
    {
        public ShopsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopsDbContext>();
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(optionsBuilder.Options);
        }
    }
}