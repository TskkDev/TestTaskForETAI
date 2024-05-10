using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.StateManagment.Actions.AddCategoryActions
{
    public class AddCategoryAction
    {
        public IEnumerable<GetCountGoodsResponse> Categories { get; }
        public CategoryRequestModel Category { get; }

        public AddCategoryAction(IEnumerable<GetCountGoodsResponse> categories, CategoryRequestModel category)
        {
            Category = category;
            Categories = categories;
        }
    }
   
}
