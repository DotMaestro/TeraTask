using MassTransit;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TransferService.Application.Mappers;

namespace TransferService.Tests.Unit
{
    public class TestStartUp
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("amqp://guest:guest@rabbitmq:5672", _ => { });
                    cfg.ConfigureEndpoints(context);
                });
            });

            return services.BuildServiceProvider();
        }
    }
}
