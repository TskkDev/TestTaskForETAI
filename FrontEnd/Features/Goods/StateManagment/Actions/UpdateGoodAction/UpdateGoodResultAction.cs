using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.StateManagment.Actions.UpdateGoodAction
{
    public class UpdateGoodResultAction
    {
        public IEnumerable<GetCategoryNameResponse> Goods { get; }
        public UpdateGoodResultAction(IEnumerable<GetCategoryNameResponse> goods)
        {
            Goods = goods;
        }
    }
}
