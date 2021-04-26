using BookExchange.Domain.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Queries
{
     public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApplicationUser>
     {
          public Task<ApplicationUser> Handle(GetUserQuery request, CancellationToken cancellationToken)
          {
               throw new NotImplementedException();
          }
     }
}
