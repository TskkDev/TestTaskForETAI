using CategoriesService__BLL.Interfaces;
using CategoriesService__BLL.Services;
using MassTransit;
using SharedModels.Models.RespondModels.Request;
using SharedModels.Models.RespondModels.Response;

namespace CategoriesService__WebApi.MassTransit.ResponseComsumers.Consumers;

public class GetCategoryNameConsumer : IConsumer<GetCategoryNameRequest>
{
    private readonly ResponseConsumerLogicService _consumerHelper;
    public GetCategoryNameConsumer(ICategoryManager manager)
    {
        _consumerHelper = new ResponseConsumerLogicService(manager);
    }
    public async Task Consume(ConsumeContext<GetCategoryNameRequest> context)
    {
        GetCategoryNameResponse data;
        try
        {
            data = _consumerHelper.GoodResponseConsumerHelper(context.Message);

        }
        catch(NullReferenceException ex)
        {
            throw new MassTransitException("Invalid categoryId");
        }
        

        await context.RespondAsync<GetCategoryNameResponse>(data);
    }
}
