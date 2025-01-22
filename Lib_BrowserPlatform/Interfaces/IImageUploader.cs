using System.Net.Http;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IImageUploader
    {
        Task<string> UploadImageAsync(MultipartFormDataContent content);
    }
}
