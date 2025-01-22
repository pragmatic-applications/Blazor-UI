using System.Net.Http;
using System.Threading.Tasks;

using Lib_BrowserPlatform;

namespace Interfaces
{
    public interface IEntityHttpRepository<TEntity> : IImageUploader where TEntity : class
    {
        Task<PagingResponse<TEntity>> GetAsync(EntityParameter EntityParameter);

        public HttpClient HttpClient { get; set; }
        public string Url { get; set; }
        public string UrlFilter { get; set; }

        Task<TEntity> GetAsync(int id);

        Task AddAsync(TEntity model);

        Task EditAsync(int id, TEntity model);

        Task DeleteAsync(int id);
    }
}
