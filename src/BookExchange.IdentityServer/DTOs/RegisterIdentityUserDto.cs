using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.IdentityServer.DTOs
{
     public class RegisterIdentityUserDto
     {
          public string Username { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
          public string ConfirmPassword { get; set; }
     }
}
