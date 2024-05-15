using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.StateManagment.Actions.AddGoodAction
{
    public class AddGoodAction
    {
        public GoodRequestModel Good { get; }
        public IEnumerable<GetCategoryNameResponse> Goods { get; }
        public AddGoodAction(GoodRequestModel good, IEnumerable<GetCategoryNameResponse> goods)
        {
            Good = good;
            Goods = goods;
        }
    }
}
