using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.IdentityServer.Models
{
     public class ApplicationIdentityUser : IdentityUser
     {
          [PersonalData]
          public string FirstName { get; set; }
          [PersonalData]
          public string LastName { get; set; }
          public string Address { get; set; }

          public bool IsAdmin { get; set; }
     }
}
