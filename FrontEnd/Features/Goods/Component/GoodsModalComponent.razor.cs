using Fluxor;
using FrontEnd.Features.Category.Models;
using FrontEnd.Features.Category.StateManagment.Actions.AddCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.UpdateCategoryAction;
using FrontEnd.Features.Goods.Models;
using FrontEnd.Features.Goods.StateManagment.Actions.AddGoodAction;
using FrontEnd.Features.Goods.StateManagment.Actions.UpdateGoodAction;
using Microsoft.AspNetCore.Components;
using SharedModels.Models.RequestModels;
using System.Xml.Linq;

namespace FrontEnd.Features.Goods.Component
{
    public partial class GoodsModalComponent
    {
        [Parameter]
        public int? UpdateId { get; set; }

        [Parameter]
        public Action ToggleModal { get; set; }
        [Parameter]
        public string GoodName { get; set; }
        [Parameter]
        public string Disc { get; set; }
        [Parameter]
        public decimal Price { get; set; }
        [Parameter]
        public int CategoryId { get; set; }

        private void Send()
        {
            if(UpdateId == null)
            {
                var newGood = new GoodRequestModel()
                {
                    Name = GoodName,
                    CategoryId = CategoryId,
                    Dics= Disc,
                    Price = Price,
                };
                Dispatcher.Dispatch(new AddGoodAction(newGood, GoodState.Value.Goods));
            }
            else
            {
                var updatedCategpry = new UpdateGoodModel()
                {
                    GoodId = UpdateId??throw new Exception("no way Exception [UpdateGoods]"),
                    NewGood = new GoodRequestModel()
                    {
                        Name = GoodName,
                        CategoryId = CategoryId,
                        Dics= Disc,
                        Price = Price,
                    }

                };
                Dispatcher.Dispatch(new UpdateGoodAction(updatedCategpry, GoodState.Value.Goods));
            }
            GoodName = "";
            CategoryId = 0;
            Disc = "";
            Price = 0;
            ToggleModal();
        }
    }
}
