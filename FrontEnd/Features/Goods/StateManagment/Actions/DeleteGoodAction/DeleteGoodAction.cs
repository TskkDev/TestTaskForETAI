using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.StateManagment.Actions.DeleteGoodAction
{
    public class DeleteGoodAction
    {
        public int GoodId { get; }
        public IEnumerable<GetCategoryNameResponse> Goods { get; }
        public DeleteGoodAction(int goodId, IEnumerable<GetCategoryNameResponse> goods)
        {
            GoodId = goodId;
            Goods = goods;
        }
    }
}
