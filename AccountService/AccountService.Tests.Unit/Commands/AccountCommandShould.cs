using AccountService.Application.Accounts.Commands;
using AccountService.Application.Dtos;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;

using Moq;

namespace AccountService.Tests.Unit.Commands
{
    [Collection("AccountCollection")]
    public class AccountCommandShould
    {
        private readonly IServiceProvider _serviceProvider;

        public AccountCommandShould(ServiceProviderFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task UpdateAccountBalanceWithPositiveNumber()
        {
            // Arrange 
            var accountNumber = Guid.NewGuid();
            var accountHolder = "Test Holder";
            var accountEntity = new Account(accountNumber, accountHolder);
            accountEntity.Deposit(400.00m);

            var updateAccountDto = new UpdateBalanceDto(accountEntity.AccountNumber, 200.00m);

            var accountRepoMock = new Mock<IAccountRepository>();
            accountRepoMock.Setup(repo => repo.GetAccountAsync(accountEntity.AccountNumber)).ReturnsAsync(accountEntity);

            var commandHandler = new UpdateAccountBalanceCommandHandler(accountRepoMock.Object);
            var command = new UpdateAccountBalanceCommand(updateAccountDto);

            // Act
            await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(600.00m, accountEntity.Balance);
        }


        [Fact]
        public async Task UpdateAccountBalanceWithNegativeNumber()
        {
            // Arrange 
            var accountNumber = Guid.NewGuid();
            var accountHolder = "Test Holder";
            var accountEntity = new Account(accountNumber, accountHolder);
            accountEntity.Deposit(400.00m);

            var updateAccountDto = new UpdateBalanceDto(accountEntity.AccountNumber, -200.00m);

            var accountRepoMock = new Mock<IAccountRepository>();
            accountRepoMock.Setup(repo => repo.GetAccountAsync(accountEntity.AccountNumber)).ReturnsAsync(accountEntity);

            var commandHandler = new UpdateAccountBalanceCommandHandler(accountRepoMock.Object);
            var command = new UpdateAccountBalanceCommand(updateAccountDto);

            // Act
            await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(200.00m, accountEntity.Balance);
        }
    }
}
