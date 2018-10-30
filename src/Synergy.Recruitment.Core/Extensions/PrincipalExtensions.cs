using System;
using System.Security.Claims;
using System.Security.Principal;

using IdentityModel;

namespace Synergy.Recruitment.Core.Extensions
{
    /// <summary>
    /// Contains static extension methods for <see cref="IPrincipal"/> and <see cref="ClaimsPrincipal"/>.
    /// </summary>
    public static class PrincipalExtensions
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="principal">The principal.</param>
        public static long GetUserId(this IPrincipal principal)
        {
            ClaimsIdentity identity = principal.Identity as ClaimsIdentity;

            string userIdString = identity?.FindFirst(JwtClaimTypes.Subject)?.Value;

            return Convert.ToInt64(userIdString);
        }
    }
}
