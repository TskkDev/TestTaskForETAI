using MassTransit;
using SharedModels.Constants;

namespace CategoriesService__WebApi.MassTransit
{
    public class GoodsModifyConsumerDefinition: ConsumerDefinition<GoodsModifyConsumer>
    {
        public GoodsModifyConsumerDefinition()
        {
            EndpointName = QueueConstants.NotificationQueueNameBetweenLogicalMicroservices;
        }
    }
}
