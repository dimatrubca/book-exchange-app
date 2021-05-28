using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class WishlistRepository : RepositoryBase<Wishlist>, IWishlistRepository
     {
          public WishlistRepository(BookExchangeDbContext context) : base(context)
          {
          }
     }
}
