using System.Collections.Generic;
using System.Numerics;

namespace Synergy.Recruitment.Core.Extensions
{
    /// <summary>
    /// Authorization related extensions.
    /// </summary>
    public static class AuthorizationExtensions
    {
        /// <summary>
        /// Calculates the action integer out oc action enum values.
        /// </summary>
        /// <param name="actions">The actions list.</param>
        /// <returns>One int that holds the actions as flags.</returns>
        public static BigInteger CalculateActionsInteger(this IEnumerable<short> actions)
        {
            BigInteger sum = BigInteger.Zero;

            foreach (short action in actions)
            {
                sum |= BigInteger.One << action;
            }

            return sum;
        }
    }
}
