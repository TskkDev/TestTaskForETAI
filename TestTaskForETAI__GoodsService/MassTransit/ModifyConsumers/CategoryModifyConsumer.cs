using MassTransit;
using SharedModels.Enums;
using SharedModels.MessageModels;

namespace GoodsService__WebApi.MassTransit.ModifyConsumers;

public class CategoryModifyConsumer : IConsumer<CategoryMessage>
{
    public Task Consume(ConsumeContext<CategoryMessage> context)
    {
        //Вообще можно здесь реализовать логирование базовое
        var message = context.Message;
        if (message.OperationType == CategoryOperationTypes.Add)
        {
            Console.WriteLine($"[CategoriesMicroservice] Add category with Id {message.Category.Id}");
        }
        if (message.OperationType == CategoryOperationTypes.Update)
        {
            Console.WriteLine($"[CategoriesMicroservice] Update category with Id {message.Category.Id}");
        }
        return Task.CompletedTask;
    }
}
