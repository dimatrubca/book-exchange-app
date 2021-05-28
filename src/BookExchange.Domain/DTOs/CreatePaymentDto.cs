using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class CreatePaymentDto
     {
          public decimal Amount { get; set; }
          public int UserId { get; set; }
     }
}
