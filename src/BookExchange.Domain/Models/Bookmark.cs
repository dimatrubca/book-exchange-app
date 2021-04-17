using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class Bookmark
     {
          public int UserId { get; set; }
          public int PostId { get; set; }

          public virtual User User { get; set; }
          public virtual Post Post { get; set; }
     }
}
