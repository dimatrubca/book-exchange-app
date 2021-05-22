using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Models
{
     public class BookCategory
     {
          public int BookId;
          public int CategoryId;

          public Book Book;
          public Category Category;
     }
}
