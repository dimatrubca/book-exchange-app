using BookExchange.Application.Common.Exceptions;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using IdentityModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Queries
{
     public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, User>
     {
          private readonly IHttpContextAccessor _contextAccessor;
          private readonly IUserRepository _userRepository;


          public GetCurrentUserQueryHandler(IHttpContextAccessor contextAccessor, IUserRepository userRepository)
          {
               _contextAccessor = contextAccessor;
               _userRepository = userRepository;
          }

          public Task<User> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
          {
               string identityId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

               if (identityId == null)
               { 
                    throw new BadRequestException("User not logged in!");
               }

               User user = _userRepository.GetUserByIdentityId(identityId);

               if (user == null)
               {
                    throw new BadRequestException("Current user doesn't have a profile created");
               }

               return Task.FromResult(user);
          }
     }
}