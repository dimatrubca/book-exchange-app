using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using IdentityUser = BookExchange.API.Identity.IdentityUser;

namespace BookExchange.API.Identity
{
     public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
     {
          public AppClaimsPrincipalFactory(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
          {
          }

          public async override Task<ClaimsPrincipal> CreateAsync(IdentityUser user)
          {
               var principal = await base.CreateAsync(user);
               if (!string.IsNullOrWhiteSpace(user.FirstName))
               {
                    ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                         new Claim(ClaimTypes.GivenName, user.FirstName)
                    });
               }

               if (!string.IsNullOrWhiteSpace(user.LastName))
               {
                    ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                         new Claim(ClaimTypes.Surname, user.LastName),
                    });
               }

               return principal;
          }
     }
}
