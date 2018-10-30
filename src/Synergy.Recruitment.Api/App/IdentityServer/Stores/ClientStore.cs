using IdentityServer4.Models;
using IdentityServer4.Stores;
using static IdentityServer4.IdentityServerConstants;

using Synergy.Recruitment.Resources;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synergy.Recruitment.Api.App.IdentityServer.Stores
{
    public class ClientStore : IClientStore
    {
        #region Fields

        public readonly IEnumerable<Client> _clients;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientStore"/> class.
        /// </summary>
        public ClientStore()
        {
            Client assessmentApiClient = GetRecruitmentApiClient();

            _clients = new[]
            {
                assessmentApiClient
            };
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Finds the client by identifier asynchronously.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>See <see cref="Client"/> for more.</returns>
        public Task<Client> FindClientByIdAsync(string clientId)
            => Task.FromResult(_clients.SingleOrDefault(c => c.ClientId == clientId));

        #endregion

        #region Private Methods

        private Client GetRecruitmentApiClient()
        {
            var recruitmentApiClient = new Client
            {
                ClientId = IdentityServerConstants.RECRUITMENT_API_ID,
                ClientName = IdentityServerConstants.RECRUITMENT_API_NAME,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                ClientSecrets = new List<Secret>
                {
                    new Secret(IdentityServerConstants.RECRUITMENT_API_SECRET.Sha256())
                },
                AllowedScopes = new List<string>
                {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
                    StandardScopes.Phone,
                    IdentityServerConstants.RECRUITMENT_API,
                    IdentityServerConstants.ORGANIZATION
                },
                UpdateAccessTokenClaimsOnRefresh = false,
                AllowOfflineAccess = false,
                RequireConsent = false,
                AuthorizationCodeLifetime = 900,
                IdentityTokenLifetime = 900,
                AccessTokenLifetime = 14400
            };

            return recruitmentApiClient;
        }

        #endregion
    }
}
