using AccountService.Application.Dtos;
using AccountService.Domain.Interfaces;

using AutoMapper;

using MediatR;

namespace AccountService.Application.Accounts.Queries
{
    public record GetAccountDetailsQuery(Guid AccountNumber) : IRequest<AccountDetailsDto>;

    public class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery, AccountDetailsDto>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountDetailsQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountDetailsDto> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            var accountEntity = await _accountRepository.GetAccountAsync(request.AccountNumber);

            var accountDetailsDto = _mapper.Map<AccountDetailsDto>(accountEntity);

            return accountDetailsDto;
        }
    }
}
