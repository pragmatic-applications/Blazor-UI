using System.Threading.Tasks;

using Lib_BrowserPlatform;

namespace Interfaces
{
    public interface IBrowserService
    {
        Task<BrowserDimension> GetDimensions();
        ValueTask Resize();
        ValueTask OnWindowSize();
    }
}
