using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Posts.Queries
{
     public class GetPostConditionsQueryHandler : IRequestHandler<GetPostConditionsQuery, List<string>>
     {
          public Task<List<string>> Handle(GetPostConditionsQuery request, CancellationToken cancellationToken)
          {
               var conditions = Enum.GetNames(typeof(Condition)).ToList();

               return Task.FromResult(conditions);
          }
     }
}
