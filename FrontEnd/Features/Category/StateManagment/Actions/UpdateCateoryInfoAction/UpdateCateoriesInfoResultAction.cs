using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.StateManagment.Actions.UpdateCateoryInfoAction
{
    public class UpdateCateoriesInfoResultAction
    {
        public IEnumerable<GetCountGoodsResponse> Categories { get; }
        public UpdateCateoriesInfoResultAction(IEnumerable<GetCountGoodsResponse> categories)
        {
            Categories = categories;
        }
    }
}
