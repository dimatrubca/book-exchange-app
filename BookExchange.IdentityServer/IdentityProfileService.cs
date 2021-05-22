using BookExchange.IdentityServer.Models;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookExchange.IdentityServer
{
     public class IdentityProfileService : IProfileService
     {
          private readonly IUserClaimsPrincipalFactory<ApplicationIdentityUser> _claimsFactory;
          private readonly UserManager<ApplicationIdentityUser> _userManager;

          public IdentityProfileService(IUserClaimsPrincipalFactory<ApplicationIdentityUser> claimsFactory, UserManager<ApplicationIdentityUser> userManager)
          {
               _claimsFactory = claimsFactory;
               _userManager = userManager;
          }


          public async Task GetProfileDataAsync(ProfileDataRequestContext context)
          {
               var sub = context.Subject.GetSubjectId();
               var user = await _userManager.FindByIdAsync(sub);
               var principal = await _claimsFactory.CreateAsync(user);

               var claims = principal.Claims.ToList();
               claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

               claims.Add(new Claim(JwtClaimTypes.Id, user.Id));
               claims.Add(new Claim(JwtClaimTypes.Name, user.UserName));
               claims.Add(new Claim(JwtClaimTypes.Email, user.Email));

               if (user.IsAdmin)
               {
                    claims.Add(new Claim(JwtClaimTypes.Role, "admin"));
               } else
               {
                    claims.Add(new Claim(JwtClaimTypes.Role, "user"));
               }

               context.IssuedClaims = claims;
          }

          public async Task IsActiveAsync(IsActiveContext context)
          {
               var sub = context.Subject.GetSubjectId();
               var user = await _userManager.FindByIdAsync(sub);
               context.IsActive = user != null;
        }

}
}
