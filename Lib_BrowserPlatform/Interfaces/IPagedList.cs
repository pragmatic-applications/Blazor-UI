using System.Threading.Tasks;

using Lib_BrowserPlatform;

namespace Interfaces
{
    public interface IPagedList<T> where T : class
    {
        Task<PagedList<T>> GetPagedList(EntityParameter entityParameter);
    }
}
