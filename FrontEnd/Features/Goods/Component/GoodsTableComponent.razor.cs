using FrontEnd.Features.Goods.Enums;
using FrontEnd.Features.Goods.StateManagment.Actions.SortGoodsAction;
using FrontEnd.Features.Goods.StateManagment.States;
using FrontEnd.Shared.Components;
using Microsoft.AspNetCore.Components;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.Component
{
    public partial class GoodsTableComponent
    {
        #region params and fields
        [Parameter]
        public int CategoryIdParam { get; set; }

        private int? updatedId;
        private string goodName;
        private int categoryId;
        private string disc;
        private decimal price;
        #endregion

        #region modal and modalLogic
        ModalComponent modal;
        ModalComponent dialogModal;
        GoodsModalComponent modalComponent;
        public event Action<int> CategorySelected;
        public int CategorySelectedValue;

        private void HandleCategorySelected(int selectedCategory)
        {
            CategorySelectedValue = selectedCategory;
        }
        private void OpenAddModal(int categoryId)
        {
            this.categoryId = categoryId;

            modal.Open();
            updatedId = null;
            goodName = "";
            this.categoryId = 0;
            disc = "";
            price = 0;
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
            CategorySelected.Invoke(CategorySelectedValue);

        }
        private void OpenDialogModal(int goodId)
        {
            updatedId = goodId;
            dialogModal.Open();
        }

        private void CloseDialogModal()
        {
            dialogModal.Close();
            CategorySelected.Invoke(categoryId);
        }
        #endregion


        #region sort
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
        #endregion

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            modalComponent.CategorySelected += HandleCategorySelected;
        }
    }
}
