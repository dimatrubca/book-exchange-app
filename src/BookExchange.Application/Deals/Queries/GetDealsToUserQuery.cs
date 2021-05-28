using BookExchange.Domain.DTOs;
using BookExchange.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Deals.Queries
{
     public class GetDealsToUserQuery : PaginatedQueryBase<DealDto>
     {
          public int UserId { get; set; }
     }
}
