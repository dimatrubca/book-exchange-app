using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     public class AddToWishlistCommand : IRequest<Wishlist>
     {
          public int UserId { get; set; }
          public int BookId { get; set; }
     }
}
