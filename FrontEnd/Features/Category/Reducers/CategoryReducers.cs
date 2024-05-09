using Fluxor;
using FrontEnd.Features.Category.Actions;
using FrontEnd.Features.Category.States;

namespace FrontEnd.Features.Category.Reducers
{
    public static class CategoryReducers
    {
        [ReducerMethod]
        public static CategoryState ReduceCategoryAction(CategoryState state, CategoryAction action)
        {
            return new CategoryState(isLoading: true, categories: null);
        }

        [ReducerMethod]
        public static CategoryState ReduceCategoriesDataAction(CategoryState state, CategoriesDataAction action)
        {
            return new CategoryState(isLoading: false, categories: action.Categories);
        }
        }
    }
