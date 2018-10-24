using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class Organization
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<RoleActionOrganization> RoleActionOrganizations { get; set; }
    }
}
