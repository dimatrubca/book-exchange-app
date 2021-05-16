using AutoMapper;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookExchange.Domain.Interfaces
{
     public interface IRepositoryBase<T> where T : BaseEntity
     {
          T GetById(int id);
          public T GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includeProperties);
          List<T> GetAll();
          List<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);
          List<T> GetAllByCondition(Expression<Func<T, bool>> predicate);
          List<T> GetAllByConditions(List<Expression<Func<T, bool>>> predicate, List<Expression<Func<Book, Object>>> includes, LogicalOperator predicateLogicalOperators);
          List<T> GetAllByConditionWithInclude(Expression<Func<T, bool>> predicate,
               params Expression<Func<T, object>>[] includeProperties);
          PagedResponse<List<TDto>> GetPagedData<TDto>(List<Expression<Func<T, bool>>> predicates, 
               List<Expression<Func<T, object>>> includes, PaginationRequestFilter paginationFilter, IMapper mapper);
          bool SaveAll();
          void SaveAllWithIdentityInsert();
          void Add(T entity); // insert the item into the dbSet
          void Update(T entity);
          T Delete(int id);   // remove item from the DbSet
     }
}

