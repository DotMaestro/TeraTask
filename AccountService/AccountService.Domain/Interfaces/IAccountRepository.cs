using AccountService.Domain.Entities;

namespace AccountService.Domain.Interfaces
{
    public interface IAccountRepository
    {
        public Task<Account> GetAccountAsync(Guid accountNumber);
        public Task UpdateAsync(Account account);
    }
}
