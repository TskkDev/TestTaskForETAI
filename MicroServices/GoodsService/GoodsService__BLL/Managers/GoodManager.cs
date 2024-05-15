using GoodsService__BLL.Interface;
using GoodsService__BLL.Services;
using GoodsService__DAL.Enities;
using GoodsService__DAL.Repositories;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Request;

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

        public GetCategoryNameRequest AddGood(GoodRequestModel newGood)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new GoodsRepostiry(db);
                return(_converter.EntityToGetCategoryNameResponse(
                    repos.Add(_converter.RequestModelToEntity(newGood))));
            }
        }

        public GetCategoryNameRequest UpdateGood(int goodId, GoodRequestModel newGood)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new GoodsRepostiry(db);
                var oldGood = repos.GetById(goodId);
                if (oldGood is null) throw new NullReferenceException("Old good doesn't found");
                return(_converter.EntityToGetCategoryNameResponse(
                    repos.Update(oldGood, _converter.RequestModelToEntity(newGood))));
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

        public int BackCountGoodsInCategory(int categoryId)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new GoodsRepostiry(db);
                return repos.GetAllGoodsFromCategory(categoryId).ToList().Count();
            }
        }

        public ListGetCategoryNameRequest GetAllGoodsFromCategory(int categoryId)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new GoodsRepostiry(db);
                var goods = repos.GetAllGoodsFromCategory(categoryId).ToList();
                if (goods.Count() == 0) throw new NullReferenceException("Doesn't have good on this category");
                return _converter.EntitiesToListGetCategoryNameRequest(goods);
            }
        }

        public ListGetCategoryNameRequest SortGoods(int categoryId,
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
                return _converter.EntitiesToListGetCategoryNameRequest(goodsWithSort);
            }
        }
    }
}
