using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class BookAuthor : BaseEntity
     {
          public int Order { get; set; }
          public int BookId { get; set; }
          public int AuthorId { get; set; }

          public virtual Book Book { get; set; }
          public virtual Author Author { get; set; }
     }
}
