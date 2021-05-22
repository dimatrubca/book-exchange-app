using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class WishListDto
     {
          public int BookId { get; set; }
          public int UserId { get; set; }
     }
}
