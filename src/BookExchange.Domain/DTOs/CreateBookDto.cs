using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Domain.DTOs
{
     class CreateBookDto
     {
          [Required]
          public string Title { get; set; }

          [Required]
          [StringLength(13, MinimumLength = 10, ErrorMessage = "Invalid ISBN length")]
          public string ISBN { get; set; }
          public string Description { get; set; }
          public string Publisher { get; set; }
          public string PublishedOn { get; set; }

     }
}
