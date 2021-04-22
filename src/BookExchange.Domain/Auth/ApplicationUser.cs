using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Auth
{
     public class ApplicationUser : IdentityUser<int>, IUser<int>
     {

     }
}
