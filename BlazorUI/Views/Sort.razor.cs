using System.Threading.Tasks;

using Interfaces;

using Microsoft.AspNetCore.Components;

namespace BlazorUI.Views
{
    public partial class Sort : CoreComponent
    {
        [CascadingParameter(Name = "SelectParameterValue")] public ISelect SelectCascadingParameter { get; set; }

        private async Task ApplySort(ChangeEventArgs eventArgs)
        {
            if(eventArgs.Value.ToString() == "-1") { return; }

            await this.OnSortChanged.InvokeAsync(eventArgs.Value.ToString());
        }
    }
}

//<svg xmlns="http://www.w3.org/2000/svg" width="100" height="50"><polygon points="0,0 100,0 50,50" /></svg>
