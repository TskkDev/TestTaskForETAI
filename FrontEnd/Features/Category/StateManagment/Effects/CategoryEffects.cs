using Fluxor;
using FrontEnd.Features.Category.Interfaces;
using FrontEnd.Features.Category.Service;
using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.TopCategoryActions;
using static System.Net.WebRequestMethods;

namespace FrontEnd.Features.Category.StateManagment.Effects
{
    public class Effects
    {
        private readonly ICategoryService _categoryService;
        public Effects(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [EffectMethod]
        public async Task HandleTopCategoryAction(TopCategoriesAction action, IDispatcher dispatcher)
        {
            var categories = await _categoryService.GetAllTopicCategory();
            dispatcher.Dispatch(new TopCategoriesResultAction(categories));
        }

        [EffectMethod]
        public async Task HandleTongleCategoryAction(TongleCategoryAction action, IDispatcher dispatcher)
        {
            var categories = action.Categories;
            var newCategory = await _categoryService.GetCategoryById(action.SubCategoryId);
            newCategory.IsVisible = true;
            var newCategories = _categoryService.ChangeCategoryInListCategories(categories, action.SubCategoryId, newCategory);
            dispatcher.Dispatch(new TongleCategoryResultAction(newCategories));
        }

    }
}
