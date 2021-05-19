using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class PostDto
     {
          public int Id { get; set; }
          public string Status { get; set; }
          public int BookId { get; set; }
          public int PostedById { get; set; }
          public int ConditionId { get; set; }
          public DateTime TimeAdded { get; set; }
          public UserDto PostedBy { get; set; }
          public ConditionDto Condition { get; set; }
          public BookDto Book { get; set; }
     }
}
