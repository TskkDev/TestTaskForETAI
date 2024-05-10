using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.StateManagment.Actions.AddCategoryActions
{
    public class AddCategoryResultAction
    {
        public IEnumerable<GetCountGoodsResponse> Categories { get; }

        public AddCategoryResultAction(IEnumerable<GetCountGoodsResponse> categories)
        {
            Categories = categories;
        }
    }
}
