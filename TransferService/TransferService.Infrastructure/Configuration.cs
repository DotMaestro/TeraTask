using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TransferService.Domain.Interfaces;
using TransferService.Infrastructure.Database;
using TransferService.Infrastructure.Repositories;

namespace TransferService.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TransferDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("TransferServiceConnectionString")));

            services.AddScoped<TransferServiceDbContextInitialiser>();
            services.AddScoped<ITransferRepository, TransferRepository>();

            return services;
        }
    }
}
