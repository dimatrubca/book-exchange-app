using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Request.Commands
{
     public class UpdateRequestCommand : IRequest<Domain.Models.Request>
     {
          public int Id { get; set; }
          public RequestStatus Status { get; set; }
     }
}
