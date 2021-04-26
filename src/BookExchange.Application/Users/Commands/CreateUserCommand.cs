using BookExchange.Domain.Auth;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Application.Users.Commands
{
     public class CreateUserCommand : IRequest<ApplicationUser>
     {
          [Required]
          [StringLength(50, MinimumLength = 3)]
          public string UserName { get; set; }

          [Required]
          [StringLength(50)]
          [EmailAddress]
          public string Email { get; set; }

          [Required]
          [StringLength(50, MinimumLength = 5)]

          public string Password { get; set; }
          [Required]
          [StringLength(50, MinimumLength = 5)]

          public string ConfirmPassword { get; set; }

          public int FirstName { get; set; }
          public int LastName { get; set; }
     }
}
