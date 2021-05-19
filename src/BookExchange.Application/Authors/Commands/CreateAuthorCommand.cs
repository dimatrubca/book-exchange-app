using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Authors.Commands
{
     public class CreateAuthorCommand : IRequest<Author>
     {
          public string Name { get; set; }
     }
}
