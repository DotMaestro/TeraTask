using AccountService.Application.Dtos;
using AccountService.Domain.Interfaces;

using AutoMapper;

using MediatR;

namespace AccountService.Application.Accounts.Queries
{
    public record GetAccountBalanceQuery(Guid AccountNumber) : IRequest<AccountBalanceDto>;

    public class AccountBalanceDtoQueryHandler : IRequestHandler<GetAccountBalanceQuery, AccountBalanceDto>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountBalanceDtoQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountBalanceDto> Handle(GetAccountBalanceQuery request, CancellationToken cancellationToken)
        {
            var accountEntity = await _accountRepository.GetAccountAsync(request.AccountNumber);

            var accountBalanceDto = _mapper.Map<AccountBalanceDto>(accountEntity);

            return accountBalanceDto;
        }
    }
}
