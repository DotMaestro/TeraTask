using AccountService.Application.Dtos;
using AccountService.Domain.Interfaces;

using MediatR;

namespace AccountService.Application.Accounts.Commands
{
    public record UpdateAccountBalanceCommand(UpdateBalanceDto Dto) : IRequest;

    public class UpdateAccountBalanceCommandHandler : IRequestHandler<UpdateAccountBalanceCommand>
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountBalanceCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task Handle(UpdateAccountBalanceCommand request, CancellationToken cancellationToken)
        {
            var accountEntity = await _accountRepository.GetAccountAsync(request.Dto.AccountNumber);

            // negative values represent withdrawals and positive values represent deposits.
            if(request.Dto.Amount < 0)
            {
                accountEntity.Withdraw(request.Dto.Amount);
            } else
            {
                accountEntity.Deposit(request.Dto.Amount);
            }

            await _accountRepository.UpdateAsync(accountEntity);
        }
    }
}
