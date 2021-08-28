using BookExchange.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.IdentityServer
{
     public static class IdentityDataSeeder
     {
          public static void SeedAll(UserManager<ApplicationIdentityUser> userManager) {
               SeedUsers(userManager);
          }

          public static void SeedUsers(UserManager<ApplicationIdentityUser> userManager)
          {
               if (userManager.FindByEmailAsync("dimatrubca@gmail.com").Result == null)
               {
                    ApplicationIdentityUser user = new ApplicationIdentityUser
                    {
                         UserName = "dimatrubca",
                         Email = "dimatrubca@gmail.com",
                         IsAdmin = true,
                         Id="1"
                    };

                    IdentityResult result = userManager.CreateAsync(user, "mysecreT1!").Result;

                    if (result.Succeeded)
                    {
                         userManager.AddToRoleAsync(user, "admin").Wait();
                    }
               }

               if (userManager.FindByEmailAsync("dimatrubca@outlook.com").Result == null)
               {
                    ApplicationIdentityUser user = new ApplicationIdentityUser
                    {
                         UserName = "valentin341",
                         Email = "dimatrubca@outlook.com",
                    };

                    IdentityResult result = userManager.CreateAsync(user, "mysecreT1!").Result;
               }

               if (userManager.FindByEmailAsync("igor431thelast@gmail.com").Result == null)
               {
                    ApplicationIdentityUser user = new ApplicationIdentityUser
                    {
                         UserName = "igor431",
                         Email = "igor431@outlook.com",
                    };

                    IdentityResult result = userManager.CreateAsync(user, "mysecreT1!").Result;
               }
          }
     }
}
