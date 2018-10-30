using System.Collections.Generic;

using IdentityServer4.Models;

using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Api.App.IdentityServer.CustomResources
{
    public static class CustomIdentityResources
    {
        public class OrganizationResource : IdentityResource
        {
            public OrganizationResource()
            {
                Name = IdentityServerConstants.ORGANIZATION;
                DisplayName = IdentityServerConstants.OrganizationName;
                // Emphasize = true;
                UserClaims = new List<string>
                {
                    IdentityServerConstants.Org
                };
            }
        }
    }

}
