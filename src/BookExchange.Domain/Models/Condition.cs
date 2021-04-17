using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class Condition : BaseEntity
     {
          public string Label { get; set; }

          public string Description { get; set; }
     }
}
