using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class RegisterUserDto
     {
          public string Email { get; set; }
          public string Username { get; set; }
          public string Password { get; set; }
          public string Name { get; set; }
     }
}
