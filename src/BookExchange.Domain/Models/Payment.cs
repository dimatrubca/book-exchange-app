using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Models
{
     public enum PaymentStatus { 
          InProcess, Cancelled, Failed, Executed
     }

     public class Payment : BaseEntity
     {
          public int UserId { get; set; }
          public decimal Amount { get; set; }
          public string PaymentServiceReference { get; set; }
          public PaymentStatus PaymentStatus { get; set; }

          public User User { get; set; }
     }
}
