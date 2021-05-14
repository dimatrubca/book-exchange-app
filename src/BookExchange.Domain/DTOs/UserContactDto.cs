using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class UserContactDto
     {
          public int Id { get; set; }
          public string PhoneNumber { get; set; }
          public string Email { get; set; }
          public string ZipCode { get; set; }
          public string City { get; set; }
          public string Region { get; set; }
          public string StreetAddress { get; set; }
     }
}
