using GoodsService__BLL.Interfaces;
using GoodsService__BLL.Services;
using GoodsService__DAL.Enities;
using GoodsService__DAL.Repositories;
using SharedModels.RequestModels;
using SharedModels.ResponseModels;


namespace GoodsService__BLL.Managers
{
    public class GoodManager : IGoodManager
    {
        private readonly string _connectionString;
        private readonly ConvertModelToEntityService _converter;
        public GoodManager(string connectionString)
        {
            _connectionString = connectionString;
            _converter = new ConvertModelToEntityService();
        }

        public GoodResponseModel AddGood(GoodRequestModel newGood)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new GoodsRepostiry(db);
                return(_converter.EntityToResponseModel(
                    repos.Add(_converter.RequestModelToEntity(newGood))));
            }
        }

        public GoodResponseModel UpdateGood(int goodId, GoodRequestModel newGood)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new GoodsRepostiry(db);
                var oldGood = repos.GetById(goodId);
                if (oldGood is null) throw new NullReferenceException("Old good doesn't found");
                return(_converter.EntityToResponseModel(
                    repos.Update(oldGood, _converter.RequestModelToEntity(newGood))
                    ));
            }
        }

        public void DeleteGood(int goodId)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new GoodsRepostiry(db);
                var deletedGood = repos.GetById(goodId);
                if (deletedGood is null) throw new NullReferenceException("Doesn't found good for delete");
                repos.Delete(goodId);
                return;
            }
        }

        public List<GoodResponseModel> GetAllGoodsFromCategory(int categoryId)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new GoodsRepostiry(db);
                var goods = repos.GetAllGoodsFromCategory(categoryId).ToList();
                if (goods.Count() == 0) throw new NullReferenceException("Doesn't have good on this category");
                return _converter.EntitiesToResponseModels(goods);
            }
        }

        public List<GoodResponseModel> SortGoods(int categoryId,
            string fieldName, bool ascending)
        {
            using (var db = new DbConection(_connectionString))
            {
                List<Good> goodsWithSort;
                var repos = new GoodsRepostiry(db);
                var goods = repos.GetAllGoodsFromCategory(categoryId);
                if (goods.Count() == 0) throw new NullReferenceException("Doesn't have good on this category");
                try
                {
                    goodsWithSort = repos.SortGoods(goods, fieldName, ascending).ToList();
                }
                catch (Exception ex) 
                {
                    throw new InvalidDataException("FieldName is invalid");
                }
                return _converter.EntitiesToResponseModels(goodsWithSort);
            }
        }
    }
}
