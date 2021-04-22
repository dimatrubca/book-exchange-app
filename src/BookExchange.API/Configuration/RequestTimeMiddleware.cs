using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.API.Configuration
{
     public class RequestTimeMiddleware
     {
          private readonly RequestDelegate _next;
          private readonly ILogger _logger;

          public RequestTimeMiddleware(RequestDelegate next, ILogger logger)
          {
               _next = next;
               _logger = logger;
          }

          // only for lesson 2 
          // TODO: delete after presenting
          public async Task Invoke(HttpContext context)
          {
               context.Items["RequestTime"] = DateTime.Now;
               await this._next.Invoke(context);
               _logger.LogInformation("Request time was set to " + context.Items["RequestTime"]);
          }
     }
}
