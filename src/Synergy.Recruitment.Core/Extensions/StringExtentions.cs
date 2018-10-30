using System;

namespace Synergy.Recruitment.Core.Extensions
{
    /// <summary>
    /// Constains static extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtentions
    {
        /// <summary>
        /// Checks whether two string objects are similar using ordinal ignore case.
        /// </summary>
        /// <param name="stringA">The string a.</param>
        /// <param name="stringB">The string b.</param>
        /// <returns><c>True</c> if they are equal, otherwise <c>False</c>.</returns>
        public static bool IsSimilarTo(this string stringA, string stringB)
            => string.Compare(stringA, stringB, StringComparison.OrdinalIgnoreCase) == 0;
    }
}
