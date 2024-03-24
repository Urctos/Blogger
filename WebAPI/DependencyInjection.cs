using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrasttructure(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
