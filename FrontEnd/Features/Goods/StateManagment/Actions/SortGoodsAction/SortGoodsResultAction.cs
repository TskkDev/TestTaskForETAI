using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.StateManagment.Actions.SortGoodsAction
{
    public class SortGoodsResultAction
    {
        public IEnumerable<GetCategoryNameResponse> Goods { get; }
        public SortGoodsResultAction(IEnumerable<GetCategoryNameResponse> goods)
        {
            Goods = goods;
        }
    }
}
