using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{

     public enum DealStatus
     {
          InDelivery,
          Delivered,
          Returned,
          NotDelivered,
          NotReturned,
          Canceled // (book not sent yet)
     }
     public class DealStatusHistory
     {
          public DateTime Time { get; set; }
          public DealStatus Status { get; set; }
          public DealStatus DealId { get; set; }
          public virtual Deal Deal { get; set; }
     }
}