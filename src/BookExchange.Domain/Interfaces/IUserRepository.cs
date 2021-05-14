using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Interfaces
{
     public interface IUserRepository : IRepositoryBase<User>
     {
          public User GetUserByIdentityId(string id);
     }
}
