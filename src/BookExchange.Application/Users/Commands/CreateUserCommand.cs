using BookExchange.Domain.Auth;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Application.Users.Commands
{
     public class CreateUserCommand : IRequest<User>
     {
     }
}
