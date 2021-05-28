using BookExchange.Domain.Interfaces;
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
     public class GetTopUsersQueryHandler : IRequestHandler<GetTopUsersQuery, List<User>>
     {
          private readonly IUserRepository _userRepository;

          public GetTopUsersQueryHandler(IUserRepository userRepository)
          {
               _userRepository = userRepository;
          }

          public Task<List<User>> Handle(GetTopUsersQuery request, CancellationToken cancellationToken)
          {
               var users = _userRepository.GetTopUsers(request.Amount);

               return Task.FromResult(users);
          }
     }
}
