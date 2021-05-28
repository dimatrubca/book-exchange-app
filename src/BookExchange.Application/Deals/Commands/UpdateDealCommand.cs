using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Deals.Commands
{
     public class UpdateDealCommand : IRequest<Deal>
     {
          public int Id { get; set; }
          public DealStatus DealStatus { get; set; }

     }
}
