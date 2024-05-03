using MassTransit;
using SharedModels.Constants;

namespace GoodsService__WebApi.MassTransit.ModifyConsumers;

public class CategoryModifyConsumerDefinition : ConsumerDefinition<CategoryModifyConsumer>
{
    public CategoryModifyConsumerDefinition()
    {
        EndpointName = QueueConstants.NotificationQueueNameFromCategoriesToGoods;
    }
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<CategoryModifyConsumer> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(x=>x.Intervals(100, 500, 1000));
    }
}
