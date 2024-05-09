using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions
{
    public class TongleCategoryAction
    {
        public IEnumerable<GetCountGoodsResponse> Categories { get; }
        public int SubCategoryId { get; set; }

        public TongleCategoryAction(IEnumerable<GetCountGoodsResponse> categories, int subCategoryId)
        {
            Categories = categories;
            SubCategoryId = subCategoryId;
        }
    }
}
