using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Domain.Parameters
{
     public class BookParameters : RequestParameters
     {
          public string Author;
          public string Category;
          public int MinBookPageCount { get; set; }
          public int MaxBookPageCount { get; set; } = int.MaxValue;
     }
}
