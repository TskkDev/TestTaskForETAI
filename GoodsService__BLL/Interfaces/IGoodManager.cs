﻿using SharedModels.RequestModels;
using SharedModels.ResponseModels;

namespace GoodsService__BLL.Interfaces
{
    public interface IGoodManager
    {
        public GoodResponseModel AddGood(GoodRequestModel newGood);
        public GoodResponseModel UpdateGood(int goodId, GoodRequestModel newGood);
        public void DeleteGood(int goodId);
        public List<GoodResponseModel> GetAllGoodsFromCategory(int categoryId);
        public List<GoodResponseModel> SortGoods(int categoryId, string fieldName, bool ascending);
    }
}
