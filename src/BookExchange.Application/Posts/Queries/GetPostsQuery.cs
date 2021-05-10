using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Application.Posts.Queries
{
     public class GetPostsQuery : IRequest<List<Post>>
     {
          public int? PostedById { get; set; }
          public int? ConditionId { get; set; }
          public int? BookId { get; set; }
          public PostStatus? Status { get; set; } = PostStatus.Enabled;

     }
}
