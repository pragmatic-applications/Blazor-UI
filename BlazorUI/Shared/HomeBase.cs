using Microsoft.AspNetCore.Components;

namespace BlazorUI
{
    public class HomeBase : UIEntityBase
    {
        [Parameter] public bool IsPageAdminParameter { get; set; } = false;
        public string Url { get; set; }
    }
}
