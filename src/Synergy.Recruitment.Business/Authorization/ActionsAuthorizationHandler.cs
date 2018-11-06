using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

using Synergy.Recruitment.Core.Extensions;
using Synergy.Recruitment.Core.Services.Identity;

namespace Synergy.Recruitment.Business.Authorization
{
    /// <summary>
    /// The actions authorization handler.
    /// </summary>
    public sealed class ActionsAuthorizationHandler : AuthorizationHandler<RoleAction>
    {
        // private readonly IAuthorizationProvider _authorizationProvider;
        private readonly IActionService _actionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionsAuthorizationHandler" /> class.
        /// </summary>
        /// <param name="authorizationProvider">The authorization provider.</param>
        public ActionsAuthorizationHandler(IActionService actionService/*IAuthorizationProvider authorizationProvider*/)
        {
            _actionService = actionService;
            // _authorizationProvider = authorizationProvider;
        }

        /// <summary>
        /// Makes a decision if authorization is allowed based on a specific requirement.
        /// </summary>
        /// <param name="context">The authorization context.</param>
        /// <param name="roleAction">The role action to check.</param>
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAction roleAction)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail();

                return;
            }

            // long applicationId = await _authorizationProvider.GetApplicationIdAsync();
            long userId = context.User.GetUserId();

            // BigInteger actions = await _authorizationProvider.GetActionsAsync(applicationId, userId);
            BigInteger actions = await _actionService.GetActiveUserActionsAsync(userId);

            // Get the current needed role action flag.
            BigInteger currentAction = BigInteger.One << roleAction.Value;

            // Check if the projects actions contain the current needed action flag.
            if ((currentAction & actions) > 0)
            {
                context.Succeed(roleAction);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
