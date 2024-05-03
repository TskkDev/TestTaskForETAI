using GoodsService__BLL.Interface;
using GoodsService__BLL.Managers;
using GoodsService__BLL.Services;
using MassTransit;
using SharedModels.MessageModels;
using SharedModels.ResponseModels;

namespace GoodsService__WebApi.MassTransit.ResponseConsumers
{
    public class CategoriesResponseConsumer : IConsumer<CategoryListMessage>
    {
        private readonly ResponseConsumerLogicService _consumerHelper;
        public CategoriesResponseConsumer(IGoodManager manager)
        {
            _consumerHelper = new ResponseConsumerLogicService(manager);
        }
        public async Task Consume(ConsumeContext<CategoryListMessage> context)
        {
            var response = context.Message.Categories;

            var data = _consumerHelper.CategorListConsumerHelper(response);

            await context.RespondAsync(new CategoryListMessage() {Categories = data });
        }
    }
}
