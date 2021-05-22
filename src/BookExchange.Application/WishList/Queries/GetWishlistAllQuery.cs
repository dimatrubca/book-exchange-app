using BookExchange.Domain.DTOs;
using BookExchange.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.WishList.Queries
{
     public class GetWishListAllQuery : PaginatedQueryBase<WishListDto>
     {
          public int? BookId { get; set; }
          public int? UserId { get; set; }
     }
}
