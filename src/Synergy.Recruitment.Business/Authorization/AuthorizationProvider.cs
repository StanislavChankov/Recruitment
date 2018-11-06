using System.Numerics;
using System.Threading.Tasks;

using Synergy.Recruitment.Core.Services.Identity;

namespace Synergy.Recruitment.Business.Authorization
{
    public class AuthorizationProvider : IAuthorizationProvider
    {
        private readonly IActionService _actionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationProvider"/> class.
        /// </summary>
        public AuthorizationProvider(IActionService actionService)
        {
            _actionService = actionService;
        }

        /// See <see cref="IAuthorizationProvider"/> for more.
        public Task<BigInteger> GetActionsAsync(long userId)
        {
            if (userId <= 0L)
            {
                return Task.FromResult(BigInteger.Zero);
            }

            return _actionService.GetActiveUserActionsAsync(userId);
        }
    }
}
