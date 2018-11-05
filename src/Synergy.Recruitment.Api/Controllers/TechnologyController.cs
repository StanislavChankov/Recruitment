using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Data.Models;
using Synergy.Recruitment.Rest.Models.Technology;

namespace Synergy.Recruitment.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TechnologyController : Controller
    {
        private readonly ITechnologyService _technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TechnologyResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<Technology> technologies = await _technologyService.GetAllAsync();

            IEnumerable<TechnologyResponse> response = technologies.Select(TechnologyFactory.GetTechnologyResponse);

            return Ok(response);
        }
    }
}
