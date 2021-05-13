using AutoMapper;
using BookExchange.Application.Common.Exceptions;
using BookExchange.Application.Common.Extensions;
using BookExchange.Domain.Auth;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
     {
          private readonly IMapper _mapper;
          private readonly IHttpContextAccessor _accessor;
          private readonly IUserRepository _userRepository;

          public CreateUserCommandHandler(IMapper mapper, IHttpContextAccessor accessor, IUserRepository userRepository)
          {
               _mapper = mapper;
               _accessor = accessor;
               _userRepository = userRepository;
          }

          public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
          {
               var contextUser = _accessor.HttpContext.User;

               string identityId = contextUser.FindFirst(ClaimTypes.NameIdentifier).Value;
               string email = contextUser.FindFirst(ClaimTypes.Email).Value;
               string username = contextUser.FindFirst(ClaimTypes.Name).Value;
               string firstName = contextUser.Identity.FirstName();
               string lastName = contextUser.Identity.LastName();

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
                    FirstName= firstName,
                    LastName= lastName,
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
