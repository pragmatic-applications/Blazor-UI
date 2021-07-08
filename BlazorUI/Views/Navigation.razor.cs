using System.Collections.Generic;

using Lib_BrowserPlatform;

using Microsoft.AspNetCore.Components;

namespace BlazorUI.Views
{
    public partial class Navigation
    {
        [Parameter] public List<PageLink> NavLinks { get; set; }

        [Parameter] public string BisName { get; set; }
    }
}
