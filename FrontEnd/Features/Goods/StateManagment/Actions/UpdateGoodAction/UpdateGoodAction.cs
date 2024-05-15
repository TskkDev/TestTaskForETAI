using FrontEnd.Features.Goods.Models;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.StateManagment.Actions.UpdateGoodAction
{
    public class UpdateGoodAction
    {
        public UpdateGoodModel NewGood { get; }
        public IEnumerable<GetCategoryNameResponse> Goods { get; }
        public UpdateGoodAction(UpdateGoodModel good, IEnumerable<GetCategoryNameResponse> goods)
        {
            NewGood = good;
            Goods = goods;
        }
    }
}
