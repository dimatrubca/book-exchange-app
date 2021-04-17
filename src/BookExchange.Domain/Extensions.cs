using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BookExchange.Domain
{
     public static class Extensions
     {
          public static Func<T, bool> AndAlso<T>(
              this Func<T, bool> predicate1,
              Func<T, bool> predicate2)
          {
               return arg => predicate1(arg) && predicate2(arg);
          }

          public static Func<T, bool> OrElse<T>(
              this Func<T, bool> predicate1,
              Func<T, bool> predicate2)
          {
               return arg => predicate1(arg) || predicate2(arg);
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
