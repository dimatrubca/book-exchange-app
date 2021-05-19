using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class AuthorDto
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public List<BookDto> Books { get; set; }
     }
}
