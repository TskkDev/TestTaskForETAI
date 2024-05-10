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
}
