using System.Collections.Generic;

namespace Lib_BrowserPlatform
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public PagerData PagerData { get; set; }
    }
}
