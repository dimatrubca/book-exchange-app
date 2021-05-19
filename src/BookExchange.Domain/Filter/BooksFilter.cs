using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.Filter
{
     public class BooksFilter : PaginationRequestFilter
     {
          public bool IncludeDetails { get; set; }
          public bool IncludeAuthors { get; set; }
          public bool IncludeCategories { get; set; }
          public bool IncludeWishedBy { get; set; }

          public string ISBN { get; set; }
          public string Title { get; set; }
          public string Author { get; set; }
          public List<string> Categories { get; set; }
          public string Publisher { get; set; }
          public string Description { get; set; }
          public DateTime PublishedOn { get; set; }
          public int? PageCount { get; set; }
          public int? MinPageCount { get; set; }   
          public int? MaxPageCount { get; set; }
     }
}



