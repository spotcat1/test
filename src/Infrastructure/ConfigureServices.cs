
using Application.Contracts.User;
using FluentValidation;
using Infrastructure.CrossCuttings.Validations.UserValidations;
using Infrastructure.Persistants;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("UserDataCenterConnectionString")));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            ValidatorOptions.Global.LanguageManager = new UserValidatorCustomLanguage();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());  
            });

            services.AddHttpContextAccessor();


            return services;
        }
    }
}
