using CategoriesService__BLL.Interfaces;
using SharedModels.MessageModels.RespondModels.Request;
using SharedModels.MessageModels.RespondModels.Response;

namespace CategoriesService__BLL.Services
{
    public class ResponseConsumerLogicService
    {
        private readonly ICategoryManager _manager;
        public ResponseConsumerLogicService(ICategoryManager manager)
        {
            _manager = manager;
        }
        public GetCategoryNameResponse GoodResponseConsumerHelper(GetCategoryNameRequest categoryNameRequest)
        {
            var categoryNameResponse = new GetCategoryNameResponse()
            {
                Id = categoryNameRequest.Id,
                Name = categoryNameRequest.Name,
                Dics = categoryNameRequest.Dics,
                Price = categoryNameRequest.Price,
                CategoryId = categoryNameRequest.CategoryId,
                CategoryName = _manager.GetCategoryNameById(categoryNameRequest.CategoryId)
            };
            return categoryNameResponse;
        }
        public ListGetCategoryNameResponse GoodListConsumerHelper(List<GetCategoryNameRequest> categoriesNameRequests)
        {
            return new ListGetCategoryNameResponse()
            {
                Goods = categoriesNameRequests.Select(cn => GoodResponseConsumerHelper(cn)).ToList()
            };       
        }
    }
}
