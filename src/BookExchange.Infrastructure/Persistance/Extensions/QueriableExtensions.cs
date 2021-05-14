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

          public static List<T> CreatePaginatedResult<T>

          public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query,
               params Expression<Func<T, object>>[] includes) where T : class
          {
               if (includes != null)
               {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
               }

               return query;
          }

          // 
          public static Task EnableIdentityInsert<T>(this DbContext context) => SetIdentityInsert<T>(context, enable: true);
          public static Task DisableIdentityInsert<T>(this DbContext context) => SetIdentityInsert<T>(context, enable: false);

          private static Task SetIdentityInsert<T>(DbContext context, bool enable)
          {
               var entityType = context.Model.FindEntityType(typeof(T));
               var value = enable ? "ON" : "OFF";
               return context.Database.ExecuteSqlRawAsync(
                   $"SET IDENTITY_INSERT {entityType.GetSchema()}.{entityType.GetTableName()} {value}");
          }

          public static void SaveChangesWithIdentityInsert<T>(this DbContext context)
          {
               using var transaction = context.Database.BeginTransaction();
               context.EnableIdentityInsert<T>();
               context.SaveChanges();
               context.DisableIdentityInsert<T>();
               transaction.Commit();
          }
     }
}
