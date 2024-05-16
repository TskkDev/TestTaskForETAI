using FrontEnd.Features.Category.StateManagment.Actions.UpdateCateoryInfoAction;
using FrontEnd.Features.Category.StateManagment.States;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Shared.Components;

public partial class ModalComponent
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public bool IsOpen { get; private set; }
    private void ToggleModal()
    {
        IsOpen = !IsOpen;
    }
    public void Open()
    {
        IsOpen = true;
    }
    public void Close()
    {
        IsOpen = false;
    }
    public async void Close(int firstSelectedCategory)
    {
        IsOpen = false;
        await Task.Delay(200);
        Dispatcher.Dispatch(new UpdateCateoriesInfoAction(
                    firstSelectedCategory, null,
                    CategoryState.Value.Categories));
    }
    public async void Close( int firstSelectedCategory, int? secondSelectedCategory)
    {
        IsOpen = false;
        await Task.Delay(200);
        Dispatcher.Dispatch(new UpdateCateoriesInfoAction(
                    firstSelectedCategory, secondSelectedCategory,
                    CategoryState.Value.Categories));
    }
}
