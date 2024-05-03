using CategoriesService__BLL.Interfaces;
using CategoriesService__BLL.Services;
using MassTransit;
using SharedModels.MessageModels;

namespace CategoriesService__WebApi.MassTransit.ResponseComsumers;

public class GoodsResponseConsumer : IConsumer<GoodsListMessage>
{
    private readonly ResponseConsumerLogicService _consumerHelper;
    public GoodsResponseConsumer(ICategoryManager manager)
    {
        _consumerHelper = new ResponseConsumerLogicService(manager);
    }
    public async Task Consume(ConsumeContext<GoodsListMessage> context)
    {
        var response = context.Message.Goods;

        var data = _consumerHelper.GoodListConsumerHelper(response);

        await context.RespondAsync(new GoodsListMessage() { Goods = data });
    }
}
