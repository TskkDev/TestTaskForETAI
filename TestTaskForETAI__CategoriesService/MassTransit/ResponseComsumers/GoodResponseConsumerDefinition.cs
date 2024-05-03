using MassTransit;
using SharedModels.Constants;

namespace CategoriesService__WebApi.MassTransit.ResponseComsumers;

public class GoodResponseConsumerDefinition : ConsumerDefinition<GoodResponseConsumer>
{
    public GoodResponseConsumerDefinition()
    {
        EndpointName = QueueConstants.MessageResponseQueue;
    }
}
