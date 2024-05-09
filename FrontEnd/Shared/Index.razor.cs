using FrontEnd.Features.Category.StateManagment.Actions.TopCategoryActions;

namespace FrontEnd.Shared
{
    public partial class Index
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new TopCategoriesAction());
        }
    }
}
