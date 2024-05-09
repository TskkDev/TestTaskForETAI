using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.Actions
{
    public class CategoriesDataAction
    {
        public IEnumerable<GetCountGoodsResponse> Categories { get; }

        public CategoriesDataAction(IEnumerable<GetCountGoodsResponse> categories)
        {
            Categories = categories;
        }
    }
}
