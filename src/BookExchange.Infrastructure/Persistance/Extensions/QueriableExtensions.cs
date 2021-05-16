using BookExchange.Domain.Filter;
using BookExchange.Domain.Models;
using BookExchange.Domain;
using BookExchange.Domain.Wrappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using System.Reflection;
using System.Linq.Dynamic.Core;

namespace BookExchange.Infrastructure.Persistance.Extensions
{
     public static class QueriableExtensions
     {
          public static IQueryable<T> Page<T>(this IQueryable<T> query, int page, int pageSize = 10)
          {
               return query.Skip((page - 1) * pageSize).Take(pageSize);
          }
          
          public static PagedResponse<List<TDto>> CreatePaginatedResponse<TEntity, TDto>(this IQueryable<TEntity> query, 
               List<Expression<Func<TEntity, bool>>> predicates, List<Expression<Func<TEntity, object>>> includes, PaginationRequestFilter paginationFilter, IMapper mapper) where TEntity : class
          {
               query = query.IncludeMultiple(includes.ToArray());

               int total = query.Count();

               query = query.Filter(predicates, paginationFilter.FilterLogicalOperator);

               query = query.Sort(paginationFilter.SortBy, paginationFilter.SortDirection);

               query = query.Page(paginationFilter.PageNumber, paginationFilter.PageSize);


               var listResult = mapper.Map<List<TDto>>(query.ToList());

               return new PagedResponse<List<TDto>>(listResult, paginationFilter.PageNumber, paginationFilter.PageSize)
               {
                    TotalRecords = total
               };
          }

          public static IQueryable<T> Filter<T>(this IQueryable<T> query, List<Expression<Func<T, bool>>> predicates, LogicalOperator filterLogicalOperator)
          { 
               return query.Where(BookExchange.Domain.Extensions.CombineExpresions(predicates, filterLogicalOperator));
          }

          public static IQueryable<T> Sort<T>(this IQueryable<T> query, string columnName, string sortDirection)
          {
               if (string.IsNullOrWhiteSpace(columnName))
               {
                    return query;
               }

               // sort direction???
               query = query.OrderBy(columnName);
               return query;
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

         /* public static IOrderedQueryable<TSource> OrderBy<TSource>(
            this IQueryable<TSource> query, string propertyName)
               {
                    var entityType = typeof(TSource);

                    //Create x=>x.PropName
                    var propertyInfo = entityType.GetProperty(propertyName);
                    ParameterExpression arg = Expression.Parameter(entityType, "x");
                    MemberExpression property = Expression.Property(arg, propertyName);
                    var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

                    //Get System.Linq.Queryable.OrderBy() method.
                    var enumarableType = typeof(System.Linq.Queryable);
                    var method = enumarableType.GetMethods()
                         .Where(m => m.Name == "OrderBy" && m.IsGenericMethodDefinition)
                         .Where(m => {
                              var parameters = m.GetParameters().ToList();
                   //Put more restriction here to ensure selecting the right overload                
                   return parameters.Count == 2;//overload that has 2 parameters
              }).Single();
                    //The linq's OrderBy<TSource, TKey> has two generic types, which provided here
                    MethodInfo genericMethod = method
                         .MakeGenericMethod(entityType, propertyInfo.PropertyType);

                    /*Call query.OrderBy(selector), with query and selector: x=> x.PropName
                      Note that we pass the selector as Expression to the method and we don't compile it.
                      By doing so EF can extract "order by" columns and generate SQL for it.*/
                   /* var newQuery = (IOrderedQueryable<TSource>)genericMethod
                         .Invoke(genericMethod, new object[] { query, selector });
                    return newQuery;
               }*/

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
