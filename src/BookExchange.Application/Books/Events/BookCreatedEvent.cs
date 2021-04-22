using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Application.Books.Events
{
     public class BookCreatedEvent : INotification
     {
          [Required]
          public int Id { get; set; }
          public string Title { get; set; }
          public List<string> Authors { get; set; }
          public string ShortDescription { get; set; }
          public string Description { get; set; }
     }
}
