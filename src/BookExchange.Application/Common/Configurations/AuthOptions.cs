using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Application.Common.Configurations
{
     public class AuthOptions
     {
          public const string Auth = "AuthOptions";
          public string SecretKey { get; set; }
          public string Issuer { get; set; }
          public string Audience { get; set; }
          public int TokenLifetime { get; set; }

          public SymmetricSecurityKey GetSymmetricSecurityKey()
          {
               return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
          }
     }
}
