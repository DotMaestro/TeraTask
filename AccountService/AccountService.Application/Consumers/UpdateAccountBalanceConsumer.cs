using AccountService.Application.Accounts.Commands;
using AccountService.Application.Dtos;

using MassTransit;

using MediatR;

using Tera.TransferService.Messages;

namespace AccountService.Application.Consumers
{
    public class UpdateAccountBalanceConsumer : IConsumer<UpdateAccountBalance>
    {
        private readonly ISender _mediator;

        public UpdateAccountBalanceConsumer(ISender mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<UpdateAccountBalance> context)
        {
            var dto = new UpdateBalanceDto(context.Message.AccountNumber, context.Message.Amount);

            await _mediator.Send(new UpdateAccountBalanceCommand(dto));
        }
    }
}
