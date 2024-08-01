using TransferService.Domain.Entities;
using TransferService.Domain.Interfaces;
using TransferService.Infrastructure.Database;

namespace TransferService.Infrastructure.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _context;

        public TransferRepository(TransferDbContext context)
        {
            _context = context;
        }

        public void Create(Transfer transferEntity)
        {
            if (transferEntity == null)
            {
                throw new ArgumentNullException(nameof(transferEntity));
            }
            _context.Set<Transfer>().Add(transferEntity);
            _context.SaveChanges();
        }
    }
}
