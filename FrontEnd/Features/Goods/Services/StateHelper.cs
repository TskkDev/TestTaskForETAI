using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.Services
{
    public class StateHelper
    {
        //не нужен оставил если по итогу правок понадоибится здесь что то 
        public List<GetCategoryNameResponse> AddGoodInGoodsList(
            IEnumerable<GetCategoryNameResponse> goods,GetCategoryNameResponse good)
        {
            if(goods.First().CategoryId != good.CategoryId)
            {
                return goods.ToList();
            }
            var newGoods = goods.ToList();
            newGoods.Add(good);
            return newGoods;
        }

        public List<GetCategoryNameResponse> UpdateGoodInGoodsList(
            IEnumerable<GetCategoryNameResponse> goods, GetCategoryNameResponse good)
        {
            var newGoods = goods.ToList();
            if(newGoods.First().CategoryId != good.CategoryId)
            {
                newGoods = DeleteGoodFromGoodsList(goods, good.Id);
                return newGoods;
            }
            else
            {
                newGoods = goods.Select(g =>
                {
                    if (g.Id == good.Id)
                    {
                        return good;
                    }
                    return g;
                }).ToList();
            }
            return newGoods;
        }

        public List<GetCategoryNameResponse> DeleteGoodFromGoodsList(
            IEnumerable<GetCategoryNameResponse> goods, int goodId) 
        {
            var deletedGood = goods.FirstOrDefault(x => x.Id == goodId);
            if (deletedGood == null) throw new NullReferenceException("Haven't goods with this Id");
            var newGoods = goods.ToList();
            newGoods.Remove(deletedGood);
            return newGoods;
        }
    }
}
