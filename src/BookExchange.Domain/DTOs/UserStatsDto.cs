using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class UserStatsDto
     {
          public int Wishlist { get; set; }
          public int Bookshelf { get; set; }
          public int Requests { get; set; }
          public int Requested { get; set; }
          public int Awaiting { get; set; }
          public int Sent { get; set; }
     }
}
