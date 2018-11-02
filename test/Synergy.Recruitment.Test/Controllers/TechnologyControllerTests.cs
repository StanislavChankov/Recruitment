using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;

using Synergy.Recruitment.Api.Controllers;
using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Data.Models;
using Synergy.Recruitment.Rest.Models.Technology;

namespace Synergy.Recruitment.Test.Controllers
{
    [TestClass]
    [TestCategory("Technology")]
    public class TechnologyControllerTests
    {
        private TechnologyController _controller;

        private ITechnologyService _technologyService;

        [TestInitialize]
        public void TestInitialize()
        {
            _technologyService = Substitute.For<ITechnologyService>();

            _controller = new TechnologyController(_technologyService);
        }

        #region Tests

        [TestMethod]
        public async Task GetAllAsync_200Ok()
        {
            MockGetAllAsync();

            IActionResult result = await _controller.GetAsync();

            var candidateResult = ((OkObjectResult)result).Value as IEnumerable<TechnologyResponse>;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(candidateResult, typeof(IEnumerable<TechnologyResponse>));
            Assert.IsFalse(candidateResult.Any());
        }

        #endregion

        #region Private Mock Methods

        private void MockGetAllAsync(IEnumerable<Technology> technologies = null)
            => _technologyService
                .GetAllAsync()
                .Returns(technologies ?? Enumerable.Empty<Technology>());

        #endregion
    }
}