using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class Author : BaseEntity
     {
          public string Name { get; set; }
          public virtual ICollection<Book> Books { get; set; }
     }
}
