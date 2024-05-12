using GoodsService__BLL.Interface;
using SharedModels.Models.RespondModels.Request;
using SharedModels.Models.RespondModels.Response;

namespace GoodsService__BLL.Services
{
    public class ResponseConsumerLogicService
    {
        private readonly IGoodManager _manager;
        public ResponseConsumerLogicService(IGoodManager manager)
        {
            _manager = manager;
        }
        public GetCountGoodsResponse CategoryResponseConsumerHelper(GetCountGoodsRequest countGoodsRequest)
        {
            var countGoodsResponse = new GetCountGoodsResponse()
            {
                Id = countGoodsRequest.Id,
                Name = countGoodsRequest.Name,
                ParentCategoryId = countGoodsRequest.ParentCategoryId,
                CountGoods = _manager.BackCountGoodsInCategory(countGoodsRequest.Id),
                SubCategories = countGoodsRequest.SubCategories.Select(sc => new GetCountGoodsResponse()
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    ParentCategoryId = sc.ParentCategoryId,
                    CountGoods = _manager.BackCountGoodsInCategory(sc.Id),
                }).ToList()
            };
            return countGoodsResponse;
        }
        public ListGetCountGoodsResponse CategoriesListConsumerHelper(List<GetCountGoodsRequest> countsGoodsRequest)
        {
            return new ListGetCountGoodsResponse() 
            {
                Categories = countsGoodsRequest.Select(sc => CategoryResponseConsumerHelper(sc)).ToList()
            };
        }
    }
}
