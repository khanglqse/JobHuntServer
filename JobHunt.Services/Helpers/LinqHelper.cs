﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace JobHunt.Services.Helpers
{
    public static class LinqHelper
    {
        public static Expression<Func<T, TKey>> OrderExpression<T, TKey>(string memberName)
        {
            ParameterExpression[] typeParams = { Expression.Parameter(typeof(T), "") };

            Expression<Func<T, TKey>> orderByExpression = (Expression<Func<T, TKey>>)Expression.Lambda(
                    Expression.Property(typeParams[0], memberName), typeParams);
            return orderByExpression;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> input, string memberName, string sord)
        {
            ParameterExpression[] typeParams = new ParameterExpression[] { Expression.Parameter(typeof(T), "") };
            PropertyInfo pro = typeof(T).GetProperty(memberName);
            Type type = pro.PropertyType;
            if (type == typeof(DateTime))
            {
                var expression = OrderExpression<T, DateTime>(memberName);
                return "ASC".Equals(sord, StringComparison.OrdinalIgnoreCase) ? input.OrderBy(expression) : input.OrderByDescending(expression);
            }
            else if (type == typeof(DateTime?))
            {
                var expression = OrderExpression<T, DateTime?>(memberName);
                return "ASC".Equals(sord, StringComparison.OrdinalIgnoreCase) ? input.OrderBy(expression) : input.OrderByDescending(expression);
            }
            else if (type == typeof(int))
            {
                var expression = OrderExpression<T, int>(memberName);
                return "ASC".Equals(sord, StringComparison.OrdinalIgnoreCase) ? input.OrderBy(expression) : input.OrderByDescending(expression);
            }
            else if (type == typeof(int?))
            {
                var expression = OrderExpression<T, int?>(memberName);
                return "ASC".Equals(sord, StringComparison.OrdinalIgnoreCase) ? input.OrderBy(expression) : input.OrderByDescending(expression);
            }
            else if (type == typeof(double))
            {
                var expression = OrderExpression<T, double>(memberName);
                return "ASC".Equals(sord, StringComparison.OrdinalIgnoreCase) ? input.OrderBy(expression) : input.OrderByDescending(expression);
            }
            else if (type == typeof(double?))
            {
                var expression = OrderExpression<T, double?>(memberName);
                return "ASC".Equals(sord, StringComparison.OrdinalIgnoreCase) ? input.OrderBy(expression) : input.OrderByDescending(expression);
            }
            else if (type == typeof(string))
            {
                var expression = OrderExpression<T, string>(memberName);
                return "ASC".Equals(sord, StringComparison.OrdinalIgnoreCase) ? input.OrderBy(expression) : input.OrderByDescending(expression);
            }
            else if (type == typeof(bool))
            {
                var expression = OrderExpression<T, bool>(memberName);
                return "ASC".Equals(sord, StringComparison.OrdinalIgnoreCase) ? input.OrderBy(expression) : input.OrderByDescending(expression);
            }
            else if (type == typeof(bool?))
            {
                var expression = OrderExpression<T, bool?>(memberName);
                return "ASC".Equals(sord, StringComparison.OrdinalIgnoreCase) ? input.OrderBy(expression) : input.OrderByDescending(expression);
            }
            return input;
        }

        private static object GetPropertyValue(object obj, string property)
        {
            System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo.GetValue(obj, null);
        }

        /// <summary>
        /// Get Name of Property of Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetPropertyName<T, TResult>(Expression<Func<T, TResult>> expression)
        {
            var me = expression.Body as MemberExpression;
            if (me != null)
            {
                return me.Member.Name;
            }
            return null;
        }

        public static Func<T, object> GetOrderByExpression<T>(string sortColumn)
        {
            Func<T, object> orderByExpr = null;
            if (!String.IsNullOrEmpty(sortColumn))
            {
                Type sponsorResultType = typeof(T);

                if (sponsorResultType.GetProperties().Any(prop => prop.Name == sortColumn))
                {
                    System.Reflection.PropertyInfo pinfo = sponsorResultType.GetProperty(sortColumn);
                    orderByExpr = (data => pinfo.GetValue(data, null));
                }
            }
            return orderByExpr;
        }

        public static Expression<Func<T, object>> OrderExpression<T>(string memberName)
        {
            ParameterExpression[] typeParams = new ParameterExpression[] { Expression.Parameter(typeof(T), "") };
            var func = GetOrderByExpression<T>(memberName);

            var orderByExpression = (Expression<Func<T, object>>)Expression.Lambda<Func<T, object>>(Expression.Call(func.Method));

            return orderByExpression;
        }

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

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)

            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first

            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }

    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}