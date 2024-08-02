using AutoMapper;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;

using Moq;

using TransferService.Application.Dtos;
using TransferService.Application.Transfers.Commands;
using TransferService.Domain.Entities;
using TransferService.Domain.Interfaces;

namespace TransferService.Tests.Unit.Commands
{
    [Collection("TransferCollection")]
    public class TransferCommandShould
    {
        private readonly IServiceProvider _serviceProvider;

        public TransferCommandShould(ServiceProviderFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task CreateTransfer()
        {
            // Arrange
            var accNumber = Guid.NewGuid();
            var amount = 400.00m;
            var transferEntity = new Transfer();
            transferEntity.AccountNumber = accNumber;
            transferEntity.Amount = amount;
            transferEntity.TransferId = 1;

            var transferRepoMock = new Mock<ITransferRepository>();

            var transferDto = new CreateTransferDto(accNumber, amount);

            var command = new CreateTransferCommand(transferDto);
            var commandHandler = new CreateTransferCommandHandler(transferRepoMock.Object, _serviceProvider.GetRequiredService<IBus>(), _serviceProvider.GetRequiredService<IMapper>());

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(transferEntity.TransferId, result);
        }
    }
}
