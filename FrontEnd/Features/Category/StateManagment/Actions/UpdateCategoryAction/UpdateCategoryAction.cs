using FrontEnd.Features.Category.Models;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.StateManagment.Actions.UpdateCategoryAction
{
    public class UpdateCategoryAction
    {
        public IEnumerable<GetCountGoodsResponse> Categories { get; }
        public CategoryUpdateModel Category { get; }

        public UpdateCategoryAction(IEnumerable<GetCountGoodsResponse> categories, CategoryUpdateModel category)
        {
            Category = category;
            Categories = categories;
        }
    }
}
