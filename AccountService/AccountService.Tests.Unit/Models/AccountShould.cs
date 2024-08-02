using AccountService.Domain.Entities;

namespace AccountService.Tests.Unit.Models
{
    [Collection("MyCollection")]
    public class AccountShould
    {
        [Fact]
        public void ConstructedWithValidData()
        {
            // Arrange
            var accNumber = Guid.NewGuid();
            var accHolder = "Test Holder";

            // Act
            var account = new Account(accNumber, accHolder);

            // Assert
            Assert.Equal(accNumber, account.AccountNumber);
            Assert.Equal(accHolder, account.AccountHolder);
            Assert.Equal(0m, account.Balance);
        }

        [Fact]
        public void UpdateBalanceWithPositiveNumber()
        {
            // Arrange
            var accNumber = Guid.NewGuid();
            var accHolder = "Test Holder";
            var amount = 400.00m;

            // Act
            var account = new Account(accNumber, accHolder);
            account.Deposit(amount);

            // Assert
            Assert.Equal(amount, account.Balance);
        }

        [Fact]
        public void UpdateBalanceWithNegativeNumber()
        {
            // Arrange
            var accNumber = Guid.NewGuid();
            var accHolder = "Test Holder";
            var initialAmount = 400.00m;
            var withdrawAmount = -200.00m;

            // Act
            var account = new Account(accNumber, accHolder);
            account.Deposit(initialAmount);
            account.Withdraw(withdrawAmount);

            // Assert
            Assert.Equal(200.00m, account.Balance);
        }
    }
}
