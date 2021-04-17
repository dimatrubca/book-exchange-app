using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class BookDto
     {
          public int Id { get; set; }
          public string Title { get; set; }
          public string ISBN { get; set; }
          public string ShortDescription { get; set; }
          public BookDetailsDto Details { get; set; }

          //public string Authors { get; set; }
          //public string Categories { get; set; }
     }
}
