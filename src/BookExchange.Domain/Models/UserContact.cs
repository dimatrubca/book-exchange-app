using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class UserContact : BaseEntity
     {
          public string PhoneNumber { get; set; }
          public string Email { get; set; }
          public string ZipCode { get; set; }
          public string Country { get; set; }
          public string City { get; set; }
          public string Region { get; set; }
          public string StreetAddress { get; set; }

          public int UserId { get; set; }
          public virtual User User { get; set; }
     }
}
