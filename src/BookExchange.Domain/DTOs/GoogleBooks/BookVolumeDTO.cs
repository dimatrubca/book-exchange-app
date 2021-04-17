using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.DTOs.GoogleBooks
{
     public class BookVolumeDTO
     {
          public string kind { get; set; }
          public string id { get; set; }
          public string etag { get; set; }
          public string selfLink { get; set; }
          public VolumeInfo volumeInfo { get; set; }
     }
}
