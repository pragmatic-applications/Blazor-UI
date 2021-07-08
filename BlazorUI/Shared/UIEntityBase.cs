using Microsoft.AspNetCore.Components;

namespace BlazorUI
{
    public class UIEntityBase : ComponentBase
    {
        [Parameter] public bool IsCrudParameter { get; set; } = false;

        public string UrlDetail { get; set; }
        public string UrlEdit { get; set; }
        public string UrlDelete { get; set; }
    }
}
