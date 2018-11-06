using System.Numerics;
using System.Threading.Tasks;

using Synergy.Recruitment.Core.Services.Identity;

namespace Synergy.Recruitment.Business.Authorization
{
    /// <summary>
    /// Identity api authorization provider.
    /// </summary>
    public class ApiAuthorizationProvider : IAuthorizationProvider
    {
        #region Fields

        private readonly IActionService _actionService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiAuthorizationProvider"/> class.
        /// </summary>
        public ApiAuthorizationProvider(IActionService actionService)
        {
            _actionService = actionService;
        }

        #endregion


        /// <summary>See <see cref="IAuthorizationProvider"/></summary>
        public Task<BigInteger> GetActionsAsync(long userId)
            => _actionService.GetActiveUserActionsAsync(userId);
    }
}
