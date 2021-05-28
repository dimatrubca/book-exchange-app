using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     public class RejectRequestCommand : IRequest<Unit>
     {
          public int UserId { get; set; }
          public int PostId { get; set; }
     }
}
