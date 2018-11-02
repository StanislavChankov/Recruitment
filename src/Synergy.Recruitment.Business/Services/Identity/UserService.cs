using System;
using System.Threading.Tasks;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Business.Models.Users;
using Synergy.Recruitment.Core.Extensions;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Core.Services.Identity;

namespace Synergy.Recruitment.Business.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly ISecurityService _securityService;
        private readonly IUserRepository _userRepository;

        public UserService(ISecurityService securityService, IUserRepository userRepository)
        {
            _securityService = securityService;
            _userRepository = userRepository;
        }

        public async Task<UserPassword> ValidateCredentialsAsync(string emailAddress, string password)
        {
            emailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            password = password ?? throw new ArgumentNullException(nameof(password));

            var selectExp = UserFactory.GetUserByEmail(emailAddress, default(bool?));

            UserPassword user = await _userRepository.GetByEmailAsync(UserFactory.GetPersonOrganization, selectExp);

            string hashedPassword = _securityService.GetHashedPassword(password, user.PasswordSalt);

            if (hashedPassword.IsSimilarTo(user.PasswordHash))
            {
                return user;
            }

            return await Task.FromResult(default(UserPassword));
        }
    }
}
