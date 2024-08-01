using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TransferService.Infrastructure.Database
{
    public class TransferServiceDbContextInitialiser
    {
        private readonly ILogger<TransferDbContext> _logger;
        private readonly TransferDbContext _context;

        public TransferServiceDbContextInitialiser(ILogger<TransferDbContext> logger, TransferDbContext context)
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
    }
}
