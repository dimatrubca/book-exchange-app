using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Application.Common.Exceptions
{
     class ApiExceptionFilter : ExceptionFilterAttribute
     {
          public override void OnException(ExceptionContext context)
          {
               if (context.Exception is ApiException apiException)
               {
                    context.Result = new ObjectResult(apiException.Message) { StatusCode = (int)apiException.Code };
               }
          }
     }
}
