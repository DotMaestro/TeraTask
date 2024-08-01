using MassTransit;

namespace AccountService.Application.Consumers
{
    public class UpdateAccountBalanceConsumerDefinition : ConsumerDefinition<UpdateAccountBalanceConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<UpdateAccountBalanceConsumer> consumerConfigurator, IRegistrationContext context)
        {
            base.ConfigureConsumer(endpointConfigurator, consumerConfigurator, context);
        }
    }
}
