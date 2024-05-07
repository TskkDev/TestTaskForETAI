using GoodsService__BLL.Interface;
using GoodsService__BLL.Services;
using MassTransit;
using SharedModels.Models.RespondModels.Request;
using SharedModels.Models.RespondModels.Response;

namespace GoodsService__WebApi.MassTransit.ResponseConsumers.Consumers;

public class GetCountsOfGoodsConsumer : IConsumer<ListGetCountGoodsRequest>
{
    private readonly ResponseConsumerLogicService _consumerHelper;
    public GetCountsOfGoodsConsumer(IGoodManager manager)
    {
        _consumerHelper = new ResponseConsumerLogicService(manager);
    }
    public async Task Consume(ConsumeContext<ListGetCountGoodsRequest> context)
    {

        var data = _consumerHelper.CategoriesListConsumerHelper(context.Message.Categories);

        await context.RespondAsync<ListGetCountGoodsResponse>(data);
    }
}
