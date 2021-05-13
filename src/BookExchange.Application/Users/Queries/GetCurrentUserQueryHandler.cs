using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Queries
{
     public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, User>
     {
          public Task<User> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
          {
               throw new NotImplementedException();
          }
     }
}
