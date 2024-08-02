using AccountService.API.Controllers;
using AccountService.Application.Accounts.Queries;
using AccountService.Application.Dtos;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Moq;

namespace AccountService.Tests.Unit.Controllers
{
    [Collection("MyCollection")]
    public class AccountControllerShould
    {
        private readonly IServiceProvider _serviceProvider;

        public AccountControllerShould(ServiceProviderFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task GetAccountDetailsByAccountNumber()
        {
            // Arrange
            var mediatorMock = new Mock<ISender>();

            var accountDetails = new AccountDetailsDto(Guid.NewGuid(), "Test person", DateTime.UtcNow);

            mediatorMock.Setup(m => m.Send(It.IsAny<GetAccountDetailsQuery>(), default)).ReturnsAsync(accountDetails);

            var controller = new AccountsController(mediatorMock.Object);

            // Act
            var result = await controller.GetAccountDetailsAsync(accountDetails.AccountNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var accountDetailsDto = Assert.IsAssignableFrom<AccountDetailsDto>(okResult.Value);

            Assert.NotNull(accountDetailsDto);
            Assert.Equal(accountDetails.AccountNumber, accountDetailsDto.AccountNumber);
            Assert.Equal(accountDetails.AccountHolder, accountDetailsDto.AccountHolder);
            Assert.Equal(accountDetails.CreatedDate, accountDetailsDto.CreatedDate);
        }

        [Fact]
        public async Task GetAccountBalanceByAccountNumber()
        {
            // Arrange
            var mediatorMock = new Mock<ISender>();

            var accountBalance = new AccountBalanceDto(Guid.NewGuid(), 400.00m);

            mediatorMock.Setup(m => m.Send(It.IsAny<GetAccountBalanceQuery>(), default)).ReturnsAsync(accountBalance);

            var controller = new AccountsController(mediatorMock.Object);

            // Act 
            var result = await controller.GetAccountBalanceAsync(accountBalance.AccountNumber);

            // Assert 
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var accountBalanceDto = Assert.IsAssignableFrom<AccountBalanceDto>(okResult.Value);

            Assert.NotNull(accountBalanceDto);
            Assert.Equal(accountBalance.AccountNumber, accountBalanceDto.AccountNumber);
            Assert.Equal(accountBalance.Balance, accountBalanceDto.Balance);

        }

    }
}
