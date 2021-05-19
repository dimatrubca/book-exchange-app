using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Filter
{
     public class PostsFilter : PaginationRequestFilter
     {
          public bool IncludePostedBy { get; set; }
          public bool IncludeCondition { get; set; }
          public bool IncludeBook { get; set; }
          public string Status { get; set; }
          public int? BookId { get; set; }
          public int? PostedById { get; set; }
          public int? ConditionId { get; set; }
          public DateTime TimeAdded { get; set; }
     }
}
