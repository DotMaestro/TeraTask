using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

using TransferService.Application.Mappers;
using TransferService.Application.Transfers.Commands;

namespace TransferService.Application
{
    public static class Configuration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateTransferCommand))!));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            return services;
        }
    }
}
