using Microsoft.AspNetCore.Components;

namespace BlazorUI.Views
{
    public partial class Container<TEntity> : ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public TEntity UIEntityParameter { get; set; }
    }
}
