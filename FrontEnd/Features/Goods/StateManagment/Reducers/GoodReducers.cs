using Fluxor;
using FrontEnd.Features.Category.StateManagment.Actions.TopCategoryActions;
using FrontEnd.Features.Category.StateManagment.States;
using FrontEnd.Features.Goods.StateManagment.Actions.AddGoodAction;
using FrontEnd.Features.Goods.StateManagment.Actions.DeleteGoodAction;
using FrontEnd.Features.Goods.StateManagment.Actions.LoadGoodsAction;
using FrontEnd.Features.Goods.StateManagment.Actions.SortGoodsAction;
using FrontEnd.Features.Goods.StateManagment.Actions.UpdateGoodAction;
using FrontEnd.Features.Goods.StateManagment.States;

namespace FrontEnd.Features.Goods.StateManagment.Reducers
{
    public static class GoodReducers
    {
        [ReducerMethod]
        public static GoodState ReduceLoadGoodsAction(GoodState state, LoadGoodsAction action)
        {
            return new GoodState(isLoading: true, goods: null);
        }

        [ReducerMethod]
        public static GoodState ReduceLoadGoodsResultAction(GoodState state, LoadGoodsResultAction action)
        {
            return new GoodState(isLoading: false, goods: action.Goods);
        }

        [ReducerMethod]
        public static GoodState ReduceSortGoodsAction(GoodState state, SortGoodsAction action)
        {
            return new GoodState(isLoading: true, goods: state.Goods);
        }

        [ReducerMethod]
        public static GoodState ReduceSortGoodsResultAction(GoodState state, SortGoodsResultAction action)
        {
            return new GoodState(isLoading: false, goods: action.Goods);
        }

        [ReducerMethod]
        public static GoodState ReduceAddGoodAction(GoodState state, AddGoodAction action)
        {
            return new GoodState(isLoading: true, goods: action.Goods);
        }

        [ReducerMethod]
        public static GoodState ReduceAddGoodResultAction(GoodState state, AddGoodResultAction action)
        {
            return new GoodState(isLoading: false, goods: action.Goods);
        }

        [ReducerMethod]
        public static GoodState ReduceUpdateGoodAction(GoodState state, UpdateGoodAction action)
        {
            return new GoodState(isLoading: true, goods: action.Goods);
        }

        [ReducerMethod]
        public static GoodState ReduceUpdateGoodResultAction(GoodState state, UpdateGoodResultAction action)
        {
            return new GoodState(isLoading: false, goods: action.Goods);
        }

        [ReducerMethod]
        public static GoodState ReduceDeleteGoodAction(GoodState state, DeleteGoodAction action)
        {
            return new GoodState(isLoading: true, goods: action.Goods);
        }

        [ReducerMethod]
        public static GoodState ReduceDeleteGoodResultAction(GoodState state, DeleteGoodResultAction action)
        {
            return new GoodState(isLoading: false, goods: action.Goods);
        }
    }
}
