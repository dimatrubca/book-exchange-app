using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
     {
          public CategoryRepository(BookExchangeDbContext context) : base(context)
          {
          }
     }
}
