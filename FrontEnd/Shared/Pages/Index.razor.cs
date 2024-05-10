using FrontEnd.Features.Category.Component;
using FrontEnd.Features.Category.StateManagment.Actions.TopCategoryActions;
using FrontEnd.Shared.Components;

namespace FrontEnd.Shared.Pages
{
    public partial class Index
    {
        ModalComponent modal;
        void OpenModal()
        {
            modal.Open();
        }
        void CloseModal()
        {
            modal.Close();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new TopCategoriesAction());
        }
    }
}
