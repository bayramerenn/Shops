using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shops.Persistence.Context;

namespace Shops.Persistence
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ShopsDbContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=ShopsDb;Integrated Security=True"));
            return services;
        }
    }
}