using BookExchange.Application.Common.Configurations;
using BookExchange.Domain.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     class LogginUserCommandHandler : IRequestHandler<LogginUserCommand, string>
     {
          private readonly SignInManager<ApplicationUser> _signInManager;
          private readonly AuthOptions _authenticationOptions;

          public LogginUserCommandHandler(SignInManager<ApplicationUser> signInManager, IOptions<AuthOptions> authenticatinOptions)
          {
               _signInManager = signInManager;
               _authenticationOptions = authenticatinOptions.Value;
          }

          public async Task<string> Handle(LogginUserCommand request, CancellationToken cancellationToken)
          {
               var checkingPassword = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

               if (!checkingPassword.Succeeded)
               {
                    return null;
               }

               var signInCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
               var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _authenticationOptions.Issuer,
                    audience: _authenticationOptions.Audience,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signInCredentials
               );

               var tokenHandler = new JwtSecurityTokenHandler();
               var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

               return await Task.FromResult(encodedToken);
          }
     }
}
