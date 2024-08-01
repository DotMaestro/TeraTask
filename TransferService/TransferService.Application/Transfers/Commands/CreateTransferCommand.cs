using AutoMapper;

using MassTransit;

using MediatR;

using Tera.TransferService.Messages;

using TransferService.Application.Dtos;
using TransferService.Domain.Entities;
using TransferService.Domain.Interfaces;

namespace TransferService.Application.Transfers.Commands
{
    public record CreateTransferCommand(CreateTransferDto Dto) : IRequest<int>;

    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand, int>
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IBus _broker;
        private readonly IMapper _mapper;

        public CreateTransferCommandHandler(ITransferRepository transferRepository, IBus broker, IMapper mapper)
        {
            _transferRepository = transferRepository;
            _broker = broker;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = _mapper.Map<Transfer>(request.Dto);

            _transferRepository.Create(transfer);

            await _broker.Publish<UpdateAccountBalance>(new 
            {
                CommandId = Guid.NewGuid(),
                AccountNumber = transfer.AccountNumber,
                Amount = transfer.Amount,
            });


            return transfer.TransferId;
        }
    }
}
