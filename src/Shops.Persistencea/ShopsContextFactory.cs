using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shops.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Persistence
{
    public class ShopsContextFactory : IDesignTimeDbContextFactory<ShopsDbContext>
    {
        public ShopsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopsDbContext>();
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            throw new NotImplementedException();
        }
    }
}
