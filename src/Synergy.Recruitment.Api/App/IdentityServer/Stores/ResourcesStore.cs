using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IdentityServer4.Models;
using IdentityServer4.Stores;
using IsResources = IdentityServer4.Models.Resources;

using Synergy.Recruitment.Api.App.IdentityServer.CustomResources;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Api.App.IdentityServer.Stores
{
    public class ResourcesStore : IResourceStore
    {
        #region Fields

        public static IEnumerable<IdentityResource> _identityResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResources.Phone(),
            new CustomIdentityResources.OrganizationResource()
        };

        public static IEnumerable<ApiResource> _apiResources = new List<ApiResource>
        {
            new ApiResource(IdentityServerConstants.RECRUITMENT_API, IdentityServerConstants.RECRUITMENT_API_DISPLAY_NAME),
        };

        #endregion

        #region Public methods

        /// See <see cref="IResourceStore"/> for more.
        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            ApiResource apiResource = _apiResources
                .SingleOrDefault(a => a.Name == name);

            return Task.FromResult(apiResource);
        }

        /// See <see cref="IResourceStore"/> for more.
        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<ApiResource> apiResources = Enumerable.Empty<ApiResource>();

            if (scopeNames != null && scopeNames.Any())
            {
                apiResources = _apiResources
                    .SelectMany(a => a.Scopes, (a, s) => new
                    {
                        ApiResource = a,
                        Scope = s,
                    })
                    .Where(r => scopeNames.Contains(r.Scope.Name))
                    .Select(r => r.ApiResource)
                    .Distinct();
            }

            return Task.FromResult(apiResources);
        }

        /// See <see cref="IResourceStore"/> for more.
        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<IdentityResource> identityResources = Enumerable.Empty<IdentityResource>();

            if (scopeNames != null && scopeNames.Any())
            {
                identityResources = _identityResources.Where(ir => scopeNames.Contains(ir.Name));
            }

            return Task.FromResult(identityResources);
        }

        /// See <see cref="IResourceStore"/> for more.
        public Task<IsResources> GetAllResourcesAsync()
        {
            var resources = new IsResources(_identityResources, _apiResources);

            return Task.FromResult(resources);
        }

        #endregion
    }
}
