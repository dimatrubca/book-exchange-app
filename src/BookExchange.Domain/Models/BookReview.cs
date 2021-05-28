using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class BookReview : BaseEntity
     {
          //public int BookReviewId { get; set; }
          public int BookId { get; set; }
          public int UserId { get; set; }
          public decimal Rating { get; set; }
          public virtual Book Book { get; set; }
          public virtual User User { get; set; }
     }
}
