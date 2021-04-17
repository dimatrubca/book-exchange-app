using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class UserRepository : RepositoryBase<User>, IUserRepository
     {
          public UserRepository(DbContext context) : base(context)
          {
          }
     }
}
