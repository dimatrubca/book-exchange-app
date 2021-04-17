using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class PostReview : Review
     {
          public int PostId { get; set; }
          public virtual Post Post { get; set; }
     }
}
