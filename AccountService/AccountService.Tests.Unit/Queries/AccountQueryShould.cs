using AccountService.Application.Accounts.Queries;
using AccountService.Application.Dtos;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace AccountService.Tests.Unit.Queries
{
    [Collection("AccountCollection")]
    public class AccountQueryShould
    {
        private readonly IServiceProvider _serviceProvider;

        public AccountQueryShould(ServiceProviderFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task GetAccountDetailsByAccountNumber()
        {
            // Arrange 
            var accountNumber = Guid.NewGuid();
            var accountHolder = "Test Holder";
            var accountEntity = new Account(accountNumber, accountHolder);

            var accountDetailsDto = new AccountDetailsDto(accountEntity.AccountNumber, accountEntity.AccountHolder, accountEntity.CreatedDate);

            var accountRepoMock = new Mock<IAccountRepository>();
            accountRepoMock.Setup(repo => repo.GetAccountAsync(accountEntity.AccountNumber)).ReturnsAsync(accountEntity);

            var queryHandler = new GetAccountDetailsQueryHandler(accountRepoMock.Object, _serviceProvider.GetRequiredService<IMapper>());
            var query = new GetAccountDetailsQuery(accountEntity.AccountNumber);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AccountDetailsDto>(result);
        }

        [Fact]
        public async Task GetAccountBalanceByAccountNumber()
        {
            // Arrange 
            var accountNumber = Guid.NewGuid();
            var accountHolder = "Test Holder";
            var accountEntity = new Account(accountNumber, accountHolder);
            accountEntity.Deposit(400.00m);

            var accountBalanceDto = new AccountBalanceDto(accountEntity.AccountNumber, accountEntity.Balance);

            var accountRepoMock = new Mock<IAccountRepository>();
            accountRepoMock.Setup(repo => repo.GetAccountAsync(accountEntity.AccountNumber)).ReturnsAsync(accountEntity);

            var queryHandler = new AccountBalanceDtoQueryHandler(accountRepoMock.Object, _serviceProvider.GetRequiredService<IMapper>());
            var query = new GetAccountBalanceQuery(accountEntity.AccountNumber);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AccountBalanceDto>(result);
        }
    }
}
