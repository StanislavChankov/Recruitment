using Synergy.Recruitment.Data.Models.Abstract;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class DefaultRoleAction : BaseEntity
    {
        public long RoleId { get; set; }

        public long ActionId { get; set; }

        public Role Role { get; set; }

        public Action Action { get; set; }
    }
}
