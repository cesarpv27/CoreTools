using System;
using System.Collections.Generic;
using System.Text;
using ExThrower = CoreTools.Throws.ExceptionThrower;

namespace CoreTools.Extensions
{
    public static class ListExtensions
    {
        public static void CopyTo<T>(this IList<T> source, int index, IList<T> dest, int count)
        {
            if (dest == null)
                ExThrower.ST_ThrowArgumentNullException(nameof(dest));

            if (index < 0 || source.Count - 1 < index)
                ExThrower.ST_ThrowArgumentOutOfRangeException(nameof(index), index.ToString());

            if (count < 0)
                ExThrower.ST_ThrowArgumentOutOfRangeException(nameof(count), count.ToString());

            if (source.Count - index < count)
                ExThrower.ST_ThrowArgumentException("Number of items minus 'index' is less than 'count'");

            for (int i = index; i < count; i++)
                dest.Add(source[i]);
        }
    }
}
