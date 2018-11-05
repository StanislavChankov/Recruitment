using System.Numerics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Synergy.Recruitment.Core.Services.Identity;

namespace Synergy.Recruitment.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ActionController : Controller
    {
        private readonly IActionService _actionService;

        public ActionController(IActionService actionService)
        {
            _actionService = actionService;
        }

        #region Actions

        /// <summary>
        /// Gets the user actions asynchronously.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(BigInteger), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [Route("~/api/users/{userId:long}/[controller]")]
        public async Task<IActionResult> GetAsync([FromRoute] long userId)
        {
            BigInteger actions = await _actionService.GetActiveUserActionsAsync(userId);

            if (actions == default(BigInteger))
            {
                return NotFound($"Either not found user with identifier: {userId} or not associated role/actions to this user.");
            }

            return Ok(actions);
        }

        #endregion
    }
}
