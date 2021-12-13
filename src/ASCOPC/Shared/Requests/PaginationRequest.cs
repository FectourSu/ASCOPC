namespace ASCOPC.Shared.Requests
{
    public class PaginationRequest
    {
        public PaginationRequest() : this(page: 1, pageSize: 5)
        {
        }

        public PaginationRequest(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
