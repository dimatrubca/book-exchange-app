using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Extensions
{
     public static class QueriableExtensions
     {
          public static IQueryable<T> Page<T>(this IOrderedQueryable<T> query, int page, int pageSize = 10)
          {
               return query.Skip((page - 1) * pageSize).Take(pageSize);
          }

          public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query,
               params Expression<Func<T, object>>[] includes) where T : class
          {
               if (includes != null)
               {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
               }

               return query;
          }
     }
}
