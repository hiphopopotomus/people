using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace webapi.Entities
{
    public interface ITypedEnumeration : IComparable
    {
        public static IEnumerable<T> GetAll<T>() where T : ITypedEnumeration
        {
            var values = new List<T>();

            // Add all public static fields as valid enum values
            values.AddRange(typeof(T).GetFields(BindingFlags.Public |
                                                BindingFlags.Static |
                                                BindingFlags.DeclaredOnly)
                                            .Select(f => f.GetValue(null)).Cast<T>());

            // Add all public static properties as valid enum values
            values.AddRange(typeof(T).GetProperties(BindingFlags.Public |
                                                BindingFlags.Static |
                                                BindingFlags.DeclaredOnly)
                                            .Select(p => p.GetValue(null)).Cast<T>());

            return values;
        }

        public static T GetValue<T>(object key) where T : ITypedEnumeration
        {
            return GetAll<T>().Single(value => typeof(T).GetProperty("Id").GetValue(value).Equals(key));
        }
    }
}
