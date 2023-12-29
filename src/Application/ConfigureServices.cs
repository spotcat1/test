

using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUser, User>();

            return services;
        }
    }
}
