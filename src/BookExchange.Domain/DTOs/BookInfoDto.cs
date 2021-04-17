using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.DTOs
{
     public class BookInfoDTO
     {
          public string Title { get; set; }
          public List<string> Authors { get; set; }
          public string Description { get; set; }
          public string isbn10 { get; set; }
          public string isbn13 { get; set; }
          public int PageCount { get; set; }
          public string Publisher { get; set; }
          public List<string> Categories { get; set; }
          public string SmallThumbnailLink { get; set; }
          public string ThumbnailLink { get; set; }
          public string Language { get; set; }
     }
}
