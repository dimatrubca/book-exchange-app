using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class PostRepository : RepositoryBase<Post>, IPostRepository
     {
          public PostRepository(DbContext context) : base(context)
          {
          }
     }
}
