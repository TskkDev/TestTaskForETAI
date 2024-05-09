using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
using Microsoft.AspNetCore.Components;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.Component
{
    public partial class CategoryListComponent
    {
        [Parameter]
        public IEnumerable<GetCountGoodsResponse> categories { get; set; }
        private void ToggleCategory(GetCountGoodsResponse category)
        {

            Dispatcher.Dispatch(new TongleCategoryAction(CategoryState.Value.Categories, category.Id));
            StateHasChanged();
        }
    }
}
