using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Shops.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection));
            services.AddAutoMapper(typeof(DependencyInjection));
            return services;
        }
    }
}