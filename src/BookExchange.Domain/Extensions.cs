using BookExchange.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BookExchange.Domain
{
     public static class Extensions
     {
          public delegate Expression<Func<T, bool>> ExpressionOperation<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2);

          public static Expression<Func<T, bool>> GetTrueExpression<T>()
          {
               return a => true;
          }

          //var result = predicates.Aggregate<Expression<Func<T, bool>>, Expression< Func<T, bool>>> (GetTrueExpression<T>, (result, next) => applyOperation.Invoke(result, next));
          public static Expression<Func<T, bool>> CombineExpresions<T>(List<Expression<Func<T, bool>>> expresions, LogicalOperator combineOperator) {
               ExpressionOperation<T> applyOperator;

               switch (combineOperator) {
                    case LogicalOperator.And:
                         applyOperator = OrElse<T>;
                         break;
                    default:
                         applyOperator = AndAlso<T>;
                         break;
               };

               Expression<Func<T, bool>> result = a => true;

               foreach (var expression in expresions)
               {
                    result = applyOperator(result, expression);
               }
               return result;
          }

          public static Expression<Func<T, bool>> AndAlso<T>(
              this Expression<Func<T, bool>> expr1,
              Expression<Func<T, bool>> expr2)
          {
               var parameter = Expression.Parameter(typeof(T));

               var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
               var left = leftVisitor.Visit(expr1.Body);

               var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
               var right = rightVisitor.Visit(expr2.Body);

               return Expression.Lambda<Func<T, bool>>(
                   Expression.AndAlso(left, right), parameter);
          }

          public static Expression<Func<T, bool>> OrElse<T>(
              this Expression<Func<T, bool>> expr1,
              Expression<Func<T, bool>> expr2)
          {
               var parameter = Expression.Parameter(typeof(T));

               var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
               var left = leftVisitor.Visit(expr1.Body);

               var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
               var right = rightVisitor.Visit(expr2.Body);

               return Expression.Lambda<Func<T, bool>>(
                   Expression.OrElse(left, right), parameter);
          }



          private class ReplaceExpressionVisitor
              : ExpressionVisitor
          {
               private readonly Expression _oldValue;
               private readonly Expression _newValue;

               public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
               {
                    _oldValue = oldValue;
                    _newValue = newValue;
               }

               public override Expression Visit(Expression node)
               {
                    if (node == _oldValue)
                         return _newValue;
                    return base.Visit(node);
               }
          }
     }
}
