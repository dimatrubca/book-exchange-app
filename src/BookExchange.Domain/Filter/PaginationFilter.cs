using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.Filter
{
     public class PaginationFilter
     {
          private int _pageNumber;
          private int _pageSize;

          public int PageNumber { 
               get {
                    return this._pageNumber;
               }
               
               set  
               {
                    if (value < 1) _pageNumber = 1;
                    else if (value > 10) _pageNumber = 10;
                    else _pageNumber = value;
               } 
          }

          public int PageSize
          {
               get
               {
                    return this._pageSize;
               }

               set
               {
                    if (value < 1) _pageSize = 1;
                    else if (value > 10) _pageSize = 10;
                    else _pageSize = value;

               }
          }

          public string SortDirection { get; set; }
          public string SortBy { get; set; }

          public PaginationFilter()
          {
               this.PageNumber = 1;
               this.PageSize = 10;
          }
          public PaginationFilter(int pageNumber, int pageSize)
          {
               this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
               this.PageSize = pageSize > 10 ? 10 : pageSize;
          }
     }
}
