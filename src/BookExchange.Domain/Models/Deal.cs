using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public enum DealStatus
     {
          InDelivery,
          Canceled,
          Delivered
     }

     public class Deal : BaseEntity
     {
          public int PostId { get; set; }
          public int BookTakerId { get; set; }
          public DateTime TimeAdded { get; set; }
          public DealStatus DealStatus { get; set; }

          public virtual Post Post { get; set; }
          public virtual User BookTaker { get; set; }
     }
}
