using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     public class RequestPostCommand : IRequest<Domain.Models.Request>
     {
          public int PostId { get; set; }
          public int UserId { get; set; }
     }
}
