namespace Synergy.Recruitment.Data.Models.Identity
{
    public class RoleActionUser
    {
        public long Id { get; set; }

        public long RoleActionOrganizationId { get; set; }

        public long SystemUserId { get; set; }

        public SystemUser SystemUser { get; set; }

        public RoleActionOrganization RoleActionOrganization { get; set; }
    }
}
