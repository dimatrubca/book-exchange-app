using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
     {
          public Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
          {
               throw new NotImplementedException();
          }
     }
}
