using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class UpdateDealDto
     {
          public DealStatus DealStatus { get; set; }
     }
}
