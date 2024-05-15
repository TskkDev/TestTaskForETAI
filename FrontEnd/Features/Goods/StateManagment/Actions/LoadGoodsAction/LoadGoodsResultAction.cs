using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.StateManagment.Actions.LoadGoodsAction
{
    public class LoadGoodsResultAction
    {
        public IEnumerable<GetCategoryNameResponse> Goods { get; }
        public LoadGoodsResultAction(IEnumerable<GetCategoryNameResponse> goods)
        {
            Goods = goods;
        }
    }
}
