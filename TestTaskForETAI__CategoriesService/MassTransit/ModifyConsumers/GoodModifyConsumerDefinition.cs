using MassTransit;
using SharedModels.Constants;

namespace CategoriesService__WebApi.MassTransit.ModifyConsumers
{
    public class GoodModifyConsumerDefinition : ConsumerDefinition<GoodModifyConsumer>
    {
        public GoodModifyConsumerDefinition()
        {
            EndpointName = QueueConstants.NotificationQueueNameFromGoodsToCategories;
        }
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<GoodModifyConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(x => x.Intervals(100, 500, 1000));
        }
    }
}
