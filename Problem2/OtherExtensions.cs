using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Problem2
{
    public static class OtherExtensions
    {
        public static IEnumerable<TSource> Duplicates<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> selector)
        {
            var grouped = source.GroupBy(selector);
            var moreThen1 = grouped.Where(i => i.IsMultiple());

            return moreThen1.SelectMany(i => i);
        }

        public static bool IsMultiple<String>(this IEnumerable<String> source)
        {
            var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() && enumerator.MoveNext();
        }

        public static IEnumerable<String> ToIEnumarable<String>(this String item)
        {
            yield return item;
        }

        public static string FormatInvariant(this string text, params object[] parameters)
        {
            return string.Format(CultureInfo.InvariantCulture, text, parameters);
        }
    }
}