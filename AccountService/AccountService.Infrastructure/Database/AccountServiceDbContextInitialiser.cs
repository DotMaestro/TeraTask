using AccountService.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AccountService.Infrastructure.Database
{
    public class AccountServiceDbContextInitialiser
    {
        private readonly ILogger<AccountDbContext> _logger;
        private readonly AccountDbContext _context;

        public AccountServiceDbContextInitialiser(ILogger<AccountDbContext> logger, AccountDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while initialising the database");
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            await SeedAccounts();
        }

        public async Task SeedAccounts()
        {
            if(!_context.Accounts.Any())
            {
                var gio = new Account(Guid.NewGuid(), "Giorgi Didebulidze");
                var jemal = new Account(Guid.NewGuid(), "Jemal Bagashvili");
                var jon = new Account(Guid.NewGuid(), "Jemal Bagashvili");
                var nugzari = new Account(Guid.NewGuid(), "Nugzari Tyemaladze");
                var avto = new Account(Guid.NewGuid(), "Avto Mgeladze");
                var irodioni = new Account(Guid.NewGuid(), "Irodion Mosidze");

                gio.Deposit(3000.00m);
                jemal.Deposit(40000.00m);
                jon.Deposit(1200.00m);
                nugzari.Deposit(10.00m);
                avto.Deposit(1700.00m);
                irodioni.Deposit(1150.00m);


                var accounts = new List<Account>
                {
                    gio, 
                    jemal, 
                    jon, 
                    nugzari, 
                    avto, 
                    irodioni
                };

                await _context.AddRangeAsync(accounts);
                await _context.SaveChangesAsync();
            }
        }
    }
}