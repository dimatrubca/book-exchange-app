using AutoMapper;
using BookExchange.Application.Common.Exceptions;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using IdentityModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
     {
          private readonly IMapper _mapper;
          private readonly IHttpContextAccessor contextAccessor;
          private readonly IUserRepository _userRepository;

          public CreateUserCommandHandler(IMapper mapper, IHttpContextAccessor accessor, IUserRepository userRepository)
          {
               _mapper = mapper;
               contextAccessor = accessor;
               _userRepository = userRepository;
          }

          public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
          {
               var claims = contextAccessor.HttpContext.User.Claims;

               string identityId = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Id).Value;
               string email = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Email).Value;
               string username = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Name).Value;

               if (CheckUserWithUsernameExists(username))
               {
                    throw new BadRequestException($"User with username = {username} already exists");
               }

               if (CheckUserWithEmailExists(email))
               {
                    throw new BadRequestException($"User with email = {email} already exists");
               }

               var user = new User
               {
                    IdentityId = identityId,
                    Username = username,
                    UserContact = new UserContact
                    {
                         Email = email
                    }
               };

               _userRepository.Add(user);
               _userRepository.SaveAll();

               return user;
          }

          public bool CheckUserWithEmailExists(string email)
          {
               return _userRepository.GetAllByConditionWithInclude(u => u.UserContact.Email == email, u => u.UserContact).Count != 0;
          }

          public bool CheckUserWithUsernameExists(string username)
          {
               return _userRepository.GetAllByCondition(u => u.Username == username).Count != 0;
          }
     }
}
