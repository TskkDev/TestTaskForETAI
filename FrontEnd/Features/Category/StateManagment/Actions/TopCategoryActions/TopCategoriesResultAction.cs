using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.StateManagment.Actions.TopCategoryActions
{
    public class TopCategoriesResultAction
    {
        public IEnumerable<GetCountGoodsResponse> Categories { get; }

        public TopCategoriesResultAction(IEnumerable<GetCountGoodsResponse> categories)
        {
            Categories = categories;
        }
    }
}
