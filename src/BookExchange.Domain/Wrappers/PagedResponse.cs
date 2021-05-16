using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.Wrappers
{
     public class PagedResponse<T> : Response<T>
     {
          public int PageNumber { get; set; }
          public int PageSize { get; set; } 
          public int TotalPages { get; set; }
          public Uri FirstPage { get; set; }
          public Uri LastPage { get; set; }
          public int TotalRecords { get; set; }
          public Uri NextPage { get; set; }
          public Uri PreviousPage { get; set; }

          public PagedResponse(T data, int pageNumber, int pageSize) : base(data)
          {
               this.PageNumber = pageNumber;
               this.PageSize = pageSize;
               this.Data = data;
          }
     }
}
