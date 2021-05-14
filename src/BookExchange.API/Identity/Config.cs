using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.API.Identity
{
     public static class Config
     {
          public static IEnumerable<IdentityResource> IdentityResources =>
              new List<IdentityResource>
              {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResources.Address(),
                new IdentityResource("roles", "User Roles", new List<string> { "role" })
              };


          public static IEnumerable<ApiScope> ApiScopes =>
              new List<ApiScope>
              {
                new ApiScope("bookApi", "BookExchange Web API")
              };

          public static List<ApiResource> ApiResources =>

               new List<ApiResource>
               {
                    new ApiResource("bookApiResource", "BookExchange Web API Resoure")
                    {
                         Scopes = { "bookApi" },
                         UserClaims = {
                              JwtClaimTypes.Role,
                              JwtClaimTypes.Name,
                              JwtClaimTypes.GivenName,
                              JwtClaimTypes.FamilyName,
                              JwtClaimTypes.Email,
                              JwtClaimTypes.PhoneNumber,
                              JwtClaimTypes.Address,
                              JwtClaimTypes.Id
                         }
                    }
               };
          

          public static IEnumerable<Client> Clients =>
              new List<Client>
              {
                new Client
                {
                      ClientId = "client",
                      ClientName = "React Client",
                      RequireClientSecret = false,
                      AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                      AllowedScopes =
                      {
                          IdentityServerConstants.StandardScopes.OpenId,
                          IdentityServerConstants.StandardScopes.Profile,
                         "roles",
                          "bookApi"
                      }
                }
              };
     }
}
