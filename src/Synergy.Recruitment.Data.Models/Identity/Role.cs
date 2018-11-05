using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class Role
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<RoleActionOrganization> RoleActionOrganizations { get; set; }

        public ICollection<SystemUser> SystemUsers { get; set; }
    }
}
