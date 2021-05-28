using BookExchange.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Queries
{
     public class GetUserStatsQuery : IRequest<UserStatsDto>
     {
          public int UserId { get; set; }
     }
}
