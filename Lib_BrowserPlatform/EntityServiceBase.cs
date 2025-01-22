using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

using Constants;

namespace Lib_BrowserPlatform
{
    public class EntityServiceBase
    {
        public EntityServiceBase(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(HttpConstant.Url_Api_Base);
            this.HttpClient = httpClient;
        }

        protected HttpClient HttpClient { get; set; }
        protected string Url { get; set; }
        public string UrlApiUploader { get; set; }

        public List<ImageFile> ImageFiles { get; set; } = new();
        public string Message { get; set; } = "InputFile";
        public bool IsDisabled { get; set; } = true;

        public async Task UploadAsync(string fileNameStart)
        {
            using var msg = await this.HttpClient.PostAsJsonAsync<List<ImageFile>>(this.UrlApiUploader + $"/{fileNameStart}", this.ImageFiles, CancellationToken.None);

            this.IsDisabled = false;

            if(msg.IsSuccessStatusCode)
            {
                this.Message = $"{this.ImageFiles.Count} files uploaded";
                this.ImageFiles.Clear();

                this.IsDisabled = true;
            }
        }
    }
}
