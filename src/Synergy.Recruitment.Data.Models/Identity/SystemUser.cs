using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class SystemUser
    {
        public long Id { get; set; }

        public long PersonId { get; set; }

        public Person Person { get; set; }

        public ICollection<SystemUserPassword> SystemUserPasswords { get; set; }

        public ICollection<RoleActionUser> RoleActionUsers { get; set; }
    }
}
