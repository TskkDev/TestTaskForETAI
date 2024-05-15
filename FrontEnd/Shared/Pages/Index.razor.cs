using FrontEnd.Features.Category.Component;
using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.TopCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.UpdateCateoryInfoAction;
using FrontEnd.Features.Goods.Component;
using FrontEnd.Features.Goods.StateManagment.States;
using FrontEnd.Shared.Components;

namespace FrontEnd.Shared.Pages
{
    public partial class Index
    {
        ModalComponent modal;
        GoodsTableComponent goodsTable;

        void OpenModal()
        {
            modal.Open();
        }
        void CloseModal()
        {
            modal.Close();
        }
        private void HandleCategorySelected(int selectedCategory)
        {
            int firstSelectedCategory = GoodState.Value.Goods.First().CategoryId;
            int? secondSelectedCategory = null;
            if(selectedCategory != firstSelectedCategory)
            {
                secondSelectedCategory = selectedCategory;
            }

            Dispatcher.Dispatch(new UpdateCateoriesInfoAction(
                    firstSelectedCategory, secondSelectedCategory,
                    CategoryState.Value.Categories));
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new TopCategoriesAction());
        }
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            goodsTable.CategorySelected += HandleCategorySelected;
        }
    }
}
