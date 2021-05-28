using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class TopUserDto
     {
          public int Id { get; set; }
          public int Points { get; set; }
          public string Username { get; set; }
     }
}
