using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Wrappers
{
     public class PagedResponse<T> : Response<T>
     {
          public int PageNumber { get; set; }
          public int PageSize { get; set; } 
          public int TotalPages { get; set; }

          public PagedResponse(T data, int pageNumber, int pageSize)
          {
               this.PageNumber = pageNumber;
               this.PageSize = pageSize;
               this.Data = data;
          }
     }
}
