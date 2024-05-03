using MassTransit;
using SharedModels.Constants;

namespace GoodsService__WebApi.MassTransit.ModifyConsumers;

public class CategoriesModifyConsumerDefinition : ConsumerDefinition<CategoriesModifyConsumer>
{
    public CategoriesModifyConsumerDefinition()
    {
        EndpointName = QueueConstants.NotificationQueueNameBetweenLogicalMicroservices;
    }
}
