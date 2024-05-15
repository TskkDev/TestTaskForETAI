using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
using FrontEnd.Features.Goods.StateManagment.Actions.LoadGoodsAction;
using FrontEnd.Shared.Components;
using Microsoft.AspNetCore.Components;
using SharedModels.Models.RespondModels.Response;
using System.Reflection;

namespace FrontEnd.Features.Category.Component
{
    public partial class CategoryListComponent
    {
        private int CategoryId;
        private int? ParentCategoryId;
        private string CategoryName;

        ModalComponent modal;
        [Parameter]
        public IEnumerable<GetCountGoodsResponse> Categories { get; set; }
        private void ToggleCategory(GetCountGoodsResponse category)
        {

            Dispatcher.Dispatch(new TongleCategoryAction(CategoryState.Value.Categories, category.Id));
            StateHasChanged();
        }
        private void LoadGoodsFromCategory (int categoryId)
        {
            Dispatcher.Dispatch(new LoadGoodsAction(categoryId));
            StateHasChanged();
        }
        private void OpenModal(GetCountGoodsResponse info)
        {
            CategoryId = info.Id;
            ParentCategoryId = info.ParentCategoryId;
            CategoryName = info.Name;

            modal.Open();
        }
        private void CloseModal()
        {
            modal.Close();
        }
    }
}
