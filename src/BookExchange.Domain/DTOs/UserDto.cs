using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class UserDto
     {
          public int Id { get; set; }
          public string Username { get; set; }
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public decimal Points { get; set; }
          public UserContactDto UserContact { get; set; }
     }
}
