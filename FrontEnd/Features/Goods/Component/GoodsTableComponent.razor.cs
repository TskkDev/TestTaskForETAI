using FrontEnd.Features.Category.StateManagment.Actions.TopCategoryActions;
using FrontEnd.Features.Goods.Enums;
using FrontEnd.Features.Goods.StateManagment.Actions.SortGoodsAction;
using FrontEnd.Shared.Components;
using Microsoft.AspNetCore.Components;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.Component
{
    public partial class GoodsTableComponent
    {
        [Parameter]
        public IEnumerable<GetCategoryNameResponse> Goods { get; set; }
        [Parameter]
        public int CategoryIdParam { get; set; }


        ModalComponent modal;
        ModalComponent dialogModal;
        private int? updatedId;
        private string goodName;
        private int categoryId;
        private string disc;
        private decimal price;
        private void OpenAddModal(int categoryId)
        {
            this.categoryId = categoryId;

            modal.Open();
        }
        private void OpenUpdateModal(GetCategoryNameResponse good)
        {
            updatedId = good.Id;
            goodName = good.Name;
            categoryId = good.CategoryId;
            disc = good.Dics;
            price = good.Price;

            modal.Open();
        }

        private void CloseModal()
        {
            modal.Close();
        }
        private void OpenDialogModal(int goodId)
        {
            updatedId = goodId;
            dialogModal.Open();
        }

        private void CloseDialogModal()
        {
            dialogModal.Close();
        }




        private GoodsFieldEnum previosFieldName = GoodsFieldEnum.Id;
        private bool ascending = true;

        private void Sort(GoodsFieldEnum fieldName, int categoryId)
        {
            if(fieldName == previosFieldName)
            {
                ascending = !ascending;
            }
            Dispatcher.Dispatch(new SortGoodsAction(CategoryIdParam, fieldName.ToString(), ascending));
            previosFieldName = fieldName;
        }
    }
}
