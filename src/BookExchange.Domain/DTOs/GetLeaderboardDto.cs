using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     public class GetLeaderboardDto
     {
          [Required]
          [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
          public int Amount { get; set; }
     }
}
