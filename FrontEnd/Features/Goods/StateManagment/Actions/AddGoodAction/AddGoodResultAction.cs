using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.StateManagment.Actions.AddGoodAction
{
    public class AddGoodResultAction
    {
        public IEnumerable<GetCategoryNameResponse> Goods { get; }
        public AddGoodResultAction(IEnumerable<GetCategoryNameResponse> goods)
        {
            Goods = goods;
        }
    }
}
