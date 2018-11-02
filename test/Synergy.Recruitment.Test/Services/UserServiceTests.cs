using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;
using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Business.Models.Users;
using Synergy.Recruitment.Business.Services.Identity;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Core.Services.Identity;
using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Test.Mocks;

namespace Synergy.Recruitment.Test.Services
{
    [TestClass]
    [TestCategory("User")]
    public class UserServiceTests
    {
        private ISecurityService _securityService;
        private IUserRepository _userRepository;
        private IUserService _userService;

        [TestInitialize]
        public void TestInitialize()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _securityService = Substitute.For<ISecurityService>();

            _userService = new UserService(_securityService, _userRepository);
        }

        [TestMethod]
        public async Task ValidateCredentialsAsync_CallsRepoWithCorrectArgs()
        {
            var email = "test@gmail.com";
            var selectExp = UserFactory.GetUserByEmail(email, default(bool?));
            _userRepository.MockGetByEmailAsync();
            _securityService.MockGetHashedPassword();

            var result = await _userService.ValidateCredentialsAsync(email, string.Empty);
            
            await _userRepository
                    .ReceivedWithAnyArgs()
                    .GetByEmailAsync(UserFactory.GetPersonOrganization, selectExp);
        }

        [TestMethod]
        public async Task ValidateCredentialsAsync_CallsSecurityService()
        {
            var email = "test@gmail.com";
            var selectExp = UserFactory.GetUserByEmail(email, default(bool?));
            _userRepository.MockGetByEmailAsync();
            _securityService.MockGetHashedPassword();

            var result = await _userService.ValidateCredentialsAsync(email, string.Empty);

            _securityService
                    .ReceivedWithAnyArgs()
                    .GetHashedPassword("HashedPassword", "Salt");
        }

        [TestMethod]
        public async Task ValidateCredentialsAsync_ReturnsCorrectObject()
        {
            var email = "test@gmail.com";
            var selectExp = UserFactory.GetUserByEmail(email, default(bool?));
            _userRepository.MockGetByEmailAsync();
            _securityService.MockGetHashedPassword();

            var result = await _userService.ValidateCredentialsAsync(email, string.Empty);

            Assert.AreEqual(default(long), result.Id);
            Assert.AreEqual("Salt", result.PasswordSalt);
            Assert.AreEqual("HashedPassword", result.PasswordHash);
        }

        [TestMethod]
        public async Task ValidateCredentialsAsync_ReturnsNull()
        {
            var email = "test@gmail.com";
            var selectExp = UserFactory.GetUserByEmail(email, default(bool?));
            _userRepository.MockGetByEmailAsync(hashedPass: "WrongPassword");
            _securityService.MockGetHashedPassword();

            var result = await _userService.ValidateCredentialsAsync(email, string.Empty);

            Assert.AreEqual(default(UserPassword), result);
        }

        [TestMethod]
        public async Task ValidateCredentialsAsync_NullEmail_ShouldThrow()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await _userService.ValidateCredentialsAsync(null, string.Empty));
        }

        [TestMethod]
        public async Task ValidateCredentialsAsync_NullPass_ShouldThrow()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await _userService.ValidateCredentialsAsync(string.Empty, null));
        }
    }
}
