using Microsoft.AspNetCore.Components;

namespace BlazorUI
{
    public class FormCore : ComponentBase
    {
        [Parameter] public EventCallback OnValidSubmit { get; set; }
        [Parameter] public EventCallback OnInvalidSubmit { get; set; }

        [Parameter] public string ButtonTextParameter { get; set; }
        [Parameter] public string FormTitleParameter { get; set; }
        [Parameter] public FormMode FormModeParameter { get; set; } = FormMode.Create;

        public string CategoryId { get; set; } = "0";

        public string Zero { get; set; } = "0";

        protected bool IsDisabled
        {
            get
            {
                return CategoryId == Zero;
            }
        }

        public int GetCategoryId(string categoryId)
        {
            int.TryParse(categoryId, out var result);

            return result;
        }
    }
}
