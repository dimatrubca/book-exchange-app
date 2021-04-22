using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
     {
          private readonly DbContext _context;
          private readonly DbSet<T> _entitites;

          public RepositoryBase(DbContext context)
          {
               this._context = context;
               _entitites = context.Set<T>();
          }

          public List<T> GetAll()
          {
               return _entitites.ToList();
          }

          public List<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties) {
               return _entitites.IncludeMultiple(includeProperties)
                    .ToList();
          }


          public List<T> GetAllByCondition(Expression<Func<T, bool>> predicate)
          {
               return _entitites.Where(predicate).ToList();
          }

          public List<T> GetAllByConditionWithInclude(Expression<Func<T, bool>> predicate,
               params Expression<Func<T, object>>[] includeProperties)
          {
               return _entitites.IncludeMultiple(includeProperties).Where(predicate).ToList();
          }

          public T GetById(int id)
          {
               return _entitites.SingleOrDefault(e => e.Id == id);
          }

          public T GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includeProperties) {
               return _entitites.IncludeMultiple(includeProperties).SingleOrDefault(e => e.Id == id);
          }


          public void Add(T entity)
          {
               if (entity == null) {
                    throw new ArgumentNullException("entity");
               }
               _entitites.Add(entity);
          }

          public T Delete(int id)
          {
               T entity = _entitites.SingleOrDefault(e => e.Id == id);

               if (entity == null)
               {
                    return null;
               }

               _entitites.Remove(entity);

               return entity;
          }

          public void Update(T entity)
          {
               if (entity == null) 
               {
                    throw new ArgumentNullException("entity");
               }
               _context.Entry(entity).State = EntityState.Modified; 
          }

          public bool SaveAll()
          {
               return _context.SaveChanges() >= 0;
          }

          public void SaveAllWithIdentityInsert()
          {
               _context.SaveChangesWithIdentityInsert<T>();
          }

     }
}
