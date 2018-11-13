using System.Collections.Generic;

using Synergy.Recruitment.Data.Models.Abstract;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<RoleActionOrganization> RoleActionOrganizations { get; set; }

        public ICollection<SystemUser> SystemUsers { get; set; }
    }
}
