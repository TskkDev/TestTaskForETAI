using GoodsService__BLL.Models;
using SharedModels.Models.RespondModels.Request;

namespace GoodsService__BLL.Interface
{
    public interface IGoodManager
    {
        public GetCategoryNameRequest AddGood(GoodRequestModel newGood);
        public GetCategoryNameRequest UpdateGood(int goodId, GoodRequestModel newGood);
        public void DeleteGood(int goodId);
        public int BackCountGoodsInCategory(int categoryId);
        public ListGetCategoryNameRequest GetAllGoodsFromCategory(int categoryId);
        public ListGetCategoryNameRequest SortGoods(int categoryId, string fieldName, bool ascending);
    }
}