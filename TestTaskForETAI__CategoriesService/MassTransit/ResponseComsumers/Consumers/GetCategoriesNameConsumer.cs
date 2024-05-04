using CategoriesService__BLL.Interfaces;
using CategoriesService__BLL.Services;
using MassTransit;
using SharedModels.MessageModels.NotifyModels;
using SharedModels.MessageModels.RespondModels.Request;
using SharedModels.MessageModels.RespondModels.Response;

namespace CategoriesService__WebApi.MassTransit.ResponseComsumers.Consumers;

public class GetCategoriesNameConsumer : IConsumer<ListGetCategoryNameRequest>
{
    private readonly ResponseConsumerLogicService _consumerHelper;
    public GetCategoriesNameConsumer(ICategoryManager manager)
    {
        _consumerHelper = new ResponseConsumerLogicService(manager);
    }
    public async Task Consume(ConsumeContext<ListGetCategoryNameRequest> context)
    {
        var data = _consumerHelper.GoodListConsumerHelper(context.Message.Goods);

        await context.RespondAsync<ListGetCategoryNameResponse>(data);
    }
}
