using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Categories.Commands
{
     public class DeleteCategoryCommand : IRequest<Unit>
     {
          public int Id { get; set; }
     }
}
