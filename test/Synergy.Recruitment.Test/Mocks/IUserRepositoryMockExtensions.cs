using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using NSubstitute;

using Synergy.Recruitment.Business.Models.Users;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Test.Mocks
{
    public static class IUserRepositoryMockExtensions
    {
        public static void MockGetByEmailAsync(this IUserRepository userRepository, string salt = "Salt", string hashedPass = "HashedPassword")
            => userRepository
                .GetByEmailAsync(Arg.Any<Expression<Func<SystemUser, UserPassword>>>(), Arg.Any<Expression<Func<SystemUser, bool>>>())
                .ReturnsForAnyArgs(Task.FromResult(new UserPassword { PasswordSalt = salt, PasswordHash = hashedPass }));
    }
}
