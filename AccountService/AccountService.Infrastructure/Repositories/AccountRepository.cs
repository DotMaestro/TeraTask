using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using AccountService.Infrastructure.Database;

namespace AccountService.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _context;

        public AccountRepository(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountAsync(Guid accountNumber)
        {
            var account = await _context.Accounts.FindAsync(accountNumber);

            if(account == null)
            {
                throw new ArgumentException("Account Does Not Exists!");
            }

            return account;
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
