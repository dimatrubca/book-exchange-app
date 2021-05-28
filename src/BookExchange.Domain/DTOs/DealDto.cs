using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class DealDto
     {
          public int PostId { get; set; }
          public int BookTakerId { get; set; }
          public string DealStatus { get; set; }

          public virtual PostDto Post { get; set; }
          public virtual UserDto BookTaker { get; set; }
     }
}
