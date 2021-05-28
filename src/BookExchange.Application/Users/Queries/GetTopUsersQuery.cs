using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Queries
{
     public class GetTopUsersQuery : IRequest<List<User>>
     {
          public int Amount { get; set; }
     }
}
