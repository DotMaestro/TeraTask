using AutoMapper;

using MassTransit;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Moq;

using TransferService.API.Controllers;
using TransferService.Application.Dtos;
using TransferService.Application.Transfers.Commands;
using TransferService.Domain.Entities;
using TransferService.Domain.Interfaces;

namespace TransferService.Tests.Unit.Controllers
{
    [Collection("TransferCollection")]
    public class TransferControllerShould
    {
        private readonly IServiceProvider _serviceProvider;

        public TransferControllerShould(ServiceProviderFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task CreateTransferByAccountNumber()
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
            
            var mediatorMock = new Mock<ISender>();
            mediatorMock.Setup(m => m.Send(It.IsAny<CreateTransferCommand>(), default)).ReturnsAsync(transferEntity.TransferId);

            var controller = new TransfersController(mediatorMock.Object);


            // Act
            var result = await controller.CreateTransferAsync(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }
    }
}
