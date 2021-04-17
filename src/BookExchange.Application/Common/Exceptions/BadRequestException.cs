using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BookExchange.Application.Common.Exceptions
{
     class BadRequestException : ApiException
     {
          public BadRequestException(HttpStatusCode code, string message) : base(code, message)
          {
          }
     }
}
