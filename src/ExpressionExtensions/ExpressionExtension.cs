using System;
using System.Linq.Expressions;

namespace ExpressionExtensions
{
    public static class ExpressionExtension
    {
        public static Expression<Func<T,bool>> And<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(exp1.Body, exp2.Body), exp1.Parameters);
        }

        public static Expression<Func<T, bool>> OR<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(exp1.Body, exp2.Body), exp1.Parameters);
        }

        //
    }
}
