using BookExchange.Domain.DTOs;
using BookExchange.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.WishList.Queries
{
     public class GetUserWishlistQuery : PaginatedQueryBase<WishListDto>
     {
     }
}
