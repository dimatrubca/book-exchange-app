using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BookExchange.Application.Common.Exceptions
{
     public class DeleteFailureException : ApiException
     {
          public DeleteFailureException(string name, object key)
               : base(HttpStatusCode.BadRequest, $"Entity \"{name}\" ({key}) was not found")
          {
          }
     }
}
