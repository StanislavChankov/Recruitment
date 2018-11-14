using System.Collections.Generic;

using Synergy.Recruitment.Data.Models.Abstract;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<RoleActionOrganization> RoleActionOrganizations { get; set; }

        public ICollection<SystemUser> SystemUsers { get; set; }

        public ICollection<DefaultRoleAction> DefaultRoleActions { get; set; }
    }
}
