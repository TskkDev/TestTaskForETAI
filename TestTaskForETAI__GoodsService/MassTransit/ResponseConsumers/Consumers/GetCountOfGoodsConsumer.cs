using GoodsService__BLL.Interface;
using GoodsService__BLL.Services;
using MassTransit;
using SharedModels.MessageModels.RespondModels.Request;
using SharedModels.MessageModels.RespondModels.Response;

namespace GoodsService__WebApi.MassTransit.ResponseConsumers.Consumers;

public class GetCountOfGoodsConsumer : IConsumer<GetCountGoodsRequest>
{
    private readonly ResponseConsumerLogicService _consumerHelper;
    public GetCountOfGoodsConsumer(IGoodManager manager)
    {
        _consumerHelper = new ResponseConsumerLogicService(manager);
    }
    public async Task Consume(ConsumeContext<GetCountGoodsRequest> context)
    {
        var data = _consumerHelper.CategoryResponseConsumerHelper(context.Message);

        await context.RespondAsync<GetCountGoodsResponse>(data);
    }
}
