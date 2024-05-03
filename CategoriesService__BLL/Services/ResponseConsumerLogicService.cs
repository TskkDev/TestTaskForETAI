using CategoriesService__BLL.Interfaces;
using SharedModels.ResponseModels;

namespace CategoriesService__BLL.Services
{
    public class ResponseConsumerLogicService
    {
        private readonly ICategoryManager _manager;
        public ResponseConsumerLogicService(ICategoryManager manager)
        {
            _manager = manager;
        }
        public CategoryResponseModel? GetGoodResponseModel(GoodResponseModel goodResponseModel) 
        {
            return _manager.GetCategoryById(goodResponseModel.Id);
        }
        public GoodResponseModel GoodResponseConsumerHelper(GoodResponseModel goodResponseModel)
        {
            goodResponseModel.CategoryName = _manager.GetCategoryNameById(goodResponseModel.CategoryId);
            return goodResponseModel;
        }
        public List<GoodResponseModel> GoodListConsumerHelper(List<GoodResponseModel> goodsResponseModel)
        {
            return goodsResponseModel.Select(g => GoodResponseConsumerHelper(g)).ToList();
        }
    }
}
