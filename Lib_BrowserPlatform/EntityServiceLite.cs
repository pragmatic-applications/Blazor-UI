using System.Net.Http;
using System.Threading.Tasks;

namespace Lib_BrowserPlatform
{
    public class EntityServiceLite : EntityServiceBase
    {
        public EntityServiceLite(HttpClient httpClient) : base(httpClient: httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetAsync() => await this.HttpClient.GetAsync(this.Url);
    }
}
