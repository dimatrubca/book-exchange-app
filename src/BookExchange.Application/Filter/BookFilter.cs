using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Filter
{
     public class BookFilter : PaginationFilter
     {
          public string ISBN { get; set; }
          public string Title { get; set; }
          public string Author { get; set; }
          public string Condition { get; set; }
          public string Category { get; set; }
          public string Publisher { get; set; }
          public string Description { get; set; }
          public int MinPageCount { get; set; }   
          public int MaxPageCount { get; set; }
     }
}
