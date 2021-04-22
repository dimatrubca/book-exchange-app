using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Commands
{
     public class DeleteBookByIdCommand : IRequest<Unit>
     {
          public int Id { get; set; }
     }
}
