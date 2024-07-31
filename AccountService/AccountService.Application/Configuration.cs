using AccountService.Application.Accounts.Commands;
using AccountService.Application.Mapper;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace AccountService.Application
{
    public static class Configuration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(UpdateAccountBalanceCommand))!));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            return services;
        }
    }
}
