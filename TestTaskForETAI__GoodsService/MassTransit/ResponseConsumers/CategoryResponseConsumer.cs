using GoodsService__BLL.Interface;
using GoodsService__BLL.Services;
using MassTransit;
using SharedModels.ResponseModels;

namespace GoodsService__WebApi.MassTransit.ResponseConsumers
{
    public class CategoryResponseConsumer : IConsumer<CategoryResponseModel>
    {
        private readonly ResponseConsumerLogicService _consumerHelper;
        public CategoryResponseConsumer(IGoodManager manager)
        {
            _consumerHelper = new ResponseConsumerLogicService(manager);
        }
        public async Task Consume(ConsumeContext<CategoryResponseModel> context)
        {
            var response = context.Message;

            var data = _consumerHelper.CategoryResponseConsumerHelper(response);

            await context.RespondAsync(data);
        }
    }
}
