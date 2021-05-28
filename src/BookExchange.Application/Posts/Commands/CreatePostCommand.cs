using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Application.Posts.Commands
{
     public class CreatePostCommand : IRequest<Post>
     {
          [Required]
          public int BookId { get; set; }
          [Required]
          public int PostedById { get; set; }
          [Required]
          public Condition Condition { get; set; }
     }
}
