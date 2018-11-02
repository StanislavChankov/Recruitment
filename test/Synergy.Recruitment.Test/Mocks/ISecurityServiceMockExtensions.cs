using NSubstitute;

using Synergy.Recruitment.Core.Services;

namespace Synergy.Recruitment.Test.Mocks
{
    public static class ISecurityServiceMockExtensions
    {
        public static void MockGetHashedPassword(this ISecurityService securityService, string hashedPass = "HashedPassword")
            => securityService
                .GetHashedPassword(Arg.Any<string>(), Arg.Any<string>())
                .ReturnsForAnyArgs(hashedPass);
    }
}
