using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.StateManagment.Actions.DeleteGoodAction
{
    public class DeleteGoodResultAction
    {
        public IEnumerable<GetCategoryNameResponse> Goods { get; }
        public DeleteGoodResultAction(IEnumerable<GetCategoryNameResponse> goods)
        {
            Goods = goods;
        }
    }
}
