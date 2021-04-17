using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class Review : BaseEntity
     {
          public int ReviewerId;
          public string Message;
          public int Rating;

          public virtual User Reviewer { get; set; }
     }    
}