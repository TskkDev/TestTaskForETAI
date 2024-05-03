using GoodsService__WebApi.MassTransit.ModifyConsumers;
using MassTransit;
using SharedModels.Constants;

namespace GoodsService__WebApi.MassTransit.ResponseConsumers
{
    public class CategoryResponseConsumerDefinition : ConsumerDefinition<CategoryResponseConsumer>
    {
        public CategoryResponseConsumerDefinition()
        {
            EndpointName = QueueConstants.MessageResponseQueue;
        }
    }
}
