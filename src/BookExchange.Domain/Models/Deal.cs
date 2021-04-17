using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class Deal : BaseEntity
     {
          public int PostId { get; set; }
          public int BookTakerId { get; set; }
          public DateTime TimeAdded { get; set; }

          public virtual Post Post { get; set; }
          public virtual User BookTaker { get; set; }
     }
}
