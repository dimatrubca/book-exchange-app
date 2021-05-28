using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Interfaces
{
     public interface IDealRepository : IRepositoryBase<Deal>
     {
          public PagedResponse<DealDto> GetDealsFromUser(int userId, PaginationFilter filter);
          public PagedResponse<DealDto> GetDealsToUser(int userId, PaginationFilter filter);
     }
}
