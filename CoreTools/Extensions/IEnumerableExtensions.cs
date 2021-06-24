using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExThrower = CoreTools.Throws.ExceptionThrower;

namespace CoreTools.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (var item in @this)
                action(item);
        }

        public static string JoinAll(this IEnumerable<string> @this, string separator)
        {
            ExThrower.ST_ThrowIfArgumentIsNull(separator, nameof(separator));

            string result = default;

            int index = 0;
            int totalMinusOne = @this.Count() - 1;
            foreach (var item in @this)
            {
                result += item;
                if (index++ < totalMinusOne)
                    result += separator;
            }

            return result;
        }
    }
}
