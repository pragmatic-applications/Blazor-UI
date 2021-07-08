using System;
using System.Threading.Tasks;

using Interfaces;

using Lib_BrowserPlatform;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorUI
{
    public class CoreComponent : ComponentBase
    {
        public bool IsDebugConsole { get; set; } = true;

        public static int EntityId = 0;
        public string ButtonText { get; set; } = "Save";

        public FormMode FormMode { get; set; } = FormMode.Create;
        public string FormTitle { get; set; }

        public static string CategoryName { get; set; } // CoreComponent.CategoryName
        public static int CategoryId { get; set; } // CoreComponent.CategoryId

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public int IdParameter { get; set; } = 0;
        [Parameter] public string UrlParameter { get; set; } = string.Empty;

        [Inject] public NavigationManager NavigationManager { get; set; }

        public string CurrentTitle { get; set; } = string.Empty;
        public string PageToNavigateTo { get; set; } = string.Empty;

        [Parameter] public ISelect SelectParameter { get; set; }
        [Parameter] public int SpreadParameter { get; set; }
        [Parameter] public PagerData PagerDataParameter { get; set; }

        [Parameter] public string AdminTitleParameter { get; set; }
        [Parameter] public string HomeTitleParameter { get; set; }
        [Parameter] public string AboutTitleParameter { get; set; }
        [Parameter] public string ItemTitleParameter { get; set; }
        [Parameter] public string ProductTitleParameter { get; set; }
        [Parameter] public string StudentTitleParameter { get; set; }
        [Parameter] public string ShopTitleParameter { get; set; }

        [Parameter] public string ButtonLogoValueParameter { get; set; }

        [Parameter] public string TitleParameter { get; set; }

        public string HeadTitleValue { get; set; }
        public int SpreadValue { get; set; }

        [Parameter] public string BannerTitleParameter { get; set; }
        public string BannerTitleValue { get; set; }
        public string HeaderTitle { get; set; }

        [Parameter] public string AppNameParameter { get; set; }
        public string AppNameValue { get; set; }
        public string AppName { get; set; }

        [CascadingParameter(Name = "ItemTitleValue")] public string ItemTitleCParameter { get; set; }
        [CascadingParameter(Name = "ProductTitleValue")] public string ProductTitleCParameter { get; set; }
        [CascadingParameter(Name = "StudentTitleValue")] public string StudentTitleCParameter { get; set; }
        [CascadingParameter(Name = "AdminTitleValue")] public string AdminTitleCParameter { get; set; }
        [CascadingParameter(Name = "HomeTitleValue")] public string HomeTitleCParameter { get; set; }
        [CascadingParameter(Name = "AboutTitleValue")] public string AboutTitleCParameter { get; set; }

        [CascadingParameter(Name = "ShopTitleValue")] public string ShopTitleCParameter { get; set; }
        [CascadingParameter(Name = "TitleValue")] public string TitleCParameter { get; set; }
        [CascadingParameter] public string TitleCascadingParameter { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.CurrentTitle = string.IsNullOrWhiteSpace(this.TitleParameter) ? "Blazor & MVC" : this.TitleParameter;
        }

        [Parameter] public bool IsPageIndexParameter { get; set; } = false;
        [Parameter] public bool IsCrudParameter { get; set; } = false;
        [Parameter] public bool IsPageAdminParameter { get; set; } = false;

        public string UrlUpdate { get; set; }
        public string UrlDelete { get; set; }

        protected int ImageCount { get; set; } = 0;

        public ISelect ItemSelect { get; set; }

        protected virtual void ClearFields() { }


        protected virtual void Reload()
        {
            this.ClearFields();
            this.NavigationManager.NavigateTo("/");
        }

        protected void GoToPage(string pageToNavigateTo)
        {
            this.ClearFields();
            this.StateHasChanged();
            this.NavigationManager.NavigateTo(pageToNavigateTo);
        }

        [Inject] public ImageUploaderService ImageUploaderService { get; set; }
        public string ImageFimeName { get; set; }
        protected string FileNameStart => Guid.NewGuid().ToString() + "_";

        [Inject] public EntityParameter EntityParameter { get; set; }
        [Inject] public PagerData PagerData { get; set; }

        protected virtual Task GetAsync() => Task.FromResult(default(object));
        protected virtual Task GetAsync(int id) => Task.FromResult(default(object));
        protected virtual Task InsertAsync() => Task.FromResult(default(object));
        protected virtual Task UpdateAsync() => Task.FromResult(default(object));
        protected virtual Task DeleteAsync() => Task.FromResult(default(object));
        protected virtual Task GetEntityCategoryAsync() => Task.FromResult(default(object));

        [Parameter] public EventCallback<string> OnSearchChanged { get; set; }
        protected async Task SearchChanged(string searchTerm)
        {
            this.EntityParameter.PageNumber = 1;
            this.EntityParameter.SearchTerm = searchTerm;
            await this.GetAsync();
        }

        
        [Parameter] public EventCallback<string> OnSortChanged { get; set; }
        protected async Task SortChanged(string orderBy)
        {
            this.EntityParameter.OrderBy = orderBy;
            await this.GetAsync();
        }

        [Parameter] public EventCallback<int> OnSelectedPage { get; set; }
        protected async Task SelectedPage(int page)
        {
            this.EntityParameter.PageNumber = page;

            await this.GetAsync();
        }

        protected async Task OnChange(InputFileChangeEventArgs e)
        {
            var files = e.GetMultipleFiles();

            foreach(var file in files)
            {
                var resizedFile = await file.RequestImageFileAsync(file.ContentType, 640, 480);
                var buf = new byte[resizedFile.Size];

                using var stream = resizedFile.OpenReadStream();
                await stream.ReadAsync(buf);

                this.ImageFimeName = file.Name;
                this.ImageUploaderService.ImageFiles.Add(new ImageFile { Base64Data = Convert.ToBase64String(buf), ContentType = file.ContentType, FileName = file.Name });
            }

            this.ImageUploaderService.Message = $"Click the Upload button to upload {this.ImageFimeName}";
            this.ImageUploaderService.IsDisabled = false;
        }

        protected async Task<string> UploadFilesAsync()
        {
            var fileNameStart = this.FileNameStart;
            await this.ImageUploaderService.UploadAsync(fileNameStart: fileNameStart);

            return fileNameStart;
        }

        protected virtual Task UploadAsync() => Task.FromResult(default(object));

        // Generic Class members
        public bool IsLoading { get; set; }
        public bool IsError { get; set; }

        protected virtual void LoadDataFail(Exception exception) { }
        protected virtual void LoadDataCategoryFail(Exception exception) { }
        // Generic Class members
        // E NN
    }
}
