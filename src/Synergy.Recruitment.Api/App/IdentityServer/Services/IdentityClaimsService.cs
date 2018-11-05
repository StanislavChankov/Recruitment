using IsResources = IdentityServer4.Models.Resources;
using IdentityServer4.Services;
using IdentityServer4.Validation;

using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Synergy.Recruitment.Api.App.IdentityServer.Services
{
    public class IdentityClaimsService : DefaultClaimsService
    {
        #region Fields

        //private readonly IUserService _userService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityClaimsService"/> class.
        /// </summary>
        public IdentityClaimsService(IProfileService profile/*, IUserService userService*/, ILogger<DefaultClaimsService> logger)
            : base(profile, logger)// => _userService = userService;
        {

        }
                

        #endregion

        #region Public Methods

        public override async Task<IEnumerable<Claim>> GetAccessTokenClaimsAsync(
            ClaimsPrincipal subject,
            IsResources resources,
            ValidatedRequest request)
        {
            IEnumerable<Claim> claims = await base.GetAccessTokenClaimsAsync(subject, resources, request);

            // if (subject == null)
            // {
            //     DataResult<long?> userId = await _userRepository.GetIdByUserNameAsync("", true);
            // 
            //     if (userId.HasValue)
            //     {
            //         claims = new List<Claim>(claims)
            //         {
            //             new Claim(JwtClaimTypes.Subject, userId.Value.ToString())
            //         };
            //     }
            // }

            return claims;
        }

        #endregion
    }
}
