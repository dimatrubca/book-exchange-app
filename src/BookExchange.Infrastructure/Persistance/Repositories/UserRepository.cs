using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class UserRepository : RepositoryBase<User>, IUserRepository
     {
          public UserRepository(DbContext context) : base(context)
          {

          }

          public User GetUserByIdentityId(string id)
          {
               return GetAllByConditionWithInclude(u => u.IdentityId == id, u => u.UserContact).Single();
          }
     }
}
