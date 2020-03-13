using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CruiseManager.Core.Util
{
    public static class IEnumerableExtentions
    {
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this ?? Enumerable.Empty<T>();
        }

        public static IEnumerable OrEmpty(this IEnumerable @this)
        {
            return @this ?? Enumerable.Empty<object>();
        }

        public static bool AnyAndNotNull<T>(this IEnumerable<T> @this)
        {
            return @this != null && @this.Any();
        }

        public static bool AnyAndNotNull<T>(this IEnumerable<T> @this, Func<T, bool> predicate)
        {
            return @this != null && @this.Any(predicate);
        }

        public static int MaxOrDefault<T>(this IEnumerable<T> @this, Func<T, int> selector, int dVal = default(int))
        {
            if (@this.AnyAndNotNull())
            { return @this.Max(selector); }
            else
            { return dVal; }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> e)
        {
            return e == null || e.Any() == false;
        }
    }
}