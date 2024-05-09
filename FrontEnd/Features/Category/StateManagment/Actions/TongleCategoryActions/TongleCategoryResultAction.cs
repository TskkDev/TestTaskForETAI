using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions
{
    public class TongleCategoryResultAction
    {
        public IEnumerable<GetCountGoodsResponse> Categories { get; }

        public TongleCategoryResultAction(IEnumerable<GetCountGoodsResponse> categories)
        {
            Categories = categories;
        }
    }
}
