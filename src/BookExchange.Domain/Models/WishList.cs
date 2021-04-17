using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class WishList : BaseEntity
     {
          public int UserId { get; set; }
          public int BookId { get; set; }

          public virtual User User { get; set; }
          public virtual Book Book { get; set; }
     }
}
