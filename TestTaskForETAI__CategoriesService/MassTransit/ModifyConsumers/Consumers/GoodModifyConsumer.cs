using MassTransit;
using SharedModels.Enums;
using SharedModels.MessageModels.NotifyModels;

namespace CategoriesService__WebApi.MassTransit.ModifyConsumers.Consumers
{
    public class GoodModifyConsumer : IConsumer<GoodMessage>
    {
        public Task Consume(ConsumeContext<GoodMessage> context)
        {
            //Вообще можно здесь реализовать логирование базовое
            var message = context.Message;
            if (message.OperationType == GoodOperationTypes.Add)
            {
                Console.WriteLine($"[GoodsMicroservice] Add good with Id {message.Good.Id}");
            }
            if (message.OperationType == GoodOperationTypes.Update)
            {
                Console.WriteLine($"[GoodsMicroservice] Update good with Id {message.Good.Id}");
            }
            if (message.OperationType == GoodOperationTypes.Delete)
            {
                Console.WriteLine($"[GoodsMicroservice] Delete good with Id {message.Good.Id}");
            }
            return Task.CompletedTask;
        }
    }
}