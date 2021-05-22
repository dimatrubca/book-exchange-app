using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.Filter
{
     public class BooksFilter : PaginationFilter
     {
          public bool IncludeDetails { get; set; }
          public bool IncludeAuthors { get; set; }
          public bool IncludeCategories { get; set; }
          public bool IncludeWishedBy { get; set; }

          public string ISBN { get; set; }
          public string Title { get; set; }
          public List<int> AuthorsId { get; set; }
          public List<int> CategoriesId { get; set; }
          public string Publisher { get; set; }
          public string Description { get; set; }
          public int? PublishedYear { get; set; }
          public int? PageCount { get; set; }
          public int? MinPageCount { get; set; }   
          public int? MaxPageCount { get; set; }
     }
}



