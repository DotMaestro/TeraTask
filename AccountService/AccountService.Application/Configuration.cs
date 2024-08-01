using AccountService.Application.Accounts.Commands;
using AccountService.Application.Consumers;
using AccountService.Application.Mapper;

using MassTransit;

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

            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.AddConsumer<UpdateAccountBalanceConsumer, UpdateAccountBalanceConsumerDefinition>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("", _ => { });
                    cfg.UseMessageRetry(r => r.Immediate(3));
                    cfg.ConfigureEndpoints(context);
                });

            });


            return services;
        }
    }
}
