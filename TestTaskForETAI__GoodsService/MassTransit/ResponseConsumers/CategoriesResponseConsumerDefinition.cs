using GoodsService__WebApi.MassTransit.ModifyConsumers;
using MassTransit;
using SharedModels.Constants;

namespace GoodsService__WebApi.MassTransit.ResponseConsumers
{
    public class CategoriesResponseConsumerDefinition: ConsumerDefinition<CategoriesResponseConsumer>
    {
        public CategoriesResponseConsumerDefinition()
        {
            EndpointName = QueueConstants.NotificationQueueNameBetweenMicroservices;
        }
    }
}
