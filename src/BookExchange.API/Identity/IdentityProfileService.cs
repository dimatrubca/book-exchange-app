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
using IdentityUser = BookExchange.API.Identity.IdentityUser;

namespace BookExchange.API.Identity
{
     public class IdentityProfileService : IProfileService
     {
          private readonly IUserClaimsPrincipalFactory<IdentityUser> _claimsFactory;
          private readonly UserManager<IdentityUser> _userManager;

          public IdentityProfileService(IUserClaimsPrincipalFactory<IdentityUser> claimsFactory, UserManager<IdentityUser> userManager)
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
               /*claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));
               claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));
               if (user.PhoneNumber != null) claims.Add(new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber));
               if (user.Address != null) claims.Add(new Claim(JwtClaimTypes.Address, user.Address));*/

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
