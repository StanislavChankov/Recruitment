using System;
using System.Linq.Expressions;

using Synergy.Recruitment.Business.Models.Organizations;
using Synergy.Recruitment.Core.Extensions;
using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Rest.Models.Authorization;

namespace Synergy.Recruitment.Business.Factories
{
    public static class OrganizationFactory
    {
        /// <summary>
        /// Gets the <see cref="OrganizationLogic"/> out of <see cref="Organization"/>.
        /// </summary>
        public static Expression<Func<Organization, OrganizationLogic>> GetOrganizationLogic
            => organization
                => new OrganizationLogic
                {
                    Id = organization.Id,
                    Name = organization.Name,
                };

        public static Expression<Func<Organization, bool>> GetOrganizationByName(string name)
            => organization
                => organization.Name.IsSimilarTo(name);

        /// <summary>
        /// Gets the <see cref="Organization"/> out of <see cref="UserOrganizationInsertRequest"/>.
        /// </summary>
        public static Func<UserOrganizationInsertRequest, Organization> GetOrganization
            => request
                => new Organization
                {
                    Name = request.OrganizationName
                };
    }
}
