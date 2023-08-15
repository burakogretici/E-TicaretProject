namespace Core.Utilities.Paging
{
    public record PageRequest : IPageRequest
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }

        public PageRequest()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public PageRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 5 ? 5 : pageSize;
        }
    }
}
