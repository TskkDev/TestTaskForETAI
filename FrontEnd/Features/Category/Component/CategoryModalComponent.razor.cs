using FrontEnd.Features.Category.StateManagment.Actions.AddCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
using Microsoft.AspNetCore.Components;
using SharedModels.Models.RequestModels;

namespace FrontEnd.Features.Category.Component
{
    public partial class CategoryModalComponent
    {
        [Parameter]
        public int? UpdateId { get; set; }

        [Parameter]
        public Action ToggleModal { get; set; }

        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }

        private void Submit()
        {
            if (ParentCategoryId == 0) ParentCategoryId = null;
            var newCategory = new CategoryRequestModel()
            {
                Name = CategoryName,
                ParentCategoryId = ParentCategoryId,
            };
            Dispatcher.Dispatch(new AddCategoryAction(CategoryState.Value.Categories, newCategory));
            ToggleModal();
        }
    }
}
