using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Synergy.Recruitment.Core.Services.Identity;
using Synergy.Recruitment.Rest.Models.Authorization;

namespace Synergy.Recruitment.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserOrganizationInsertRequest UserOrgInsertRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.CreateUserOrganizationAsync(UserOrgInsertRequest);

            return Ok();
        }
    }
}
