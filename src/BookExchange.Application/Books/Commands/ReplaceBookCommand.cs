using BookExchange.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Application.Books.Commands
{
     public class ReplaceBookCommand : IRequest<Book>
     {
          public int Id { get; set; }
          [Required]
          public string Title { get; set; }
          [Required]
          [StringLength(13, ErrorMessage = "Invalid ISBN length")]
          public string ISBN { get; set; }
          public string ShortDescription { get; set; }
          public string Description { get; set; }
          public string Publisher { get; set; }
          public int? PageCount { get; set; }
          public DateTime? PublishedOn { get; set; }
          public List<int> AuthorsIds { get; set; }
          public List<int> CategoriesIds { get; set; }
          public IFormFile Thumbnail { get; set; }
          public IFormFile Image { get; set; }
     }
}
