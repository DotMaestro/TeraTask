using AutoMapper;

using MediatR;

using TransferService.Application.Dtos;
using TransferService.Domain.Entities;
using TransferService.Domain.Interfaces;

namespace TransferService.Application.Transfers.Commands
{
    public record CreateTransferCommand(CreateTransferDto Dto) : IRequest<int>;

    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand, int>
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IMapper _mapper;

        public CreateTransferCommandHandler(ITransferRepository transferRepository, IMapper mapper)
        {
            _transferRepository = transferRepository;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = _mapper.Map<Transfer>(request.Dto);

            _transferRepository.Create(transfer);

            return Task.FromResult(transfer.TransferId);
        }
    }
}
