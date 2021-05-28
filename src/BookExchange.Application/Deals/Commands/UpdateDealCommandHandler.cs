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

namespace BookExchange.Application.Deals.Commands
{
     public class UpdateDealCommandHandler : IRequestHandler<UpdateDealCommand, Deal>
     {
          private readonly IDealRepository _dealRepository;

          public Task<Deal> Handle(UpdateDealCommand command, CancellationToken cancellationToken)
          {
               var deal = _dealRepository.GetById(command.Id);

               if (deal == null)
               {
                    throw new NotFoundException(nameof(Domain.Models.Request), command.Id);
               }

               deal.DealStatus = command.DealStatus;
               _dealRepository.SaveAll();

               return Task.FromResult(deal);
          }
     }
}
