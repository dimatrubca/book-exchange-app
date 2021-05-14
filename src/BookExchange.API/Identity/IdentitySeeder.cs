using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.API.Identity
{
     public static class IdentitySeeder
     {
          public static void SeedAll(RoleManager<IdentityRole> roleManager) {
               CreateRoles(roleManager);
          }

          public static void CreateRoles(RoleManager<IdentityRole> roleManager)
          {

               if (roleManager.RoleExistsAsync("Admin").Result)
               {
                    var role = roleManager.FindByNameAsync("Admin").Result;
                    roleManager.DeleteAsync(role).Wait();
               }

               if (roleManager.RoleExistsAsync("Basic").Result)
               {
                    var role = roleManager.FindByNameAsync("Basic").Result;
                    roleManager.DeleteAsync(role).Wait();


               if (!roleManager.RoleExistsAsync("admin").Result)
               {
                    roleManager.CreateAsync(new IdentityRole { Name = "Admin" }).Wait();
               }

               if (!roleManager.RoleExistsAsync("user").Result)
               {
                    roleManager.CreateAsync(new IdentityRole { Name = "Basic" }).Wait();
               }


               }

          }
     }
}
