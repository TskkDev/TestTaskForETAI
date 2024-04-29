using TestTaskForETAI__GoodsService.Data_Access_Layer.Enities;

namespace TestTaskForETAI__GoodsService.Data_Access_Layer.Interfaces;

public interface IGoodsRepository
{
    Good Add(Good good);
    Good Update(Good good, Good newGood);
    void Delete(int goodId);
    Good? GetById(int id);
    IEnumerable<Good> GetAllGoodsFromCategory(int categoryId);
    IEnumerable<Good> SortGoods(int categoryId, string fieldName, bool ascending );
}