using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BookExchange.Application.Common.Exceptions
{
     public class ApiException : Exception
     {
          public HttpStatusCode Code { get; }

          public ApiException(HttpStatusCode code, string message) : base(message)
          {
               Code = code;
          }
     }
}
