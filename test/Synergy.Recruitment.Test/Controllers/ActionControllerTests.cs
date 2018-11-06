using System.Numerics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;

using Synergy.Recruitment.Api.Controllers;
using Synergy.Recruitment.Core.Services.Identity;
using Synergy.Recruitment.Test.Mocks;

namespace Synergy.Recruitment.Test.Controllers
{
    [TestClass]
    [TestCategory("Action")]
    public class ActionControllerTests
    {
        private IActionService _actionService;
        private ActionController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _actionService = Substitute.For<IActionService>();

            _controller = new ActionController(_actionService);
        }

        #region Tests

        [TestMethod]
        public async Task GetAsync_200Ok()
        {
            var userId = 1;
            var actions = 123;
            _actionService.MockGetAsync(userId, actions);

            IActionResult result = await _controller.GetAsync(userId);
            var resultValue = (BigInteger)((OkObjectResult)result).Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(actions, resultValue);
        }

        [TestMethod]
        public async Task GetAsync_404NotFound()
        {
            var userId = 0;
            _actionService.MockGetAsync(userId);

            IActionResult result = await _controller.GetAsync(userId);
            var resultValue = ((NotFoundObjectResult)result).Value.ToString();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
            Assert.AreEqual($"Either not found user with identifier: {userId} or not associated role/actions to this user.", resultValue);
        }

        #endregion
    }
}
