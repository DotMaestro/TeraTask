using Microsoft.EntityFrameworkCore;

using System.Reflection;

using TransferService.Domain.Entities;

namespace TransferService.Infrastructure.Database
{
    public class TransferDbContext : DbContext
    {
        public DbSet<Transfer> Transfers { get; set; }

        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
