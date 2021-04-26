using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Application.Users.Commands
{
     public class LogginUserCommand : IRequest<string>
     {
          public string Username { get; set; }
          public string Email { get; set; }
          [Required]
          public string Password { get; set; }
     }
}
