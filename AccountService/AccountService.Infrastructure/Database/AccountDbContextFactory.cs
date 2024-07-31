using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccountService.Infrastructure.Database
{
    public class AccountDbContextFactory : IDesignTimeDbContextFactory<AccountDbContext>
    {
        public AccountDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = config.GetConnectionString("AccountServiceConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<AccountDbContext>()
                .UseSqlServer(connectionString);

            return new AccountDbContext(optionsBuilder.Options);
        }
    }
}