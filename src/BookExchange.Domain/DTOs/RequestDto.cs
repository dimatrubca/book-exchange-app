using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class RequestDto
     {
          public int Id { get; set; }
          public int PostId { get; set; }
          public int UserId { get; set; }
          public string Status { get; set; }
          public virtual PostDto Post { get; set; }
          public virtual UserDto User { get; set; }
     }
}
