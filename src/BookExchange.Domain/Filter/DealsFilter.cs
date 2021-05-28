using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Filter
{
     public class DealsFilter : PaginationFilter
     {
          public DealStatus? DealStatus { get; set; }
          public int? PostId { get; set; }
          public int? BookTakerId { get; set; }
          public int? BookGiverId { get; set; }
     }
}
