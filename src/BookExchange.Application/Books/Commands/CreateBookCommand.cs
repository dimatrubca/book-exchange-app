using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Books.Commands
{
     public class CreateBookCommand : IRequest<Book>
     {
          [Required]
          public string Title { get; set; }
          [Required]
          [StringLength(13, MinimumLength=13, ErrorMessage = "Invalid ISBN length")]
          public string ISBN { get; set; }
          public string ShortDescription { get; set; }
          public string Description { get; set; }
          public string Publisher { get; set; }
          public int? PageCount { get; set; }
          public DateTime PublishedOn { get; set; }
          public List<int> AuthorsIds { get; set; }
          public List<int> CategoriesIds { get; set; }

     }
}
