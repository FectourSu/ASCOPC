using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCOPC.Shared.Responses
{
    public class PaginationResponse<TValue>
    {
        public PaginationResponse()
        {
            Values = new List<TValue>();
        }

        public PaginationResponse(IEnumerable<TValue> values, int page, int pageSize)
        {
            Values = values;
            Page = page;
            PageSize = pageSize;
        }

        public IEnumerable<TValue> Values { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages => Convert.ToInt32(Math.Ceiling((double)Page / PageSize));
    }
}
