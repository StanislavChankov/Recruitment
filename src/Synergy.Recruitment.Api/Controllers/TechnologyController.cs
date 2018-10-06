using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Synergy.Recruitment.Core.Services;

namespace Synergy.Recruitment.Api.Controllers
{
    [Route("api/[controller]")]
    public class TechnologyController : Controller
    {
        private readonly ITechnologyService _technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var technologies = await _technologyService.GetAllAsync();

            return Ok(technologies);
        }
    }
}
