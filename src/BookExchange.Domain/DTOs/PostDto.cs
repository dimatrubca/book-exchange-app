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
          public int BookId { get; set; }
          public int PostedById { get; set; }
          public int ConditionId { get; set; }
          public PostStatus Status { get; set; }
          public DateTime TimeAdded { get; set; }
     }
}
