using Microsoft.AspNetCore.Components;

namespace BlazorUI.Views
{
    public partial class AlertBox
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
