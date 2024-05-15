using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.StateManagment.Actions.UpdateCateoryInfoAction
{
    public class UpdateCateoriesInfoAction
    {
        public int FirstCategoryId { get; }
        public int? SecondCategoryId { get; }
        public IEnumerable<GetCountGoodsResponse> Categories { get; }
        public UpdateCateoriesInfoAction(int firstCategoryId, int? secondCategoryId, IEnumerable<GetCountGoodsResponse> categories)
        {
            FirstCategoryId = firstCategoryId;
            SecondCategoryId = secondCategoryId;
            Categories = categories;
        }
    }
}
