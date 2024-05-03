using CategoriesService__BLL.Interfaces;
using CategoriesService__BLL.Services;
using MassTransit;
using SharedModels.MessageModels;
using SharedModels.ResponseModels;

namespace CategoriesService__WebApi.MassTransit.ResponseComsumers;

public class GoodResponseConsumer : IConsumer<GoodResponseModel>
{
    private readonly ResponseConsumerLogicService _consumerHelper;
    public GoodResponseConsumer(ICategoryManager manager)
    {
        _consumerHelper = new ResponseConsumerLogicService(manager);
    }
    public async Task Consume(ConsumeContext<GoodResponseModel> context)
    {
        var response = context.Message;

        var category = _consumerHelper.GetGoodResponseModel(response);
        if (category == null) throw new MassTransitException("Invalid categoryId");

        var data = _consumerHelper.GoodResponseConsumerHelper(response);

        await context.RespondAsync(data);
    }
}
