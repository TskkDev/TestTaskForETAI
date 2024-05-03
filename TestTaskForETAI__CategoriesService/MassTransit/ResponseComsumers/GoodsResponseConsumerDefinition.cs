using MassTransit;
using SharedModels.Constants;

namespace CategoriesService__WebApi.MassTransit.ResponseComsumers;

public class GoodsResponseConsumerDefinition : ConsumerDefinition<GoodsResponseConsumer>
{
    public GoodsResponseConsumerDefinition()
    {
        EndpointName = QueueConstants.ListMessageResponseQueue;
    }
}
