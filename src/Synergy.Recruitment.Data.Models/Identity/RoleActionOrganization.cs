using Synergy.Recruitment.Data.Models.Abstract;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class RoleActionOrganization : BaseEntity
    {
        public long RoleId { get; set; }

        public long ActionId { get; set; }

        public long OrganizationId { get; set; }

        public Role Role { get; set; }

        public Action Action { get; set; }

        public Organization Organization { get; set; }
    }
}
