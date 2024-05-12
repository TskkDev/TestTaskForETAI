using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
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

        void OpenModal(GetCountGoodsResponse info)
        {
            CategoryId = info.Id;
            ParentCategoryId = info.ParentCategoryId;
            CategoryName = info.Name;

            modal.Open();
        }
        void CloseModal()
        {
            modal.Close();
        }
    }
}
