using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Core.Extensions
{
    public static class TableGlobalFilterExtensions
    {
        public static readonly Dictionary<string, Func<Expression, Expression, Expression>> Operators;

        static TableGlobalFilterExtensions()
        {
            Operators = new Dictionary<string, Func<Expression, Expression, Expression>>
            {
                 { "eq", Expression.Equal },
                 { "neq", Expression.NotEqual },
                 { "lt", Expression.LessThan },
                 { "lte", Expression.LessThanOrEqual },
                 { "gt", Expression.GreaterThan },
                 { "gte", Expression.GreaterThanOrEqual },
                 { "isnull", Expression.Equal },
                 { "isnotnull", Expression.NotEqual },
                 { "startswith", CreateStartsWithExpression },
                 { "endswith", CreateEndsWithExpression },
                 { "contains", CreateContainsExpression },
                 { "doesnotcontain", CreateDoesNotContainExpression }
            };
        }
        private static Expression CreateStartsWithExpression(Expression property, Expression value)
        {
            return Expression.Call(property, typeof(string).GetMethod("StartsWith", new[] { typeof(string) }), value);
        }

        private static Expression CreateEndsWithExpression(Expression property, Expression value)
        {
            return Expression.Call(property, typeof(string).GetMethod("EndsWith", new[] { typeof(string) }), value);
        }

        private static Expression CreateContainsExpression(Expression property, Expression value)
        {
            return Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) }), value);
        }

        private static Expression CreateDoesNotContainExpression(Expression property, Expression value)
        {
            var containsExpression = Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) }), value);
            return Expression.Not(containsExpression);
        }
        public static Expression CreateDateTimeFilterExpression(Expression propertyExpression, string searchValue)
        {
            if (DateTime.TryParse(searchValue, out var parsedDate))
            {
                var datePartExpression = Expression.PropertyOrField(propertyExpression, "Date"); 
                var parsedDateExpression = Expression.Constant(parsedDate.Date);

                return Expression.Equal(datePartExpression, parsedDateExpression);
            }

            return null;
        }

    }
}
