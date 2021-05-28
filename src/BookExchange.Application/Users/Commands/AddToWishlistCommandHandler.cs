using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Commands
{
     public class AddToWishlistCommandHandler : IRequestHandler<AddToWishlistCommand, Wishlist>
     {
          private readonly IWishlistRepository _wishlistRepository;

          public AddToWishlistCommandHandler(IWishlistRepository wishlistRepository)
          {
               _wishlistRepository = wishlistRepository;
          }

          public Task<Wishlist> Handle(AddToWishlistCommand request, CancellationToken cancellationToken)
          {
               var predicates = new List<Expression<Func<Wishlist, bool>>>();

               predicates.Add(x => x.BookId == request.BookId);
               predicates.Add(x => x.UserId == request.UserId);

               var list = _wishlistRepository.GetAllByConditions(predicates, null, Domain.Filter.LogicalOperator.And);
               if (list.Count != 0) {
                    return Task.FromResult(list.First());
               }

               Wishlist wishlist = new Wishlist
               {
                    UserId = request.UserId,
                    BookId = request.BookId
               };

               _wishlistRepository.Add(wishlist);
               _wishlistRepository.SaveAll();

               return Task.FromResult(wishlist);
          }
     }
}
