using GoodsService__DAL.Enities;
using GoodsService__DAL.Interfaces;
using LinqToDB;

namespace GoodsService__DAL.Repositories;

public class GoodsRepostiry : IGoodsRepository
{
    private readonly DbConection _db;

    public GoodsRepostiry(DbConection db)
    {
        _db = db;
    }

    public Good Add(Good good)
    {
        var newId = _db.InsertWithInt32Identity(good);
        good.Id = newId;
        return good;
    }

    public Good Update(Good good, Good newGood)
    {
        good.Name = newGood.Name;
        good.Dics = newGood.Dics;
        good.Price = newGood.Price;
        good.CategoryId = newGood.CategoryId;
        _db.Update(good);
        return good;
    }

    public void Delete(int goodId)
    {
        _db.Goods.Delete(g => g.Id == goodId);
    }

    public Good? GetById(int id)
    {
        return _db.Goods.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Good> GetAllGoodsFromCategory(int categoryId)
    {
        return _db.Goods.Where(c => c.CategoryId == categoryId);
    }

    public IEnumerable<Good> SortGoods(IEnumerable<Good> goodFromCategory, string fieldName, bool ascending)
    {
        var propertyInfo = typeof(Good).GetProperty(fieldName);
        if (ascending)
        {
            return goodFromCategory.OrderBy(g => propertyInfo.GetValue(g, null));
        }
        return goodFromCategory.OrderByDescending(g => propertyInfo.GetValue(g, null));
    }
}