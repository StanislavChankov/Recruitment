using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using IdentityServer4.Validation;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Api.App.IdentityServer.Services
{
    /// <summary>
    /// Client credentials token request validator class.
    /// </summary>
    public class ClientCredentialsTokenRequestValidator : ICustomTokenRequestValidator
    {
        #region Constants

        private const string ORGANIZATION_ID = "organizationId";

        #endregion

        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        // private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientCredentialsTokenRequestValidator" /> class.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// <param name="organizationRepository">The organization repository.</param>
        public ClientCredentialsTokenRequestValidator(
            IHttpContextAccessor httpContextAccessor
            // IOrganizationRepository organizationRepository
            )
        {
            _httpContextAccessor = httpContextAccessor;
            //_organizationRepository = organizationRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Custom validation logic for a token request.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task ValidateAsync(CustomTokenRequestValidationContext context)
        {
            HttpRequest httpRequest = _httpContextAccessor.HttpContext?.Request;

            if (httpRequest != null && httpRequest.Form.TryGetValue(IdentityServerConstants.ORGANIZATION, out StringValues stringValues) && stringValues.Any())
            {
                ICollection<Claim> clientClaims = context.Result.ValidatedRequest.ClientClaims;

                clientClaims.Add(new Claim(ORGANIZATION_ID, 1.ToString()));

                if (!clientClaims.Any(c => c.Type.Equals(ORGANIZATION_ID, StringComparison.OrdinalIgnoreCase)))
                {
                    //long? organizationId = (await _organizationRepository.GetByShortNameAndOrganizationTypeWithCacheAsync(stringValues[0], null))?.OrganizationId;

                    //if (organizationId.HasValue)
                    //{
                    //    clientClaims.Add(new Claim(ORGANIZATION_ID, organizationId.Value.ToString()));
                    //}
                    //else
                    //{
                    //    context.Result.IsError = true;
                    //    // context.Result.Error = ValidationMessages.DB_ORGANIZATION_NOT_EXIST;
                    //}
                }
            }
        }

        #endregion
    }
}
