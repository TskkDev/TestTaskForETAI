using FrontEnd.Features.Category.Models;
using FrontEnd.Features.Category.StateManagment.Actions.AddCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
using Microsoft.AspNetCore.Components;
using SharedModels.Models.RequestModels;

namespace FrontEnd.Features.Category.Component
{
    public partial class CategoriesModalComponent
    {
        [Parameter]
        public int? UpdateId { get; set; }

        [Parameter]
        public Action ToggleModal { get; set; }
        [Parameter]
        public string CategoryName { get; set; }
        [Parameter]
        public int? ParentCategoryId { get; set; }

        private void Send()
        {
            if (ParentCategoryId == 0) ParentCategoryId = null;
            if(UpdateId == null)
            {
                var newCategory = new CategoryRequestModel()
                {
                    Name = CategoryName,
                    ParentCategoryId = ParentCategoryId,
                };
                Dispatcher.Dispatch(new AddCategoryAction(CategoryState.Value.Categories, newCategory));
            }
            else
            {
                var updatedCategpry = new CategoryUpdateModel()
                {
                    CategoryId = UpdateId ?? throw new Exception("no way exception"),
                    NewCategory = new CategoryRequestModel()
                    {
                        Name = CategoryName,
                        ParentCategoryId = ParentCategoryId,
                    }

                };
                //Complite
            }
            CategoryName = "";
            ParentCategoryId = null;
            ToggleModal();
        }
    }
}
