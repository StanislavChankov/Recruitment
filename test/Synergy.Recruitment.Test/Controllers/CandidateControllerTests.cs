using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;

using Synergy.Recruitment.Api.Controllers;
using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Rest.Models.Candidate;
using Synergy.Recruitment.Test.Mocks;

namespace Synergy.Recruitment.Test.Controllers
{
    [TestClass]
    [TestCategory("Candidate")]
    public class CandidateControllerTests
    {
        private CandidateController _controller;

        private ICandidateService _candidateService;

        [TestInitialize]
        public void TestInitialize()
        {
            _candidateService = Substitute.For<ICandidateService>();

            _controller = new CandidateController(_candidateService);
        }

        #region Tests

        [TestMethod]
        public async Task GetAllAsync_200Ok()
        {
            _candidateService.MockGetAllAsync();

            IActionResult result = await _controller.GetAsync();

            var candidateResult = ((OkObjectResult)result).Value as IEnumerable<CandidateResponse>;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(candidateResult, typeof(IEnumerable<CandidateResponse>));
            Assert.IsTrue(candidateResult.Any());
        }

        #endregion
    }
}
