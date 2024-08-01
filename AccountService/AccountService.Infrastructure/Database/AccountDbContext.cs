using AccountService.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace AccountService.Infrastructure.Database
{
    public class AccountDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountNumber);

            base.OnModelCreating(modelBuilder);
        }
    }
}
