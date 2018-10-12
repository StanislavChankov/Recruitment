using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Data.Models;
using Synergy.Recruitment.Rest.Models.Candidate;

namespace Synergy.Recruitment.Api.Controllers
{
    [Route("api/[controller]")]
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CandidateResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<Candidate> candidates = await _candidateService.GetAllAsync();

            IEnumerable<CandidateResponse> response = candidates.Select(CandidateFactory.GetCandidateResponse);

            return Ok(response);
        }
    }
}
