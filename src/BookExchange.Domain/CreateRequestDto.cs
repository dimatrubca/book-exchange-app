using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain
{
     public class CreateRequestDto
     {
          public int UserId { get; set; }
          public int PostId { get; set; }
     }
}
