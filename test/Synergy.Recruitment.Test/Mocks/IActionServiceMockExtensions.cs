using System.Numerics;

using NSubstitute;

using Synergy.Recruitment.Core.Services.Identity;

namespace Synergy.Recruitment.Test.Mocks
{
    public static class IActionServiceMockExtensions
    {
        public static void MockGetAsync(this IActionService actionService, long userId, BigInteger actionsEnum = default(BigInteger))
            => actionService
                .GetActiveUserActionsAsync(userId)
                .Returns(actionsEnum);
    }
}
