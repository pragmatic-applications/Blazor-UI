namespace Lib_BrowserPlatform
{
    public class EntityParameter
    {
        private const int max_Page_Size = 50;
        public int PageNumber { get; set; } = 1;

        //private int pageSize = 4;
        private int pageSize = NumberData.Page_Size;

        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                this.pageSize = (value > max_Page_Size) ? max_Page_Size : value;
            }
        }

        public string SearchTerm { get; set; }
        public string OrderBy { get; set; } = "name";
    }
}
