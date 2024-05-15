using FrontEnd.Features.Goods.Models;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.Interfaces
{
    public interface IGoodService
    {
        public Task<List<GetCategoryNameResponse>> GetGoodsFromCategory(int id);
        public Task<List<GetCategoryNameResponse>> GetGoodsFromCategoryWithSort(
            int id, string fieldName, bool ascending);
        public Task<GetCategoryNameResponse> AddGood(GoodRequestModel goodRequest);
        public Task<GetCategoryNameResponse> UpdateGood(UpdateGoodModel updateGood);
        public Task DeleteGood(int goodId);
    }
}
