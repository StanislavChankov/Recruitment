using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Business.Factories
{
    public static class RoleActionOrganizationFactory
    {
        public static RoleActionOrganization GetRoleActionOrganization(long orgId, long roleId, long actionId)
            => new RoleActionOrganization
            {
                OrganizationId = orgId,
                RoleId = roleId,
                ActionId = actionId
            };
    }
}
