using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Filter
{
     public class PaginationRequestFilter : PaginationFilter
     {
          public LogicalOperator FilterLogicalOperator { get; set; }
     }
}
