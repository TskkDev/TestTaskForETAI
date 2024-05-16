using FrontEnd.Features.Category.Component;
using FrontEnd.Features.Category.StateManagment.Actions.TongleCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.TopCategoryActions;
using FrontEnd.Features.Category.StateManagment.Actions.UpdateCateoryInfoAction;
using FrontEnd.Features.Goods.Component;
using FrontEnd.Features.Goods.StateManagment.States;
using FrontEnd.Shared.Components;
using FrontEnd.Shared.Service.ErrorService;

namespace FrontEnd.Shared.Pages
{
    public partial class Index
    {
        ModalComponent modal;
        ModalComponent errorModal;

        private List<string> ErrorMessage = new List<string>();
        private void OpenModal()
        {
            modal.Open();
        }
        private void CloseModal()
        {
            modal.Close();
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            ErrorService.OnErrors += ShowError;
            Dispatcher.Dispatch(new TopCategoriesAction());

        }

        private void ShowError(List<string> errorMessage)
        {
            ErrorService.RemoveAllErrors();
            ErrorMessage = errorMessage;
            errorModal.Open();
        }
    }
}
