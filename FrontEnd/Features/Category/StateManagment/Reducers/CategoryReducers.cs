using Fluxor;
using FrontEnd.Features.Category.StateManagment.Actions.AddCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.TopCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.UpdateCategoryAction;
using FrontEnd.Features.Category.StateManagment.Actions.UpdateCateoryInfoAction;
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

        [ReducerMethod]
        public static CategoryState ReduceUpdateCategoryActionn(CategoryState state, UpdateCategoryAction action)
        {
            return new CategoryState(isLoading: true, categories: action.Categories);
        }
        [ReducerMethod]
        public static CategoryState ReduceUpdateCategoryResultAction(CategoryState state, UpdateCategoryResultAction action)
        {
            return new CategoryState(isLoading: false, categories: action.Categories);
        }
        
        [ReducerMethod]
        public static CategoryState ReduceUpdateCateoriesInfoAction(CategoryState state, UpdateCateoriesInfoAction action)
        {
            return new CategoryState(isLoading: true, categories: action.Categories);
        }
        [ReducerMethod]
        public static CategoryState ReduceUpdateCateoriesInfoResultAction(CategoryState state, UpdateCateoriesInfoResultAction action)
        {
            return new CategoryState(isLoading: false, categories: action.Categories);
        }

    }
}
