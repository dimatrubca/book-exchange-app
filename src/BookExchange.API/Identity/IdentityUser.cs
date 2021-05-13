using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.API.Identity
{
     public class IdentityUser : Microsoft.AspNetCore.Identity.IdentityUser
     {
          [PersonalData]
          public string FirstName { get; set; }
          [PersonalData]
          public string LastName { get; set; }
     }
}
