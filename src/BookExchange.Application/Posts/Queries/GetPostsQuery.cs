using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Application.Posts.Queries
{
     public class GetPostsQuery : PaginatedQueryBase<PostDto>
     {
          public int? PostedById { get; set; }
          public int? ConditionId { get; set; }
          public int? BookId { get; set; }
          public PostStatus? Status { get; set; } = PostStatus.Enabled;

     }
}
