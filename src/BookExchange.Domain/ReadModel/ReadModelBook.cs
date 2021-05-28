using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.ReadModel
{
     public class ReadModelBook
     {
          public int Id { get; set; }
          public string Title { get; set; }
          public List<string> Authors { get; set; }
          public List<string> Categories { get; set; }
          public string ShortDescription { get; set; }
          public string Description { get; set; }
     }
}
