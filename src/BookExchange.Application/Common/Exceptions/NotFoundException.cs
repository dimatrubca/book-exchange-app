using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BookExchange.Application.Common.Exceptions
{
     class NotFoundException : ApiException
     {
          public NotFoundException(HttpStatusCode code, string message) : base(code, message)
          {
          }
     }
}
