using Microsoft.AspNetCore.Components;

namespace BlazorUI.Views
{
    public partial class HomeButtonDefault
    {
        [Parameter] public string UrlParameter { get; set; } = string.Empty;
    }
}
