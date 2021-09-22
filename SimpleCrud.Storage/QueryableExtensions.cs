using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Storage
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Usage:
        ///     query = query.WhereEqual(x => x.Id, 85);
        ///     query = query.WhereEqual(x => x.User.LastName + " " + x.User.FirstName, "Jon Green");
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertySelector"></param>
        /// <param name="value"></param>
        /// <returns>new aggregated IQueryable filter </returns>
        public static IQueryable<TSource> WhereEqual<TSource, TProperty>(this IQueryable<TSource> query, Expression<Func<TSource, TProperty>> propertySelector, TProperty value)
        {
            var body = Expression.Equal(propertySelector.Body, Expression.Constant(value));
            var lambda = Expression.Lambda<Func<TSource, bool>>(body, propertySelector.Parameters);
            return query.Where(lambda);
        }
    }
}
