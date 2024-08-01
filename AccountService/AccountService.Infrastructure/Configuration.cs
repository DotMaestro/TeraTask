using AccountService.Domain.Interfaces;
using AccountService.Infrastructure.Database;
using AccountService.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountDbContext>(
                options => 
                options.UseSqlServer(
                    configuration.GetConnectionString("AccountServiceConnectionString"),
                opt => opt.EnableRetryOnFailure()));

            services.AddScoped<AccountServiceDbContextInitialiser>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
