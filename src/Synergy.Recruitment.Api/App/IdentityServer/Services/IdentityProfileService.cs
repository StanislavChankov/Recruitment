using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using IdentityModel;

using IdentityServer4.Models;
using IdentityServer4.Services;

using Synergy.Recruitment.Business.Models.Person;
using Synergy.Recruitment.Core.Extensions;
using Synergy.Recruitment.Core.Services.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Api.App.IdentityServer.Services
{
    /// <summary>
    /// Implementation for IDSV4 services.
    /// </summary>
    /// <seealso cref="IProfileService" />
    /// <seealso cref="IResourceOwnerPasswordValidator" />
    public class IdentityProfileService : IProfileService
    {
        #region Fields

        private readonly IPersonService _personService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProfileService"/> class.
        /// </summary>
        public IdentityProfileService(IPersonService personService)
        {
            _personService = personService;
        }

        #endregion

        /// <summary>
        /// Gets the profile data asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            long sub = context.Subject.GetUserId();

            PersonOrganization person = await _personService.GetByUserIdAsync(sub);

            context.IssuedClaims = GetClaimsValues(person);
            // TODO: RequestedClaimTypes is always empty => IssuedClaims never get filtered.
            if (context.IssuedClaims != null
                && context.RequestedClaimTypes != null
                && context.RequestedClaimTypes.Any())
            {
                context.IssuedClaims = context.IssuedClaims.Where(c => context.RequestedClaimTypes.Contains(c.Type)).ToList();
            }
        }

        /// <summary>
        /// Determines whether context [is active] asynchronously.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual Task IsActiveAsync(IsActiveContext context)
        {
            // If the user was found in the db, it is always active.
            context.IsActive = true;

            return Task.CompletedTask;
        }

        #region Private Methods

        private List<Claim> GetClaimsValues(PersonOrganization person)
        {
            person = person ?? throw new ArgumentNullException(nameof(person));

            var claims = new List<Claim>()
            {
                new Claim(JwtClaimTypes.Name, string.Format("{0} {1}", person.FirstName, person.LastName)),
                new Claim(JwtClaimTypes.GivenName, person.FirstName ?? string.Empty),
                // new Claim(JwtClaimTypes.MiddleName, person.MiddleName ?? string.Empty),
                new Claim(JwtClaimTypes.FamilyName, person.LastName ?? string.Empty),
                new Claim(JwtClaimTypes.Email, person.EmailAddress ?? string.Empty),
                new Claim(JwtClaimTypes.BirthDate, person.BirthDate.HasValue ? person.BirthDate.Value.ToString() : string.Empty),
                // new Claim(JwtClaimTypes.Profile, person.PersonGuid.ToString()),
                new Claim(IdentityServerConstants.Org, person.OrganizationId.ToString()),
            };

            return claims;
        }

        #endregion
    }
}