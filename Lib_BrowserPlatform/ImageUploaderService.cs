using Constants;

using System.Net.Http;

namespace Lib_BrowserPlatform
{
    public class ImageUploaderService : EntityServiceBase
    {
        public ImageUploaderService(HttpClient httpClient) : base(httpClient: httpClient) => this.UrlApiUploader = HttpConstant.Url_S_Api_Upload;

        public const string Url_S_Api_Upload = HttpConstant.Url_S_Api_Upload;
    }
}
