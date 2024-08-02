using AccountService.Application.Mapper;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace AccountService.Tests.Unit
{
    public class TestStartUp
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            return services.BuildServiceProvider();
        }
    }
}
