using BookExchange.Domain.Auth;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Application.Users.Queries
{
     public class GetUserQuery : IRequest<User>
     {
          public int Id { get; set; }
     }
}
