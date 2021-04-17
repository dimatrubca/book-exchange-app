using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.DTOs.GoogleBooks
{
     public class BookVolumesDTO
     {
          public string kind { get; set; }
          public int totalItems { get; set; }
          public List<BookVolumeDTO> items { get; set; }
     }
}
