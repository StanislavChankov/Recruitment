using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Synergy.Recruitment.Business.Services;
using Synergy.Recruitment.Core.Services;

namespace Synergy.Recruitment.Test.Services
{
    [TestClass]
    [TestCategory("Security")]
    public class SecurityServiceTests
    {

        private ISecurityService _securityService;

        [TestInitialize]
        public void TestInitialize()
        {
            _securityService = new SecurityService();
        }

        #region Tests

        [TestMethod]
        public void GenerateRandomPassword_CorrectLength()
        {
            string generated = _securityService.GenerateRandomPassword();

            Assert.AreEqual(8, generated.Length);
        }

        [TestMethod]
        public void GetHashedPassword_NullPainText_ShouldThrowArgNullEx()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => _securityService.GetHashedPassword(null, string.Empty));
        }

        [TestMethod]
        public void GetHashedPassword_NullSalt_ShouldThrowArgNullEx()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => _securityService.GetHashedPassword(string.Empty, null));
        }

        #endregion
    }
}
