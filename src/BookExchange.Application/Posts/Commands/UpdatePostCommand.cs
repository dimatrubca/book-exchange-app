using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Application.Posts.Commands
{
     public class UpdatePostCommand : IRequest<Post>
     {
          [Required]
          public int Id { get; set; }
          public int? ConditionId { get; set; }
          public PostStatus? Status { get; set; }
     }
}
