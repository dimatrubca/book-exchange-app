using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class UserDto
     {
          public int Id { get; set; }
          public string Username { get; set; }
          public int FirstName { get; set; }
          public int LastName { get; set; }
          public decimal Points { get; set; }
     }
}
