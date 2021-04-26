using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class LoginUserDto
     {
          public string Username { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
     }
}
