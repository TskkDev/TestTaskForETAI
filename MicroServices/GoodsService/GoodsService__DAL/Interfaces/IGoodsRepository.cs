using GoodsService__DAL.Enities;

namespace GoodsService__DAL.Interfaces;

public interface IGoodsRepository
{
    Good Add(Good good);
    Good Update(Good good, Good newGood);
    void Delete(int goodId);
    Good? GetById(int id);
    IEnumerable<Good> GetAllGoodsFromCategory(int categoryId);
    IEnumerable<Good> SortGoods(IEnumerable<Good> goodFromCategory, string fieldName, bool ascending);
}