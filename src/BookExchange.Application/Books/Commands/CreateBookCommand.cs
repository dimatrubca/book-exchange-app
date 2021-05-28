using BookExchange.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
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
          [StringLength(13, ErrorMessage = "Invalid ISBN length")]
          public string ISBN { get; set; }
          public string ShortDescription { get; set; }
          public string Description { get; set; }
          public string Publisher { get; set; }
          public int? PageCount { get; set; }
          public int? PublishedYear { get; set; }
          public List<int> AuthorsId { get; set; }
          public List<int> CategoriesId { get; set; }
          public IFormFile Image { get; set; }

     }
}
