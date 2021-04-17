using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class BookReview : Review
     {
          public int BookId { get; set; }
          public virtual Book Book { get; set; }
     }
}
