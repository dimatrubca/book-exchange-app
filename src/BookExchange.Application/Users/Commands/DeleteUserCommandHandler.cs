using BookExchange.Application.Common.Exceptions;
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
     public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
     {
          private readonly IUserRepository _userRepository;

          public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
          {
               var user = _userRepository.Delete(request.Id);

               if (user == null)
               {
                    throw new NotFoundException(nameof(user), request.Id);
               }

               _userRepository.SaveAll();
               return Task.FromResult(Unit.Value);
          }
     }
}
