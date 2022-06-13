using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shops.Application.Repositories.Reads;
using Shops.Application.Repositories.Writes;
using Shops.Persistence.Context;
using Shops.Persistence.Repositories.Reads;
using Shops.Persistence.Repositories.Writes;

namespace Shops.Persistence
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ShopsDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<ICurrentAccountWriteRepository, CurrentAccountWriteRepository>();
            services.AddScoped<ICurrentAccountReadRepository, CurrentAccountReadRepository>();
            services.AddScoped<ICurrentAccountTypeReadRepository, CurrentAccountTypeReadRepository>();
            services.AddScoped<IDiscountReadRepository, DiscountReadRepository>();
            services.AddScoped<IInvoiceWriteRepository, InvoiceWriteRepository>();
            services.AddScoped<IInvoiceReadRepository, InvoiceReadRepository>();

            return services;
        }
    }
}