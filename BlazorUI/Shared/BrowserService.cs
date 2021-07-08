using System;
using System.Threading.Tasks;

using Interfaces;

using Lib_BrowserPlatform;

using Microsoft.JSInterop;

namespace BlazorUI
{
    public class BrowserService : JavaScriptServiceBase, IBrowserService, IAsyncDisposable
    {
        public BrowserService(IJSRuntime jsRuntime) : base(jsRuntime) => JavaScriptServiceBase.JavaScriptFile = BrowserServiceJS;

        protected const string BrowserServiceJS = "./_content/BlazorUI/js/BrowserService.js";

        public async ValueTask Resize()
        {
            var module = await this.ModuleTask.Value;
            await module.InvokeVoidAsync("resize");
        }

        public async ValueTask OnWindowSize()
        {
            var module = await this.ModuleTask.Value;
            await module.InvokeVoidAsync("onWindowSize");
        }

        public async Task<BrowserDimension> GetDimensions()
        {
            var module = await this.ModuleTask.Value;

            return await module.InvokeAsync<BrowserDimension>("getDimensions");
        }

        public async ValueTask DisposeAsync()
        {
            if(this.ModuleTask.IsValueCreated)
            {
                var module = await this.ModuleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
