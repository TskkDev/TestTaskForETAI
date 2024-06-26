﻿using FrontEnd.Features.Goods.StateManagment.Actions.AddGoodAction;
using FrontEnd.Features.Goods.StateManagment.Actions.DeleteGoodAction;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Features.Goods.Component
{
    public partial class DialogModalComponent
    {
        [Parameter]
        public int DeleteId { get; set; }

        [Parameter]
        public Action ToggleModal { get; set; }
        private void Send()
        {
            try 
            { 
            Dispatcher.Dispatch(new DeleteGoodAction(DeleteId, GoodState.Value.Goods));
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
            ToggleModal();
        }
    }
}
