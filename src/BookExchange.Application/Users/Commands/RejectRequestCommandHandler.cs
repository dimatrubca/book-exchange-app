using BookExchange.Domain.Models;
using BookExchange.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     public class RejectRequestCommandHandler : IRequestHandler<RejectRequestCommand, Unit>
     {
          private readonly IUserRepository _userRepository;
          private readonly IPostRepository  _postRepository;

          public Task<Unit> Handle(RejectRequestCommand request, CancellationToken cancellationToken)
          {
               throw new NotImplementedException();
          }
     }
}
