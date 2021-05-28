using BookExchange.Application.Common.Exceptions;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Request.Commands
{
     public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, Domain.Models.Request>
     {
          private readonly IRequestRepository _requestRepository;
          private readonly IDealRepository _dealRepository;

          public UpdateRequestCommandHandler(IRequestRepository requestRepository, IDealRepository dealRepository)
          {
               _requestRepository = requestRepository;
               _dealRepository = dealRepository;
          }

          public Task<Domain.Models.Request> Handle(UpdateRequestCommand command, CancellationToken cancellationToken)
          {
               var request = _requestRepository.GetById(command.Id);

               if (command == null)
               {
                    throw new NotFoundException(nameof(Domain.Models.Request), command.Id);
               }

               if (command.Status == RequestStatus.Pending && command.Status == RequestStatus.Rejected)
               {
                    request.Status = command.Status;
                    _requestRepository.SaveAll();
               } else if (request.Status == RequestStatus.Pending && command.Status == RequestStatus.Approved)
               {
                    var deal = new Deal
                    {
                         BookTakerId = request.UserId,
                         PostId = request.PostId,
                         DealStatus = DealStatus.InDelivery,
                    };

                    _dealRepository.Add(deal);
                    _dealRepository.SaveAll();

                    request.Status = command.Status;
                    _requestRepository.SaveAll();
               }
 

               return Task.FromResult(request);
          }
     }
}
