using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BookExchange.Application.Common.Exceptions
{
     public class NotFoundException : ApiException
     {
          public NotFoundException(string name, object key)
               : base(HttpStatusCode.NotFound, $"Entity \"{name}\" ({key}) was not found")
          {
          }
     }
}
