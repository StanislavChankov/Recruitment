using Synergy.Recruitment.Business.Models.Authorization;

namespace Synergy.Recruitment.Business.Factories
{
    public static class AuthorizationFactory
    {
        public static HashedPassword GetHashedPassword(string hashedPass, string salt)
            => new HashedPassword
            {
                PasswordHash = hashedPass,
                Salt = salt
            };
    }
}
