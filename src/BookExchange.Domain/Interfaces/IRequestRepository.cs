using AutoMapper;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;

namespace BookExchange.Domain.Interfaces
{
     public interface IRequestRepository : IRepositoryBase<Request>
     {
          public PagedResponse<RequestDto> GetRequestsToUser(int userId, PaginationFilter filter);

          public PagedResponse<RequestDto> GetRequestFromUser(int userId, PaginationFilter filter);
     }
}
