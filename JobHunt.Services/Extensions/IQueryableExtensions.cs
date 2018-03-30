using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JobHunt.Services.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable IncludeBaseModel<T>(this IQueryable<T> query, Type type) where T : class
        {
            var properties = type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(ø => ø.CanRead && ø.CanWrite)
                .Where(ø => ø.PropertyType == typeof(string))
                .ToList();

            if (properties.Count > 0)
            {
                foreach (var pro in properties)
                {
                    //query = query.Select()
                }
            }

            return query;
        }
    }
}
