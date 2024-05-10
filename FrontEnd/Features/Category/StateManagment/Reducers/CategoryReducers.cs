using Fluxor;
using FrontEnd.Features.Category.StateManagment.Actions.AddCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.TopCategoryActions;
using FrontEnd.Features.Category.StateManagment.States;

namespace FrontEnd.Features.Category.StateManagment.Reducers
{
    public static class CategoryReducers
    {
        [ReducerMethod]
        public static CategoryState ReduceTopCategoryAction(CategoryState state, TopCategoriesAction action)
        {
            return new CategoryState(isLoading: true, categories: null);
        }

        [ReducerMethod]
        public static CategoryState ReduceTopCategoriesResultAction(CategoryState state, TopCategoriesResultAction action)
        {
            return new CategoryState(isLoading: false, categories: action.Categories);
        }

        [ReducerMethod]
        public static CategoryState ReduceTongleCategoryAction(CategoryState state, TongleCategoryAction action)
        {
            return new CategoryState(isLoading: true, categories: action.Categories);
        }
        [ReducerMethod]
        public static CategoryState ReduceTongleCategoryResultAction(CategoryState state, TongleCategoryResultAction action)
        {
            return new CategoryState(isLoading: false, categories: action.Categories);
        }

        [ReducerMethod]
        public static CategoryState ReduceAddCategoryActionn(CategoryState state, AddCategoryAction action)
        {
            return new CategoryState(isLoading: true, categories: action.Categories);
        }
        [ReducerMethod]
        public static CategoryState ReduceAddCategoryResultAction(CategoryState state, AddCategoryResultAction action)
        {
            return new CategoryState(isLoading: false, categories: action.Categories);
        }

    }
}
