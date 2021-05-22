using BookExchange.IdentityServer.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.IdentityServer
{
     public class IdentityContext : IdentityDbContext<ApplicationIdentityUser>
     {
          public IdentityContext(DbContextOptions options) : base(options)
          {
          }

          protected override void OnModelCreating(ModelBuilder builder)
          {
               base.OnModelCreating(builder);

               builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "admin", NormalizedName = "admin".ToUpper() });
               builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "user", NormalizedName = "user".ToUpper() });
          }
     }
}
