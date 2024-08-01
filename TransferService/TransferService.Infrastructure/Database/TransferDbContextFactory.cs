using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TransferService.Infrastructure.Database
{
    public class TransferDbContextFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = config.GetConnectionString("TransferServiceConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<TransferDbContext>()
                .UseSqlServer(connectionString);

            return new TransferDbContext(optionsBuilder.Options);
        }
    }
}