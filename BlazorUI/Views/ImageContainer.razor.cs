using System.Collections.Generic;

using Microsoft.AspNetCore.Components;

namespace BlazorUI.Views
{
    public partial class ImageContainer : ComponentBase
    {
        [Parameter] public string ImageParameter { get; set; }
        [Parameter] public string UrlApiImageParameter { get; set; }
        [Parameter] public string MaxWidthParameter { get; set; }

        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> Attributes { get; set; }

        public string Url { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            this.Url = $"{this.UrlApiImageParameter}/{this.ImageParameter}";
        }

        //protected override Task OnParametersSetAsync()
        //{
        //    return base.OnParametersSetAsync();
        //}

        //public const string Url_Api_Base_S_Images_UploadFiles = "https://localhost:5551/Images/UploadFiles";
        //public const string Url_Api_Base_S_Images_UploadFiles = "https://localhost:5551/Images/UploadFiles";
        //AppState.IsDeployed
    }
}
