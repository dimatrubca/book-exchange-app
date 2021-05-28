using Microsoft.Extensions.Configuration;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.API.Utils
{
     public static class PaymentUtils
     {
          public static APIContext GetApiContext(IConfiguration configuration)
          {
               var _payPalConfig = new Dictionary<string, string>()
                        {
                            { "clientId" , configuration.GetSection("paypal:settings:clientId").Value },
                            { "clientSecret", configuration.GetSection("paypal:settings:clientSecret").Value },
                            { "mode", configuration.GetSection("paypal:settings:mode").Value },
                        };

               var accessToken = new OAuthTokenCredential(_payPalConfig).GetAccessToken();
               var apiContext = new APIContext(accessToken);

               return apiContext;
          }
     }
}
