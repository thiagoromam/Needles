using System.Collections.Generic;
using System.Linq;

namespace Needles.Helpers
{
    internal static class EnumerableHelper
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }
    }
}