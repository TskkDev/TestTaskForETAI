using Fluxor;
using FrontEnd.Features.Goods.Interfaces;
using FrontEnd.Features.Goods.Services;
using FrontEnd.Features.Goods.StateManagment.Actions.AddGoodAction;
using FrontEnd.Features.Goods.StateManagment.Actions.DeleteGoodAction;
using FrontEnd.Features.Goods.StateManagment.Actions.LoadGoodsAction;
using FrontEnd.Features.Goods.StateManagment.Actions.SortGoodsAction;
using FrontEnd.Features.Goods.StateManagment.Actions.UpdateGoodAction;

namespace FrontEnd.Features.Goods.StateManagment.Effects
{
    public class GoodEffects
    {
        private readonly IGoodService _goodService;
        private readonly StateHelper _stateHelper;
        public GoodEffects(IGoodService goodService)
        {
            _goodService = goodService;
            _stateHelper = new StateHelper();
        }
        [EffectMethod]
        public async Task HandleLoadGoodsAction(LoadGoodsAction action, IDispatcher dispatcher)
        {
            var goods = await _goodService.GetGoodsFromCategory(action.CategoryId);
            dispatcher.Dispatch(new LoadGoodsResultAction(goods));
        }

        [EffectMethod]
        public async Task HandleSortGoodsAction(SortGoodsAction action, IDispatcher dispatcher)
        {
            var goods = await _goodService.GetGoodsFromCategoryWithSort(action.CategoryId, 
                action.FieldName, action.Ascending);
            dispatcher.Dispatch(new SortGoodsResultAction(goods));
        }

        [EffectMethod]
        public async Task HandleAddGoodAction(AddGoodAction action, IDispatcher dispatcher)
        {

            var good = await _goodService.AddGood(action.Good);
            var newGoods = _stateHelper.AddGoodInGoodsList(action.Goods, good);
            dispatcher.Dispatch(new AddGoodResultAction(newGoods));
        }

        [EffectMethod]
        public async Task HandleUpdateGoodAction(UpdateGoodAction action, IDispatcher dispatcher)
        {

            var good = await _goodService.UpdateGood(action.NewGood);
            var newGoods = _stateHelper.UpdateGoodInGoodsList(action.Goods, good);
            dispatcher.Dispatch(new UpdateGoodResultAction(newGoods));
        }

        [EffectMethod]
        public async Task HandleDeleteGoodAction(DeleteGoodAction action, IDispatcher dispatcher)
        {

            await _goodService.DeleteGood(action.GoodId);
            var newGoods = _stateHelper.DeleteGoodFromGoodsList(action.Goods, action.GoodId);
            dispatcher.Dispatch(new DeleteGoodResultAction(newGoods));
        }
    }
}
