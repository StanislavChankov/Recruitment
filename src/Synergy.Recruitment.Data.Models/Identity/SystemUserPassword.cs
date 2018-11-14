using Synergy.Recruitment.Data.Models.Abstract;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class SystemUserPassword : BaseEntity
    {
        public long SystemUserId { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public SystemUser SystemUser { get; set; }
    }
}
