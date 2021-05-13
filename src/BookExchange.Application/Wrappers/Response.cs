using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Wrappers
{
     public class Response<T>
     {
          public Response()
          { 
          }

          public Response(T data)
          {
               Data = data;
          }

          public T Data { get; set; }
     }
}
