using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class SystemUser
    {
        public long Id { get; set; }

        public long PersonId { get; set; }

        public long OrganizationId { get; set; }

        public long SystemUserPasswordId { get; set; }

        public Person Person { get; set; }

        public Organization Organization { get; set; }

        public SystemUserPassword SystemUserPassword { get; set; }

        public ICollection<RoleActionUser> RoleActionUsers { get; set; }
    }
}
