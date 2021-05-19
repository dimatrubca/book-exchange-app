using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class ConditionDto
     {
          public int Id { get; set; }
          public string Label { get; set; }
          public string Description { get; set; }
     }
}
