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

        private ModalComponent categoryModal;

        private ModalComponent goodModal;
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
        private void OpenCategoryModal(GetCountGoodsResponse info)
        {
            CategoryId = info.Id;
            ParentCategoryId = info.ParentCategoryId;
            CategoryName = info.Name;

            categoryModal.Open();
        }
        private void CloseCategoryModal()
        {
            categoryModal.Close();
        }

        private void OpenGoodModal(int categoryId)
        {
            CategoryId = categoryId;
            goodModal.Open();
        }
        private void CloseGoodModal()
        {
            goodModal.Close(CategoryId);
        }
    }
}
