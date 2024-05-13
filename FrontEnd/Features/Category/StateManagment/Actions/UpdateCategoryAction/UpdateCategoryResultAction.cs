using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.StateManagment.Actions.UpdateCategoryAction
{
    public class UpdateCategoryResultAction
    {
        public IEnumerable<GetCountGoodsResponse> Categories { get; }

        public UpdateCategoryResultAction(IEnumerable<GetCountGoodsResponse> categories)
        {
            Categories = categories;
        }
    }
}
