using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Filter
{
     public class PostFilter : PaginationRequestFilter
     {
          public int BookId { get; set; }
          public int PostedById { get; set; }
          public int ConditionId { get; set; }
          public int Status { get; set; }
          public DateTime TimeAdded { get; set; }
     }
}
