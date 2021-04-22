using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class BookDetails : BaseEntity
     {
          public string Description { get; set; }
          public string Publisher { get; set; }
          public DateTime? PublishedOn { get; set; }
          public int? PageCount { get; set; }
          public string ImagePath { get; set; }

          public int BookId { get; set; }
          public Book Book { get; set; }
     }
}
