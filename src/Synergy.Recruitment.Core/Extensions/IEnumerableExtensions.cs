using System;
using System.Collections.Generic;
using System.Linq;

namespace Synergy.Recruitment.Core.Extensions
{
    /// <summary>
    /// Contains static <see cref="IEnumerable{T}"/> extension methods.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Picks a random item from the given <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="source"/></typeparam>
        /// <param name="source">The source.</param>
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }
    }
}
