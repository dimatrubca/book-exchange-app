using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class FinishPaymentDto
     {
          public string PayerId { get; set; }
          public string PaymentId { get; set; }
     }
}
