using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     public class RequestPostCommandHandler : IRequestHandler<RequestPostCommand, Domain.Models.Request>
     {
          private readonly IRequestRepository _requestRepository;

          public RequestPostCommandHandler(IRequestRepository requestRepository)
          {
               _requestRepository = requestRepository;
          }

          public Task<Domain.Models.Request> Handle(RequestPostCommand request, CancellationToken cancellationToken)
          {
               var predicates = new List<Expression<Func<Domain.Models.Request, bool>>>();

               predicates.Add(x => x.PostId == request.PostId);
               predicates.Add(x => x.UserId == request.UserId);

               var list = _requestRepository.GetAllByConditions(predicates, null, Domain.Filter.LogicalOperator.And);
               if (list.Count != 0)
               {
                    return Task.FromResult(list.First());
               }

               Domain.Models.Request wishlist = new Domain.Models.Request
               {
                    UserId = request.UserId,
                    PostId = request.PostId,
                    Status = RequestStatus.Pending
               };

               _requestRepository.Add(wishlist);
               _requestRepository.SaveAll();

               return Task.FromResult(wishlist);
          }
     }
}
