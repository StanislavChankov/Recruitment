using System.Numerics;
using System.Threading.Tasks;

namespace Synergy.Recruitment.Core.Services.Identity
{
    public interface IActionService
    {
        /// <summary>
        /// Gets the user actions asynchronously.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        Task<BigInteger> GetActiveUserActionsAsync(long userId);
    }
}
