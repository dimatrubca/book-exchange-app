using AutoMapper;
using BookExchange.Application.Common.Exceptions;
using BookExchange.Domain.Auth;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApplicationUser>
     {
          private readonly UserManager<ApplicationUser> _userManager;
          private readonly IMapper _mapper;

          public CreateUserCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
          {
               _userManager = userManager;
               _mapper = mapper;
          }

          public async Task<ApplicationUser> Handle(CreateUserCommand request, CancellationToken cancellationToken)
          {
               if (request.Password != request.ConfirmPassword)
               {
                    throw new BadRequestException("Confirmation password doesn't match");
               }

               var user = _mapper.Map<ApplicationUser>(request);

               // hash password, create user
               var result = await _userManager.CreateAsync(user, request.Password);

               if (!result.Succeeded)
               {
                    throw new BadRequestException(string.Join(", ", result.Errors));
               }
               return user;
          }
     }
}
